import { defineConfig } from 'vite';
import crossOriginIsolation from 'vite-plugin-cross-origin-isolation';
import filterReplace from 'vite-plugin-filter-replace';
import { VitePWA } from 'vite-plugin-pwa';

export default defineConfig({
    define: {
        "global": "globalThis",
    },
    base: '',
    cacheDir: ".vite",
    preserveSymlinks: true,
    server: {
        host: "0.0.0.0",
	fs: {
            strict: false
        }
    },
    plugins: [
        crossOriginIsolation(),
        VitePWA({
            includeAssets: ["favicon.svg", "favicon.ico", "robots.txt", "apple-touch-icon.png"],
            workbox: {
                maximumFileSizeToCacheInBytes: 10000000,
            },
            manifest: {
                name: "Colorado Health Oasis",
                short_name: "Colorado Health Oasis",
                start_url: "/",
                icons: [
                    {
                        src: "android-chrome-36x36.png",
                        sizes: "36x36",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-48x48.png",
                        sizes: "48x48",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-72x72.png",
                        sizes: "72x72",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-96x96.png",
                        sizes: "96x96",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-144x144.png",
                        sizes: "144x144",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-192x192.png",
                        sizes: "192x192",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-256x256.png",
                        sizes: "256x256",
                        type: "image/png"
                    },
                    {
                        src: "android-chrome-384x384.png",
                        sizes: "384x384",
                        type: "image/png"
                    }
                ],
                theme_color: "#ffffff",
                background_color: "#ffffff",
                display: "standalone"
            }
        }),
        filterReplace.default(
            [
                {
                    filter: /\.worker.js$/,
                    replace: {
                        from: "e.data.urlOrBlob?import(e.data.urlOrBlob):",
                        to: ""
                    }
                }
            ]
        )
    ],
    ssr: {
        noExternal: ["@mapbox/mapbox-gl-geocoder"]
    },
    optimizeDeps: {
        esbuildOptions: {
            define: {
                global: 'globalThis'
            },
        }
    },
});
