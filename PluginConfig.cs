using BepInEx.Configuration;

namespace BetterPriceSetter;

public class PluginConfig(ConfigEntry<float> marketPriceMultiplier)
{
    public ConfigEntry<float> MarketPriceMultiplier { get; } = marketPriceMultiplier;
}