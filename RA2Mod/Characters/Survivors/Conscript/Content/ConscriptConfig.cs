using RA2Mod.Modules;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptConfig
    {
        public const string ConfigVersion = " 0.0";
        public const string SectionSkills = "1-5. Conscript Skills" + ConfigVersion;
        public const string SectionBody = "1-5. Conscript Body" + ConfigVersion;
        public const string SectionDebug = "1-5. Conscript Debug" + ConfigVersion;

        [Configure(SectionDebug, -8.50f, min = -20f, max = 0f)]
        public static ConfigEntry<float> m2_Pitch;
        [Configure(SectionDebug, 0.3f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_FastReload_Unused;
        [Configure(SectionDebug, 100f, max = 500f)]
        public static ConfigEntry<float> M1_Gun_Range;

        [Configure(SectionDebug, 0.5f, max = 20f)]
        public static ConfigEntry<float> M2_TerrorDrone_JumpTim;
        [Configure(SectionDebug, 12f, max = 200f)]
        public static ConfigEntry<float> M2_TerrorDrone_LifeDuration;
        [Configure(SectionDebug, 10f, max = 100f)]
        public static ConfigEntry<float> M2_TerrorDrone_BlastRadius;

        [Configure(SectionDebug, 2f, max = 10f)]
        public static ConfigEntry<float> M3_March_Speed;
        [Configure(SectionDebug, 0.3f, max = 20f)]
        public static ConfigEntry<float> M3_March_Windup;
        [Configure(SectionDebug, 10f, max = 100f)]
        public static ConfigEntry<float> M3_March_StompRadius;
        [Configure(SectionDebug, 1f, min = -100, max = 100f)]
        public static ConfigEntry<float> M3_March_TurnInfluence;
        [Configure(SectionDebug, 10f, max = 100f)]
        public static ConfigEntry<float> M3_March_Hop;
        [Configure(SectionDebug, 0.34f, min = -10, max = 10f)]
        public static ConfigEntry<float> M3_March_GravityUp;
        [Configure(SectionDebug, 10f, min = -20, max = 20f)]
        public static ConfigEntry<float> M3_March_GravityDown;

        [Configure(SectionDebug, 4f, max = 20f)]
        public static ConfigEntry<float> M3_NotMarch_Buff_Duration;

        [Configure(SectionDebug, 0f, max = 10f)]
        public static ConfigEntry<float> M4_Garrison_Regen;
        [Configure(SectionDebug, 8f, max = 100f, restartRequired = true)]
        public static ConfigEntry<float> M4_Garrison_Range;

        [Configure(SectionDebug, 4f, max = 100f)]
        public static ConfigEntry<float> M4_Garrison_Health_Multiplier;

        //start
        [Configure(SectionSkills, 1.4f, max = 20f)] 
        public static ConfigEntry<float> M1_Gun_Damage;
        [Configure(SectionSkills, 0.12f, max = 20f)]
        public static ConfigEntry<float> M1_Gun_Duration;
        [Configure(SectionSkills, 2.2f, max = 5f)]
        public static ConfigEntry<float> M1_Gun_Reload;

        [Configure(SectionSkills, 5.0f, max = 20f)]
        public static ConfigEntry<float> M1_Flak_Damage;
        [Configure(SectionSkills, 0.8f, max = 20f)]
        public static ConfigEntry<float> M1_Flak_Duration;
        [Configure(SectionSkills, 6.9f, max = 100f)]
        public static ConfigEntry<float> M1_Flak_Radius;
        [Configure(SectionSkills, 2f, max = 5f)]
        public static ConfigEntry<float> M1_Flak_Reload;

        [Configure(SectionSkills, 5f, max = 20f)]
        public static ConfigEntry<float> M2_Molotov_BaseDamage;
        
        [Configure(SectionSkills, 2f, max = 10f)]
        public static ConfigEntry<float> M2_TerrorDrone_BlastDamage;

        [Configure(SectionSkills, 3f, max = 20f)]
        public static ConfigEntry<float> M3_March_Duration;
        [Configure(SectionSkills, 3.5f, max = 20f)]
        public static ConfigEntry<float> M3_March_ChargeDamage;
        [Configure(SectionSkills, 200f, max = 500f)]
        public static ConfigEntry<float> M3_March_Armor;
        [Configure(SectionSkills, 5f, max = 20f)]
        public static ConfigEntry<float> M3_March_StompDamage;
        [Configure(SectionSkills, 13f, max = 100f)]
        public static ConfigEntry<float> M3_March_KnockUp;

        [Configure(SectionSkills, 12f, max = 20f, restartRequired = true)]
        public static ConfigEntry<float> M4_Garrison_Duration;

        public static void Init()
        {
            Config.DisableSection(SectionDebug);

            Config.InitConfigAttributes(typeof(ConscriptConfig));
        }
    }
}
