using System;
using System.Collections.Generic;
using PostTruckFix.Log;
using Harmony2 = HarmonyLib.Harmony;
using PostTruckFix.Harmony.Patches;

namespace PostTruckFix.Harmony
{
    public static class Patcher
    {
        public const string HarmonyId = "Necko.PostTruckFix";

        private static bool s_patched = false;
        private static int s_iHarmonyPatches = 0;

        public static int GetHarmonyPatchCount()
        {
            return s_iHarmonyPatches;
        }

        public static void PatchAll()
        {
            if (!s_patched)
            {
                UnityEngine.Debug.Log(PostTruckFixMain.ModName + ": Patching...");

                s_patched = true;

                var harmony = new Harmony2(HarmonyId);

                List<Type> patchList = new List<Type>();

                patchList.Add(typeof(PostVanAIIsHeavyVehiclePatch));


                s_iHarmonyPatches = patchList.Count;

                string sMessage = "Patching the following functions:\r\n";

                foreach (var patchType in patchList)
                {
                    sMessage += patchType.ToString() + "\r\n";
                    harmony.CreateClassProcessor(patchType).Patch();
                }

                Debug.Log(sMessage);
            }
        }

        public static void UnpatchAll()
        {
            if (s_patched)
            {
                var harmony = new Harmony2(HarmonyId);

                harmony.UnpatchAll(HarmonyId);
                s_patched = false;

                UnityEngine.Debug.Log(PostTruckFixMain.ModName + ": Unpatching...");
            }
        }

        public static int GetPatchCount()
        {
            var harmony = new Harmony2(HarmonyId);
            var methods = harmony.GetPatchedMethods();

            int i = 0;
            foreach (var method in methods)
            {
                var info = Harmony2.GetPatchInfo(method);

                if (info.Owners?.Contains(harmony.Id) == true)
                {
                    i++;
                }
            }

            return i;
        }
    }
}
