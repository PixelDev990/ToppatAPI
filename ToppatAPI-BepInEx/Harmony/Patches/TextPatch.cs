using HarmonyLib;
using ToppatAPI.Map;
using ToppatAPI.MinimapGen;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ToppatAPI.Harmony.Patches
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString), typeof(SystemTypes))]
    public static class TextPatch
    {
        public static bool Prefix([HarmonyArgument(0)] SystemTypes systemType, ref string __result)
        {
            if (TextHandler.Contains(systemType))
            {
                __result = TextHandler.Get(systemType);
                return false;
            }
            return true;
        }
    }
}
