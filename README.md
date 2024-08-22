# Better Price Setter
> A BepInEx plugin for Supermarket Together that makes setting prices faster and easier.

## How to use
While holding the price setter in your hands, press the middle mouse button to update the price according to the MarketPriceMultiplier setting.

By default the setting is set to double the market price. It can be changed by editing the BepInEx config file for this mod (game restart required).

## How to install
1. If you don't have BepInEx installed already [download BepInEx](https://github.com/BepInEx/BepInEx/releases) and extract it to the game folder.
2. Download the mod from the [releases page](https://github.com/Skippeh/SMT.BetterPriceSetter/releases) and extract it to the `BepInEx/plugins` folder. Create the folder if it doesn't exist.

## How to build
1. Copy `DevVars.targets.example` to `DevVars.targets` and change the `PluginFolder` to your game's plugin folder. This copies the dll to the game's plugin folder after a successful build.
2. Build the project normally, should Just Work™.
