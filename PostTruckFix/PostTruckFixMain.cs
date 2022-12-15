using ICities;

namespace PostTruckFix
{
    public class PostTruckFixMain : IUserMod
    {
        private static string Version = "v1.0.0";

        public static string ModName => "PostTruckFix " + Version;
        public static string Title => "PostTruckFix " + " " + Version;

        public static bool IsEnabled = false;

        public string Name
        {
            get { return ModName; }
        }

        public string Description
        {
            get { return "Quick Fix for PostTruck HeavyTraffic Ban"; }
        }

        public void OnEnabled()
        {
            IsEnabled = true;
        }

        public void OnDisabled()
        {
            IsEnabled = false;
        }
    }
}