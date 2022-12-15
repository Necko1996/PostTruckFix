using HarmonyLib;

namespace PostTruckFix.Harmony.Patches
{
    [HarmonyPatch(typeof(PostVanAI), "IsHeavyVehicle")]
    public static class PostVanAIIsHeavyVehiclePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = false;

            // Returning false, we skip vanilla function
            return false;
        }
    }
}
