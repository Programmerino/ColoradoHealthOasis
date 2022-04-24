import { defineConfig } from 'vite';
import crossOriginIsolation from 'vite-plugin-cross-origin-isolation';
import filterReplace from 'vite-plugin-filter-replace';

export default defineConfig({
    define: {
        "global": "globalThis",
    },
    base: '',
    cacheDir: ".vite",
    preserveSymlinks: true,
    server: {
        fs: {
            strict: false
        }
    },
    plugins: [
        crossOriginIsolation(),
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
        },
        exclude: ['/home/davis/Documents/Personal/CSProjects/ColoradoHealthOasis/dev/js/app.fut.worker.js'],
    },
});