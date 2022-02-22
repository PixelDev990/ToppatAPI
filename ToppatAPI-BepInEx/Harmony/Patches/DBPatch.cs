using HarmonyLib;
using ToppatAPI.Map;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ToppatAPI.Harmony.Patches
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.Awake))]
    public static class DBPatch
    {
        public static void Postfix(AmongUsClient __instance)
        {
            LILogger.LogInfo("Loading Ship Prefabs...");
            foreach (AssetReference assetRef in __instance.ShipPrefabs)
            {
                assetRef.LoadAsset<GameObject>();
            }
            MapHandler.Load();
        }
    }
}
