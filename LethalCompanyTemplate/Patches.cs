using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MaxwellBoombox
{
    [HarmonyPatch]
    public static class Patches
    {
        /**
         * When the boombox starts, put Maxwell
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(BoomboxItem), nameof(BoomboxItem.Start))]
        public static void MakeMaxwell(BoomboxItem __instance)
        {
            //Disable the original renderer
            GameObject.Destroy(__instance.gameObject.GetComponent<MeshRenderer>());

            //Make maxwell on it
            GameObject maxwell = GameObject.Instantiate(MaxwellBoombox.maxwellObject, __instance.transform);
            maxwell.transform.localScale = new Vector3(45.3511f, 44.8757f, 70.3447f);
            maxwell.transform.localPosition = new Vector3(-8.5f, 0, 0);
            maxwell.transform.localEulerAngles = Vector3.zero;

            //Add the controller component
            __instance.gameObject.AddComponent<MaxwellManager>();
        }

        /**
         * When the boombox is toggled, toggle the animation
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(BoomboxItem), "StartMusic")]
        public static void OnBoomboxToggle(bool startMusic, BoomboxItem __instance)
        {
            __instance.gameObject.GetComponent<MaxwellManager>().Toggle(startMusic);
        }
    }
}
