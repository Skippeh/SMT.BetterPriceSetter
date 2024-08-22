using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace BetterPriceSetter.Patches;

[HarmonyPatch(typeof(PlayerNetwork), "PriceSetFromNumpad")]
public class SetPricePatch
{
    // ReSharper disable once InconsistentNaming
    private static void Postfix(PlayerNetwork __instance, ref int productID)
    {
        if (Input.GetMouseButtonDown(2)) // If middle mouse button was just pressed
        {
            float marketPrice = ProductUtility.GetMarketPrice(productID);
            float price = marketPrice * Plugin.Config.MarketPriceMultiplier.Value;
            
            ProductUtility.SetPrice(productID, price);

            if (AccessTools.Field(typeof(PlayerNetwork), "pPrice") is { } pPriceField)
            {
                pPriceField.SetValue(__instance, price);
            }
            else
            {
                Plugin.Logger.LogWarning("Could not find PlayerNetwork.pPrice field");
            }

            if (AccessTools.Field(typeof(PlayerNetwork), "yourPriceTMP").GetValue(__instance) is TextMeshProUGUI textMesh)
            {
                textMesh.text = ProductListing.Instance.ConvertFloatToTextPrice(price);
            }
            else
            {
                Plugin.Logger.LogWarning("Could not find PlayerNetwork.yourPriceTMP field");
            }
            
            __instance.CmdPlayPricingSound();
        }
    }
}