﻿using ToppatAPI.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToppatAPI.Map
{
    class MapApplicator
    {
        const string STEAM_GAME_DIR = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Among Us\\Among Us.exe";
        const string EPIC_GAME_DIR = "C:\\Program Files\\Epic Games\\AmongUs";

        public static void Revert()
        {
            // Game Directory
            string gameExeDir = STEAM_GAME_DIR;
            if (!File.Exists(gameExeDir))
                gameExeDir = EPIC_GAME_DIR;
            if (!File.Exists(gameExeDir))
            {
                Error("Among Us Not Found", "Either Among Us is not installed or it is in a different location than default.\nPlease find and select your Among Us.exe.");

                OpenFileDialog browseDialog = new OpenFileDialog();
                DialogResult result = browseDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    gameExeDir = browseDialog.FileName;
                    if (!File.Exists(browseDialog.FileName))
                    {
                        Error("Among Us Not Found", "Could not find Among Us installation.");
                        return;
                    }
                }
                else
                {
                    Error("Among Us Not Found", "Could not find Among Us installation.");
                    return;
                }
            }
            string installDir = Path.Combine(Path.GetDirectoryName(gameExeDir), "BepInEx\\plugins\\");
            string mapDir = Path.Combine(installDir, "map.json");
            string jsonDir = Path.Combine(installDir, "Newtonsoft.Json.dll");
            string liDir = Path.Combine(installDir, "ToppatAPI.dll");

            // Write Files
            try
            {
                // Map
                if (File.Exists(mapDir))
                    File.Delete(mapDir);

                // LI
                if (File.Exists(liDir))
                    File.Delete(liDir);

                // Json
                if (File.Exists(jsonDir))
                    File.Delete(jsonDir);

                MessageBox.Show("ToppatAPI has successfully been uninstalled!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                Error("Error", "There was an error writing to Among Us: \n" + e.Message);
            }
        }

        public static void Apply()
        {
            // Game Directory
            string gameExeDir = STEAM_GAME_DIR;
            if (!File.Exists(gameExeDir))
                gameExeDir = EPIC_GAME_DIR;
            if (!File.Exists(gameExeDir))
            {
                Error("Among Us Not Found", "Either Among Us is not installed or it is in a different location than default.\nPlease find and select your Among Us.exe.");

                OpenFileDialog browseDialog = new OpenFileDialog();
                DialogResult result = browseDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    gameExeDir = browseDialog.FileName;
                    if (!File.Exists(browseDialog.FileName))
                    {
                        Error("Among Us Not Found", "Could not find Among Us installation.");
                        return;
                    }
                }
                else
                {
                    Error("Among Us Not Found", "Could not find Among Us installation.");
                    return;
                }
            }
            string installDir = Path.Combine(Path.GetDirectoryName(gameExeDir), "BepInEx\\plugins\\");
            string mapDir = Path.Combine(installDir, "map.json");
            string jsonDir = Path.Combine(installDir, "Newtonsoft.Json.dll");
            string liDir = Path.Combine(installDir, "ToppatAPI.dll");

            // BepInEx
            // TODO Install BepInEx on the fly
            if (!Directory.Exists(installDir))
            {
                Error("BepInEx Not Installed", "BepInEx is required for ToppatAPI. \nBepInEx: https://docs.reactor.gg/docs/basic/install_bepinex");
                return;
            }

            // Map File
            if (!File.Exists(MapHandler.mapDir))
            {
                Error("Invalid Map", "Thats weird...the map file you have selected is gone!");
                return;
            }

            // Write Files
            try
            {
                // Map
                if (File.Exists(mapDir))
                    File.Delete(mapDir);
                File.Copy(MapHandler.mapDir, mapDir);
                
                // LI
                if (File.Exists(liDir))
                    File.Delete(liDir);
                File.WriteAllBytes(liDir, Resources.ToppatAPI);

                // Json
                if (!File.Exists(jsonDir))
                    File.WriteAllBytes(jsonDir, Resources.Newtonsoft);

                MessageBox.Show("Map has successfully been installed", "Success!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception e)
            {
                Error("Error", "There was an error writing to Among Us: \n" + e.Message);
            }
        }

        private static void Error(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
