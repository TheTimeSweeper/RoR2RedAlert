using RA2Mod.Modules;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptConfig
    {
        public const string ConfigVersion = " 0.0";
        public const string SectionSkills = "1-5. Conscript Skills" + ConfigVersion;
        public const string SectionBody = "1-5. Conscript Body" + ConfigVersion;

        [Configure(SectionSkills, 2.0f, max = 20f)] 
        public static ConfigEntry<float> M1_Gun_Damage;
        [Configure(SectionSkills, 0.16f, max = 20f)]
        public static ConfigEntry<float> M1_Gun_Duration;
        [Configure(SectionSkills, 2f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_Reload;
        [Configure(SectionSkills, 0.3f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_FastReload_Unused;
        [Configure(SectionSkills, 100f, max = 500f)]
        public static ConfigEntry<float> M1_Gun_Range;

        [Configure(SectionSkills, 4.0f, max = 20f)]
        public static ConfigEntry<float> M1_Flak_Damage;
        [Configure(SectionSkills, 1.0f, max = 20f)]
        public static ConfigEntry<float> M1_Flak_Duration;
        [Configure(SectionSkills, 6.9f, max = 100f)]
        public static ConfigEntry<float> M1_Flak_Radius;
        [Configure(SectionSkills, 2f, max = 5f)]
        public static ConfigEntry<float> M1_Flak_Reload;

        [Configure(SectionSkills, 5f, max = 20f)]
        public static ConfigEntry<float> M2_Molotov_BaseDamage;

        [Configure(SectionSkills, 1f, max = 20f)]
        public static ConfigEntry<float> M2_TerrorDrone_JumpTim;
        [Configure(SectionSkills, 20f, max = 200f)]
        public static ConfigEntry<float> M2_TerrorDrone_LifeDuration;

        [Configure(SectionSkills, 2f, max = 10f)]
        public static ConfigEntry<float> M2_TerrorDrone_BlastDamage;
        [Configure(SectionSkills, 10f, max = 100f)]
        public static ConfigEntry<float> M2_TerrorDrone_BlastRadius;

        [Configure(SectionSkills, 3f, max = 20f)]
        public static ConfigEntry<float> M3_March_Duration;
        [Configure(SectionSkills, 0.3f, max = 20f)]
        public static ConfigEntry<float> M3_March_Windup;
        [Configure(SectionSkills, 4f, max = 20f)]
        public static ConfigEntry<float> M3_March_ChargeDamage;
        [Configure(SectionSkills, 2f, max = 10f)]
        public static ConfigEntry<float> M3_March_Speed;
        [Configure(SectionSkills, 200f, max = 500f)]
        public static ConfigEntry<float> M3_March_Armor;
        [Configure(SectionSkills, 5f, max = 20f)]
        public static ConfigEntry<float> M3_March_StompDamage;
        [Configure(SectionSkills, 10f, max = 100f)]
        public static ConfigEntry<float> M3_March_StompRadius;
        [Configure(SectionSkills, 13f, max = 100f)]
        public static ConfigEntry<float> M3_March_KnockUp;
        [Configure(SectionSkills, 1f, min = -100, max = 100f)]
        public static ConfigEntry<float> M3_March_TurnInfluence;
        [Configure(SectionSkills, 10f, max = 100f)]
        public static ConfigEntry<float> M3_March_Hop;
        [Configure(SectionSkills, 0.34f, min = -10, max = 10f)]
        public static ConfigEntry<float> M3_March_GravityUp;
        [Configure(SectionSkills, 10f, min = -20, max = 20f)]
        public static ConfigEntry<float> M3_March_GravityDown;

        [Configure(SectionSkills, 4f, max = 20f)]
        public static ConfigEntry<float> M3_NotMarch_Buff_Duration;

        [Configure(SectionSkills, 1f, max = 10f)]
        public static ConfigEntry<float> M4_Garrison_Regen;
        [Configure(SectionSkills, 6f, max = 20f, restartRequired = true)]
        public static ConfigEntry<float> M4_Garrison_Duration;
        [Configure(SectionSkills, 10f, max = 100f, restartRequired = true)]
        public static ConfigEntry<float> M4_Garrison_Range;

        public static void Init()
        {
            Config.DisableSection(SectionSkills);

            Config.InitConfigAttributes(typeof(ConscriptConfig));
        }
    }
}
