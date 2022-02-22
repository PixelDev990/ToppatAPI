using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using ToppatAPI.DB;
using Reactor;

namespace ToppatAPI
{
    [BepInPlugin(ID, "ToppatAPI", VERSION)]
    [BepInProcess("Among Us.exe")]
    public class MainHarmony : BasePlugin
    {
        public const string VERSION = "0.3.3";
        public const string ID = "com.DigiWorm.ToppatAPI";

        public HarmonyLib.Harmony Harmony { get; } = new HarmonyLib.Harmony(ID);

        public static ConfigFile ConfigFile { get; private set; }
        
        public override void Load()
        {
            ConfigFile = Config;
            LILogger.Init();
            VersionCheck.CheckVersion();
            VersionCheck.CheckNewtonsoft();
            AssetDB.Init();
            Harmony.PatchAll();
            LILogger.LogMsg("ToppatAPI Initialized.");
        }
    }
}
