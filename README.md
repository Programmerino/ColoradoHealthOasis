# [ColoradoHealthOasis](https://coloradohealthoasis.0bit.dev)

Available on the browser, Android, and IOS (as a PWA).

## Stack
This project uses [Nix](https://nixos.org) for the development environment, [Fable (F# to JSON)](https://fable.io) for the client-side code (as opposed to the data generation code), [Elmish.React](https://elmish.github.io/react/) as the UI framework, and the Github Sites platform as the data storage/website host. It also uses [Cordova](https://cordova.apache.org/) for mobile app and desktop app generation (not currently supported), and [vite](https://vitejs.dev) for live, hot-module reloaded development and as the build tool.

## Data Sources

- [Professional and Occupational Licenses in Colorado](https://data.colorado.gov/Regulations/Professional-and-Occupational-Licenses-in-Colorado/7s5z-vewr) used for licensee names, zip code locations, and license types.
- [Census ACSDT5Y2020.B01003](https://data.census.gov/cedsci/table?q=Population%20Total&tid=ACSDT5Y2020.B01003&moe=true&tp=false) for zipcode-by-zipcode population estimates.
- [Census CitySDK-generated zipcode polygons](https://github.com/uscensusbureau/citysdk/tree/master/v2/GeoJSON) for mapping, and zipcode area information.

## Development

This project uses Nix for development, and `cachix use programmerino` can be used to speed up the initial compile, and for remote pipelines.

### Building

Use `nix develop -L` and `cd dev && build`