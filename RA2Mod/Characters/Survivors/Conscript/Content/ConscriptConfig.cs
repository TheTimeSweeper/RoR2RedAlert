using RA2Mod.Modules;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptConfig
    {
        public const string ConfigVersion = " 0.0";
        public const string SectionSkills = "1-5. Conscript Skills" + ConfigVersion;
        public const string SectionBody = "1-5. Conscript Body" + ConfigVersion;

        [Configure(SectionSkills, 3f, max = 20f)] 
        public static ConfigEntry<float> M1_Rifle_Damage;
        [Configure(SectionSkills, 0.3f, max = 20f)]
        public static ConfigEntry<float> M1_Rifle_Duration;
        [Configure(SectionSkills, 1.6f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_Reload;
        [Configure(SectionSkills, 0.3f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_FastReload;

        [Configure(SectionSkills, 3f, max = 20f)]
        public static ConfigEntry<float> M3_March_Duration;
        [Configure(SectionSkills, 0.5f, max = 20f)]
        public static ConfigEntry<float> M3_March_Windup;
        [Configure(SectionSkills, 3f, max = 20f)]
        public static ConfigEntry<float> M3_March_ChargeDamage;
        [Configure(SectionSkills, 2f, max = 10f)]
        public static ConfigEntry<float> M3_March_Speed;
        [Configure(SectionSkills, 3f, max = 20f)]
        public static ConfigEntry<float> M3_March_StompDamage;
        [Configure(SectionSkills, 20f, max = 100f)]
        public static ConfigEntry<float> M3_March_StompRadius;
        [Configure(SectionSkills, 10f, max = 100f)]
        public static ConfigEntry<float> M3_March_KnockUp;
        [Configure(SectionSkills, 1f, min = -100, max = 100f)]
        public static ConfigEntry<float> M3_March_TurnInfluence;
        [Configure(SectionSkills, 3f, max = 100f)]
        public static ConfigEntry<float> M3_March_Hop;
        [Configure(SectionSkills, 1f, min = -10, max = 10f)]
        public static ConfigEntry<float> M3_March_GravityUp;
        [Configure(SectionSkills, 2f, min = -10, max = 10f)]
        public static ConfigEntry<float> M3_March_GravityDown;

        [Configure(SectionSkills, 4f, max = 20f)]
        public static ConfigEntry<float> M3_Buff_Duration;

        public static void Init()
        {
            Config.DisableSection(SectionSkills);

            Config.InitConfigAttributes(typeof(ConscriptConfig));
        }
    }
}
