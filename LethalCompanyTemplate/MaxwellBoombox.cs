using BepInEx;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace MaxwellBoombox
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class MaxwellBoombox : BaseUnityPlugin
    {
        public static GameObject maxwellObject = null;

        private void Awake()
        {
            //Load the base prefab of Maxwell
            LoadMaxwellBundle();

            //Make the patches
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            // Successfully started
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void LoadMaxwellBundle()
        {
            //Get the path to the bundle
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "Bundles", "maxwell");

            //Load the bundle
            AssetBundle maxwellBundle = AssetBundle.LoadFromFile(path);
            if(maxwellBundle == null)
            {
                Logger.LogInfo("Failed to load Maxwell bundle!");
                return;
            }

            //Load the GO
            maxwellObject = maxwellBundle.LoadAsset<GameObject>("Assets/Prefabs/maxwell.prefab");
            if (maxwellObject == null)
            {
                Logger.LogInfo("Failed to load Maxwell object!");
                return;
            }

            Logger.LogInfo("Loaded the Maxwell object!");
        }
    }
}