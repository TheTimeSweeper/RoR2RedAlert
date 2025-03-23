using RA2Mod.Modules;

namespace RA2Mod.Survivors.Desolator
{
    public class DesolatorConfig
    {
        public const string ConfigVersion = " 0.0";
        public const string SectionSkills = "1-2. Desolator Skills" + ConfigVersion;
        public const string SectionBody = "1-2. Desolator Body" + ConfigVersion;

        [Configure(SectionSkills, -1, name = "Bubble VFX Limit", description = "Limit the Spread the Doom visual area indicators and lights that can be active.\n Agnostic to whoever created it. If there are more Desolators in your game, consider increasing this.\nGameplay and damage unchanged. -1 for infinite", min = -1, max = 100)]
        public static ConfigEntry<int> VisualsLimit;

        public static void Init()
        {
            Modules.Config.InitConfigAttributes(typeof(DesolatorConfig));
        }
    }
}