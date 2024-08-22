using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BetterPriceSetter;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("Supermarket Together.exe")]
public class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger = null!;
    internal static PluginConfig PluginConfig = null!;

    private static Harmony harmony = null!;
    
    private void Awake()
    {
        Logger = base.Logger;
        PluginConfig = LoadConfig();
        harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
        
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void OnDestroy()
    {
        harmony.UnpatchSelf();
    }

    private PluginConfig LoadConfig()
    {
        var marketPriceMultiplier = Config.Bind(
            "General",
            "MarketPriceMultiplier",
            2.0f,
            "The multiplier used to set the price of products relative to the current market price.."
        );
        marketPriceMultiplier.Value = Mathf.Clamp(marketPriceMultiplier.Value, 0f, float.MaxValue);

        return new PluginConfig(marketPriceMultiplier);
    }
}
