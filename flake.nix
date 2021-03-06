{
  description = "ColoradoHealthOasis";
  inputs.nixpkgs.url = "github:nixos/nixpkgs";
  inputs.flake-utils.url = "github:numtide/flake-utils";
  inputs.flake-compat = {
    url = github:edolstra/flake-compat;
    flake = false;
  };
  inputs.android2nix = {
    url = github:Mazurel/android2nix;
  };
  inputs.dotnet.url = "github:Programmerino/dotnet-nix";
  inputs.fableFlake.url = "github:Programmerino/fable.nix";

  outputs = { self, nixpkgs, flake-utils, flake-compat, android2nix, dotnet, fableFlake }:
    flake-utils.lib.eachSystem [ "x86_64-linux" "x86_64-darwin" "aarch64-darwin" ] (system:
      let
        fable = fableFlake.defaultPackage."${system}";
        pkgs = import nixpkgs { 
          inherit system;
          config = {
            android_sdk.accept_license = true;
          };
        };

        futTarget = "app.fut";
        name = "ColoradoHealthOasis";
        packageName = "com.programmerino.fableguitemplate";
        version = let _ver = builtins.getEnv "GITVERSION_SEMVER"; in if _ver == "" then "0.0.0" else "${_ver}";
        configArg = "";
        lockFile = ./fsharp/dotnet/packages.lock.json;
        nugetSha256 = "sha256-zs09cpXkc25NvObQjj7aBVfpL1CnCWJ6Xwc+6ugo7WQ=";
        project = "";
        FSharpEntry = "App.fs";
        FSharpOut = "App.js";
        FSharpConfig = "Release";
        FableDoOptimize = false;
        src = ./.;


        sdk = pkgs.dotnet-sdk;
        jdk = pkgs.zulu;
        nodejs = pkgs.nodejs-12_x;

        fsharp-modules =
            pkgs.mkYarnModules {
              inherit version;
              pname = "${name}-fsharp-modules";
              yarnLock = ./fsharp/deps/yarn.lock;
              packageJSON = ./fsharp/deps/package.json;
           };

        fsharp = dotnet.buildDotNetProject.${system} rec {
          inherit name version sdk system;
          inherit nugetSha256 lockFile;
          library = false;
          src = ./fsharp/dotnet;
          preBuild = ''
            cd ..
            mkdir -p deps
            cp -Rs ${fsharp-modules}/node_modules deps/
            cd -
          '';
          useFable = true;
          fablePackage = fable;
          nodePackage = nodejs;
        };

        platformToolsVersion = "31.0.3";
        buildToolsVersions = [ "30.0.3" ]; # Cordova doesn't support newer versions yet
        platformVersions = [ "30" ];
        abiVersions = [ "armeabi-v7a" ];
        ndkVersions = [ "22.1.7171670" ];
        cmakeVersions = [ "3.10.2" ];
        emulatorVersion = "30.9.0";
        includeNDK = false;
        includeEmulator = false;
        includeSources = false;
        includeSystemImages = false;
        useGoogleAPIs = false;
        useGoogleTVAddOns = false;
        androidComposition = pkgs.androidenv.composeAndroidPackages {
          inherit platformToolsVersion buildToolsVersions platformVersions abiVersions;
          inherit ndkVersions cmakeVersions emulatorVersion includeNDK includeEmulator;
          inherit includeSources includeSystemImages useGoogleAPIs useGoogleTVAddOns;
        };

        bundle = pkgs.stdenv.mkDerivation {
          name = "${name}-bundle";
          inherit version;
          dontStrip = true;
          dontPatch = true;
          dontUnpack = true;
          dontInstall = true;
          dontFixup = true;
          dontConfigure = true;
          buildPhase = ''
              mkdir -p $out/{js,css}
              cp -rs ${fsharp-modules}/node_modules ./node_modules
              cp -r ${fsharp}/. .
              cp ${./fsharp/deps/esbuild.js} ./esbuild.js
              ${nodejs}/bin/node esbuild.js $PWD/${FSharpOut}
              mv $out/*.js $out/js/${FSharpOut}
              mv $out/*.css $out/css/bundle.css
          '';
        };

        tomlStringify = x: "[ \"" + (pkgs.lib.strings.concatStringsSep ", " x) + "\" ]";
        androidEnv = android2nix.lib.mkAndroid2nixEnv (
                { ... }: {
                pname = name;
                src = builtins.filterSource (path: type: false) ./.;
                gradlePkg = pkgs.gradle;
                jdk = jdk;
                devshell = pkgs.writeTextFile {
                    name = "devshell.toml";
                    text = ''
                      [devshell]
                      startup.main.text = """
                      #eval \"(starship init bash)\"
                      function watchBuild() {
                        if [[ "$PWD" == *"dev"* ]]; then
                          function clean_up {
                               kill -9 $WATCHER_PID
                          }
                          trap clean_up SIGHUP SIGINT SIGTERM
                          cd ..
                          cp -rlf $PWD/web/www/. $PWD/dev/
                          cp -rsf $PWD/fsharp/deps/. $PWD/dev/
                          cp -rlf $PWD/fsharp/dotnet/. $PWD/dev/src
                          cd dev
                          mkdir -p deps
                          ln -sf $PWD/node_modules $PWD/deps/node_modules
                          yarn install
                          futhark wasm-multicore --library ../futhark/${futTarget} -o js/${futTarget}
                          while inotifywait -e close_write ../futhark/${futTarget}; do futhark wasm-multicore --library ../futhark/${futTarget} -o js/${futTarget}; done &
                          WATCHER_PID=$!
                          fable watch src -o js --runFast "start.sh"
                          kill -9 $WATCHER_PID
                        else
                          echo Please move to the dev directory
                        fi
                      }

                      function build() {
                        if [[ "$PWD" == *"dev"* ]]; then
                          cd ..
                          cp -rlf $PWD/web/www/. $PWD/dev/
                          cp -rsf $PWD/fsharp/deps/. $PWD/dev/
                          cp -rlf $PWD/fsharp/dotnet/. $PWD/dev/src
                          cd dev
                          mkdir public
                          cp *.png ./public
                          cp browserconfig.xml ./public
                          cp favicon.ico ./public
                          cp robots.txt ./public
                          cp *.svg ./public
                          cp *.webmanifest ./public
                          mkdir -p deps
                          ln -sf $PWD/node_modules $PWD/deps/node_modules
                          yarn install
                          fable src -o js
                          yarn exec -- vite build --minify terser
                          echo Result is in dist!
                        else
                          echo Please move to the dev directory
                        fi
                      }
                      """
                      [android]
                      platformToolsVersion = "${platformToolsVersion}"
                      buildToolsVersions = ${tomlStringify buildToolsVersions}
                      platformVersions = ${tomlStringify platformVersions}
                      abiVersions = ${tomlStringify abiVersions}
                      ndkVersions = ${tomlStringify ndkVersions}
                      cmakeVersions = ${tomlStringify cmakeVersions}
                      emulatorVersion = "${emulatorVersion}"
                      includeNDK = ${pkgs.lib.boolToString includeNDK}
                      includeEmulator = ${pkgs.lib.boolToString includeEmulator}
                      includeSources = ${pkgs.lib.boolToString includeSources}
                      includeSystemImages = ${pkgs.lib.boolToString includeSystemImages}
                      useGoogleAPIs = ${pkgs.lib.boolToString useGoogleAPIs}
                      useGoogleTVAddOns = ${pkgs.lib.boolToString useGoogleTVAddOns}
                    '';
                };
                deps = ./web/deps.json;
              });

        mkPackageAndroid =
          let
            mavenRepo = androidEnv.packages."${system}".local-maven-repo;
            # Android2nix bug
            semver4jVersion = "0.16.4";
            semver4jnodeps = pkgs.fetchurl {
              url = "https://repo.maven.apache.org/maven2/com/github/gundy/semver4j/${semver4jVersion}/semver4j-${semver4jVersion}-nodeps.jar";
              sha256 = "sha256-P1nspRY3TM1P01UWJb9Q+KSxkfcAUI985IZkYKYSivA=";
            };
            # https://github.com/msfjarvis/custom-nixpkgs/blob/main/pkgs/bundletool-bin/default.nix
            bversion = "1.8.2";
            bundletool = pkgs.fetchzip rec {
              name = "bundletool-${bversion}";
              url = "https://github.com/google/bundletool/releases/download/${bversion}/bundletool-all-${bversion}.jar";
              sha256 = "1w7w60pn9fpmzbszvldm7wnlb4n2ipkgqlib90g83h4zwpjna5sf";

              postFetch = ''
                mkdir -p $out/bin
                printf "#!/bin/sh\n\nexec java \$JAVA_OPTS -jar \$0 \"\$@\"\n" > $out/bin/bundletool
                cat $downloadedFile >> $out/bin/bundletool
                chmod +x $out/bin/bundletool
              '';
            };
          in
          pkgs.mkYarnPackage {
            inherit version;
            name = "${name}-android";
            dontFixup = true;
            src = ./web;
            extraBuildInputs = [ pkgs.nodePackages.cordova jdk pkgs.gradle ];
            distPhase = "true";
            CORDOVA_ANDROID_GRADLE_DISTRIBUTION_URL = "file://" + pkgs.gradle.src;
            ANDROID_SDK_ROOT="${androidComposition.androidsdk}/libexec/android-sdk";
            GRADLE_OPTS="-XX:+TieredCompilation -XX:TieredStopAtLevel=1";
            buildPhase = ''
              export HOME="$(mktemp -d)"
              mkdir -p $out
              cd deps/${packageName}
              mkdir -p ./www/js
              cp -rs ${bundle}/. ./www
              ${pkgs.nodePackages.json}/bin/json -I -f package.json -e 'this.version = "${version}"'
              cordova telemetry off

              mkdir .m2
              cp -rs ${mavenRepo}/. .m2
              chmod -R +rw .m2

              cp -s ${semver4jnodeps} .m2/com/github/gundy/semver4j/${semver4jVersion}/semver4j-${semver4jVersion}-nodeps.jar
             
              cordova prepare android

              # export JAVA_OPTS=$(${pkgs.pcre}/bin/pcregrep -o1 'org.gradle.jvmargs=(.+)' platforms/android/gradle.properties)
              # echo $JAVA_OPTS

              function patchGradle() {
                sed -i '/mavenCentral()/ s//mavenLocal()/g' $1
                sed -i '/google()/ s//mavenLocal()/g' $1
                sed -i '/jcenter()/ s//mavenLocal()/g' $1
              }

              patchGradle platforms/android/repositories.gradle
              patchGradle platforms/android/app/repositories.gradle
              patchGradle platforms/android/CordovaLib/repositories.gradle
              patchGradle platforms/android/CordovaLib/cordova.gradle

              SETTINGS_COPY="$(cat platforms/android/settings.gradle)"
              echo "
              pluginManagement {
                repositories {
                  mavenLocal()
                }
              }" > platforms/android/settings.gradle
              echo "$SETTINGS_COPY" >> platforms/android/settings.gradle

              cordova compile android --release --no-telemetry -- --gradleArg="--parallel" --gradleArg="--offline" --gradleArg="--stacktrace" --gradleArg="--console=plain" --gradleArg="-Dorg.gradle.daemon=false" --gradleArg="-Dmaven.repo.local=$PWD/.m2" --gradleArg="-Dorg.gradle.project.android.aapt2FromMavenOverride=${androidComposition.androidsdk}/libexec/android-sdk/build-tools/${builtins.elemAt buildToolsVersions 0}/aapt2"
            '';
            installPhase = ''
              cp -r platforms/android/app/build/outputs/bundle/release/*.aab $out
              ${bundletool}/bin/bundletool build-apks --mode=universal --bundle=$out/app-release.aab --output=app.apks --aapt2=${androidComposition.androidsdk}/libexec/android-sdk/build-tools/${builtins.elemAt buildToolsVersions 0}/aapt2
              ${pkgs.unzip}/bin/unzip -q app.apks -d $out
              mv $out/universal.apk $out/${name}-${version}.apk
              mv $out/*.aab $out/${name}-${version}.aab
              rm $out/toc.pb
            '';
          };


        mkPackageElectron = pkgsystem: (
          let
            tsystem = import nixpkgs { system = pkgsystem; };
            web-modules = pkgs.mkYarnModules {
                inherit version;
                pname = "${name}-web-modules";
                yarnLock = ./web/yarn.lock;
                packageJSON = ./web/package.json;
            };
            electronVersion = pkgs.electron.version;
            electronUrlStarter = "https://github.com/electron/electron/releases/download/v${electronVersion}/electron-v${electronVersion}-";
            webElect = variant: sha256: pkgs.fetchurl {
              inherit sha256;
              url = electronUrlStarter + "${variant}.zip";
            };
            winElect = arch: sha256: webElect "win32-${arch}" sha256;
            mapping = {
              "i686-windows" = {arch = "ia32"; os = "windows"; electronSrc = winElect "ia32" "sha256-X8BOH/oXbzDF7PPERRs+WGa0T9K2TsAI1GLxXQGu++0=";};
              "x86_64-windows" = {arch = "x64"; os = "windows"; electronSrc = winElect "x64" "sha256-/v94WEGuoypZq+S1enjkn241ghYZZU/iWZoP8bxeXoE=";};
              "aarch64-windows" = {arch = "arm64"; os = "windows"; electronSrc = winElect "arm64" "sha256-EdqJgd8JfBk8EEjsWHRS+CVYr2VoB3q0r7keCdwncVk=";};
              "aarch64-linux" = {arch = "arm64"; os = "linux"; electronSrc = tsystem.electron.src;};
              "x86_64-linux" = {arch = "x64"; os = "linux"; electronSrc = tsystem.electron.src;};
              "armv7l-linux" = {arch = "armv7l"; os = "linux"; electronSrc = webElect "linux-armv7l" "sha256-tWHATJ+oxRL0GOpcMvVSZzLhzNFQ7kgwoAkdD6G34xw=";};
              "i686-linux" = {arch = "ia32"; os = "linux"; electronSrc = tsystem.electron.src;};
              "x86_64-darwin" = {arch = "x64"; os = "mac"; electronSrc = tsystem.electron.src;};
              "aarch64-darwin" = {arch = "arm64"; os = "mac"; electronSrc = tsystem.electron.src;};
            };
            os = mapping."${pkgsystem}".os;
            arch = mapping."${pkgsystem}".arch;
            electronPackage = pkgs.stdenv.mkDerivation {
                name = "electron-${os}-${arch}";
                version = electronVersion;
                dontStrip = true;
                dontPatch = true;
                dontUnpack = true;
                dontInstall = true;
                dontFixup = true;
                dontConfigure = true;
                buildPhase = ''
                    mkdir -p $out
                    ${pkgs.unzip}/bin/unzip -q ${mapping."${pkgsystem}".electronSrc} -d $out
                '';
            };
            winResource = name: file: pkgs.stdenv.mkDerivation rec {
              inherit name;
              dontStrip = true;
              dontPatch = true;
              dontUnpack = true;
              dontInstall = true;
              details = builtins.match ".*getBinFromUrl\\(\"${name}\",\ \"([[:digit:].]+)\",\ \"([^\"]+).*"  (builtins.readFile file);
              version = "${name}-${builtins.elemAt details 0}";
              archive = pkgs.fetchurl {
                url = "https://github.com/electron-userland/electron-builder-binaries/releases/download/${version}/${version}.7z";
                sha512 = builtins.elemAt details 1;
              };
              buildPhase = ''mkdir -p $out; ${pkgs.p7zip}/bin/7z x ${archive} -o$out'';
            };
            nsis = winResource "nsis" "${web-modules}/node_modules/app-builder-lib/out/targets/nsis/nsisUtil.js";
            nsisResources = winResource "nsis-resources" "${web-modules}/node_modules/app-builder-lib/out/targets/nsis/NsisTarget.js";

            appImageVersion = pkgs.stdenv.mkDerivation {
              name = "electron-appimage-version";
              version = "0.0.0";
              dontStrip = true;
              dontPatch = true;
              dontUnpack = true;
              dontInstall = true;
              dontConfigure = true;
              buildPhase = ''
                  mkdir -p $out
                  strings ${web-modules}/node_modules/app-builder-bin/linux/x64/app-builder | ${pkgs.pcre}/bin/pcregrep -o1 'appimage-([\d\.]+)' | xargs echo -n > $out/version
                  strings ${web-modules}/node_modules/app-builder-bin/linux/x64/app-builder | ${pkgs.pcre}/bin/pcregrep -o1 'electron-build-service\)([A-Za-z0-9\/=\+]+?==)' | xargs echo -n > $out/sha512
              '';
            };

            appimage = pkgs.stdenv.mkDerivation rec {
              name = "electron-appimage";
              dontUnpack = true;
              dontInstall = true;
              version = (builtins.readFile "${appImageVersion}/version");
              archive = pkgs.fetchurl {
                url = "https://github.com/electron-userland/electron-builder-binaries/releases/download/appimage-${version}/appimage-${version}.7z";
                sha512 = (builtins.readFile "${appImageVersion}/sha512");
              };
              buildPhase = ''mkdir -p $out; ${pkgs.p7zip}/bin/7z x ${archive} -o$out'';
            };
            macCmds = if os != "mac" then "" else ''
              mkdir macElectron
              cp -r ${electronPackage}/. macElectron
              chmod -R +rw macElectron
              ${pkgs.nodePackages.json}/bin/json -I -f package.json -e 'this.build.electronDist = "macElectron"'
            '';
            linuxCmds = if os != "linux" then "" else ''
              mkdir -p $ELECTRON_BUILDER_CACHE/appimage
              cp -rs ${appimage} $ELECTRON_BUILDER_CACHE/appimage/appimage-${appimage.version}
              chmod -R +rw $ELECTRON_BUILDER_CACHE/appimage/appimage-${appimage.version}
              find $ELECTRON_BUILDER_CACHE/appimage -name "*mksquashfs*" -exec ln -fs ${pkgs.squashfsTools}/bin/mksquashfs {} \;
            '';
            windowsCmds = if os != "windows" then "" else ''
              mkdir -p $ELECTRON_BUILDER_CACHE/nsis
              cp -r ${nsis} $ELECTRON_BUILDER_CACHE/nsis/${nsis.version}
              cp -r ${nsisResources} $ELECTRON_BUILDER_CACHE/nsis/${nsisResources.version}
              chmod -R +rwx $ELECTRON_BUILDER_CACHE
              autoPatchelf $ELECTRON_BUILDER_CACHE
            '';
            in
            pkgs.mkYarnPackage {
              inherit version;
              name = "${name}-electron-${pkgsystem}";
              dontFixup = true;
              src = ./web;
              extraBuildInputs = [ pkgs.nodePackages.cordova pkgs.stdenv.cc.cc.lib pkgs.p7zip pkgs.autoPatchelfHook pkgs.zlib ];
              distPhase = "true";
              USE_SYSTEM_7ZA = "true";
              ELECTRON_BUILDER_OFFLINE = "true";
              ELECTRON_SKIP_BINARY_DOWNLOAD = "true";
              DEBUG="electron-builder";
              buildPhase = ''
                mkdir -p $out
                export HOME="$(mktemp -d)"
                export ELECTRON_BUILDER_CACHE="$(mktemp -d)"
                cd deps/${packageName}
                mkdir -p ./www/js
                cp -rs ${bundle}/. ./www
                ${pkgs.nodePackages.json}/bin/json -I -f package.json -e 'this.version = "${version}"'

                cordova telemetry off
                ${pkgs.nodePackages.json}/bin/json -I -f package.json -e 'this.build.electronVersion = "${electronVersion}"'
                ${pkgs.nodePackages.json}/bin/json -I -f package.json -e 'this.build.electronDist = "${electronPackage}"'
                ${macCmds}
                ${linuxCmds}
                ${windowsCmds}
                if [ "${os}" == "windows" ]; then var1="linux" var2="mac"; fi
                if [ "${os}" == "linux" ]; then var1="windows" var2="mac"; fi
                if [ "${os}" == "mac" ]; then var1="windows" var2="linux"; fi
                ${pkgs.nodePackages.json}/bin/json -I -f build.json -e "delete this.electron.$var1; delete this.electron.$var2"
                ${pkgs.nodePackages.json}/bin/json -I -f build.json -e 'this.electron.${os}.arch = ["${arch}"]'
                cordova prepare electron

                cat <<EOT >> platforms/electron/www/cdv-electron-main.js
                app.commandLine.appendSwitch('enable-features', "SharedArrayBuffer")
                EOT

                cordova compile electron --release --no-telemetry
              '';
              installPhase = ''
                mkdir -p $out/bin
                if [ "${os}" == "windows" ]; then
                  cp platforms/electron/build/*.exe $out/bin
                  cd $out/bin
                  mv $out/bin/*.exe $out/bin/${name}-${version}-${arch}.exe
                elif [ "${os}" == "linux" ]; then
                  cp platforms/electron/build/*.AppImage $out/bin
                  mv $out/bin/*.AppImage $out/bin/${name}-${version}-${arch}.AppImage
                elif [ "${os}" == "mac" ]; then
                  cp -r platforms/electron/build/mac*/${name}.app $out/bin/${name}-${version}-${arch}.app
                fi
              '';
            });
      tarDerivation = deriv: pkgs.stdenv.mkDerivation {
                        version = deriv.version;
                        name = deriv.name + "-tar";
                        dontStrip = true;
                        dontPatch = true;
                        dontFetch = true;
                        dontUnpack = true;
                        dontBuild = true;
                        dontConfigure = true;
                        dontFixup = true;
                        installPhase = ''
                          cd ${deriv}/bin
                          tar -cf $out *.app
                        '';
                      };
      in rec {
          devShells.default = pkgs.mkShell {
            inherit name;
            inherit version;
            doCheck = false;
            DOTNET_CLI_TELEMETRY_OPTOUT=1;
            CLR_OPENSSL_VERSION_OVERRIDE=1.1;
            DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1;
            DOTNET_CLI_HOME = "/tmp/dotnet_cli";
            DOTNET_ROOT = "${sdk}";
            ANDROID_SDK_ROOT="${androidComposition.androidsdk}/libexec/android-sdk";
            buildInputs = fsharp.nativeBuildInputs ++ packages.default.extraBuildInputs ++ [ pkgs.yarn fable pkgs.starship pkgs.inotifyTools nodejs pkgs.futhark ];
            shellHook = ''
              exec ${androidEnv.devShell."${system}"}
            '';
          };

          # Necessary for flake-compat
          devShell = devShells.default;


          packages.i686-windows = mkPackageElectron "i686-windows";
          packages.x86_64-windows = mkPackageElectron "x86_64-windows";
          packages.aarch64-windows = mkPackageElectron "aarch64-windows";
          packages.i686-linux = mkPackageElectron "i686-linux";
          packages.x86_64-linux = mkPackageElectron "x86_64-linux";
          packages.armv7l-linux = mkPackageElectron "armv7l-linux";
          packages.aarch64-linux = mkPackageElectron "aarch64-linux";
          packages.x86_64-darwin = mkPackageElectron "x86_64-darwin";
          packages.x86_64-darwin-tar = tarDerivation packages.x86_64-darwin;
          packages.aarch64-darwin = mkPackageElectron "aarch64-darwin";
          packages.aarch64-darwin-tar = tarDerivation packages.aarch64-darwin;
          packages.android = mkPackageAndroid;
          packages.default = packages."${system}";
          packages.bundle = bundle;
          packages.release = pkgs.stdenv.mkDerivation {
                              inherit version;
                              name = "${name}-release";
                              dontStrip = true;
                              dontPatch = true;
                              dontFetch = true;
                              dontUnpack = true;
                              dontBuild = true;
                              dontConfigure = true;
                              installPhase = ''
                                mkdir -p $out
                                cp -s ${packages.i686-windows}/bin/*.exe $out
                                cp -s ${packages.x86_64-windows}/bin/*.exe $out
                                cp -s ${packages.aarch64-windows}/bin/*.exe $out
                                cp -s ${packages.i686-linux}/bin/*.AppImage $out
                                cp -s ${packages.x86_64-linux}/bin/*.AppImage $out
                                cp -s ${packages.armv7l-linux}/bin/*.AppImage $out
                                cp -s ${packages.aarch64-linux}/bin/*.AppImage $out
                                cp -s ${packages.x86_64-darwin-tar} $out/${name}-${version}-x86_64-darwin.tar
                                cp -s ${packages.aarch64-darwin-tar} $out/${name}-${version}-aarch64-darwin.tar
                                cp -rs ${packages.android}/. $out
                              '';
                            };

          defaultPackage = packages.default;

          apps.i686-windows = {
            type = "app";
            program = "${packages.i686-windows}/bin/${name}-${version}-ia32.exe";
          };

          apps.x86_64-windows = {
            type = "app";
            program = "${packages.x86_64-windows}/bin/${name}-${version}-x64.exe";
          };

          apps.aarch64-windows = {
            type = "app";
            program = "${packages.aarch64-windows}/bin/${name}-${version}-arm64.exe";
          };

          apps.i686-linux = {
            type = "app";
            program = "${packages.i686-linux}/bin/${name}-${version}-ia32.AppImage";
          };

          apps.x86_64-linux = {
            type = "app";
            program = "${packages.x86_64-linux}/bin/${name}-${version}-x64.AppImage";
          };

          apps.aarch64-linux = {
            type = "app";
            program = "${packages.aarch64-linux}/bin/${name}-${version}-arm64.AppImage";
          };

          apps.x86_64-darwin = {
            type = "app";
            program = "${packages.x86_64-darwin}/bin/${name}-${version}-x64.app/Contents/MacOS/${name}";
          };

          apps.aarch64-darwin = {
            type = "app";
            program = "${packages.aarch64-darwin}/bin/${name}-${version}-arm64.app/Contents/MacOS/${name}";
          };
          
          defaultApp = apps."${system}";
      }
    );
}
