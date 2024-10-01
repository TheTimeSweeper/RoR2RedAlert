﻿using RA2Mod.Modules;

namespace RA2Mod.Survivors.Chrono
{
    public static class ChronoConfig
    {
        //public static ConfigEntry<float> debug_Bomb_Pitch;
        public static ConfigEntry<float> debug_percentTimeUntilActionable;

        public static ConfigEntry<float> M0_SprintTeleport_JumpMultiplier;

        public static ConfigEntry<bool> M0_SprintTeleport_Scepter;

        public static ConfigEntry<bool> M0_SprintTeleport_OnRelease;

        public static ConfigEntry<float> M0_SprintTeleport_ProjectionSpeed;
        public static ConfigEntry<float> M0_SprintTeleport_DistTimeMulti;
        public static ConfigEntry<float> M0_SprintTeleport_TimeTimeMulti;

        public static ConfigEntry<float> M1_Shoot_Damage;
        public static ConfigEntry<float> M1_Shoot_Duration;
        public static ConfigEntry<float> M1_Shoot_Radius;
        public static ConfigEntry<float> M1Screenshake;

        public static ConfigEntry<float> M2_Bomb_Damage;

        public static ConfigEntry<float> M3_Chronosphere_Radius;
        public static ConfigEntry<float> M3_Chronosphere_Delay;
        public static ConfigEntry<float> M3ChronosphereCameraLerpTime;

        public static ConfigEntry<float> M3_Freezosphere_Radius;
        public static ConfigEntry<float> M3_Freezosphere_FreezeDuration;
        public static ConfigEntry<float> M3_Freezosphere_CastDuration;

        public static ConfigEntry<float> M4_Deconstructing_TickInterval;
        public static ConfigEntry<float> M4_Deconstructing_TickDamage;
        public static ConfigEntry<float> M4_Deconstructing_Duration;
        public static ConfigEntry<float> M4_Deconstructing_ChronoStacksRequired;
        public static ConfigEntry<float> M4_Deconstructing_Range;
        public const string ConfigVersion = " 0.0";
        public const string SectionSkills = "1-3. Chrono Skills" + ConfigVersion;
        public const string SectionBody = "1-3. Chrono Body" + ConfigVersion;

        public static void Init()
        {
            //debug_Bomb_Pitch = Config.BindAndOptionsSlider(
            //    SectionSkills,
            //    nameof(debug_Bomb_Pitch),
            //    -10f,
            //    -100f,
            //    100f,
            //    "");

            debug_percentTimeUntilActionable = Config.BindAndOptionsSlider(
                SectionSkills,
                nameof(debug_percentTimeUntilActionable),
                1f,
                0,
                1,
                "when disabled from sprint teleport, 1 means you are never actionable. 0.5 means you are actionable halfway through the sprint disable. 0 means you are always actionable" +
                "if you lower this, increase DistTimeMulti");

            M0_SprintTeleport_Scepter = Config.BindAndOptions(
                SectionSkills,
                "M0_SprintTeleport_Scepter",
                true,
                "adds ancient scepter upgrade to chrono's sprint teleport",
                true);

            M0_SprintTeleport_OnRelease = Config.BindAndOptions(
                SectionSkills,
                "M0_SprintTeleport_OnRelease",
                true,
                "Should sprinting teleport on release, or should it require a second press of sprint");

            M0_SprintTeleport_ProjectionSpeed = Config.BindAndOptionsSlider(
                SectionSkills,
                nameof(M0_SprintTeleport_ProjectionSpeed),
                9f,
                0,
                100,
                "speed multiplier for the projection sent out for teleporting to");

            M0_SprintTeleport_DistTimeMulti = Config.BindAndOptionsSlider(
                SectionSkills,
                "M0_SprintTeleport_DistTimeMulti",
                0.169f,
                0,
                1,
                "Phase out penalty multiplier based on distance teleported.");

            M0_SprintTeleport_TimeTimeMulti = Config.BindAndOptionsSlider(
                SectionSkills,
                "M0_SprintTeleport_TimeTimeMulti",
                0.5f,
                0,
                1,
                "Phase out penalty multiplier based on time spent in teleporting state. Only comes into play after 1 second, and only replaces distance penalty if larger (does not add)");
            //

            M0_SprintTeleport_JumpMultiplier = Config.BindAndOptionsSlider(
                SectionSkills,
                nameof(M0_SprintTeleport_JumpMultiplier),
                1.2f,
                0,
                100,
                "");

            M1_Shoot_Damage = Config.BindAndOptionsSlider(
                SectionSkills,
                "M1_Shoot_Damage",
                2f,
                0,
                10,
                "");

            M1_Shoot_Duration = Config.BindAndOptionsSlider(
                SectionSkills,
                "M1_Shoot_Duration",
                0.6f,
                0,
                10,
                "");
            M1_Shoot_Radius = Config.BindAndOptionsSlider(
                SectionSkills,
                "M1_Shoot_Radius",
                6f,
                0,
                100,
                "");

            M1Screenshake = Config.BindAndOptionsSlider(
                SectionSkills,
                "M1Screenshake",
                0.5f,
                0,
                10,
                "");
            //
            M2_Bomb_Damage = Config.BindAndOptionsSlider(
                SectionSkills,
                "M2_Bomb_Damage",
                5f,
                0,
                10,
                "");
            //
            M3_Chronosphere_Radius = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3_Chronosphere_Radius",
                20f,
                0,
                100,
                "");
            M3_Chronosphere_Delay = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3_Chronosphere_Delay",
                0.06f,
                0,
                1,
                "");
            M3ChronosphereCameraLerpTime = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3ChronosphereCameraLerpTime",
                0.5f,
                0,
                3,
                "");
            //
            M3_Freezosphere_Radius = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3_Freezosphere_Radius",
                30f,
                0,
                100,
                "projectile freeze radius requires restart");

            M3_Freezosphere_FreezeDuration = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3_Freezosphere_FreezeDuration",
                5f,
                0,
                20,
                "visuals require restart");

            M3_Freezosphere_CastDuration = Config.BindAndOptionsSlider(
                SectionSkills,
                "M3_Freezosphere_CastDuration",
                0.6f,
                0,
                20,
                "");

            //
            M4_Deconstructing_TickInterval = Config.BindAndOptionsSlider(
                SectionSkills,
                "M4_Deconstructing_TickInterval",
                0.3f,
                0,
                1,
                "");

            M4_Deconstructing_Duration = Config.BindAndOptionsSlider(
                SectionSkills,
                "M4_Deconstructing_Duration",
                1f,
                0,
                10,
                "");

            M4_Deconstructing_TickDamage = Config.BindAndOptionsSlider(
                SectionSkills,
                "M4_Deconstructing_TickDamage",
                0.8f,
                0,
                10,
                "");

            M4_Deconstructing_ChronoStacksRequired = Config.BindAndOptionsSlider(
                SectionSkills,
                nameof(M4_Deconstructing_ChronoStacksRequired),
                100f,
                0,
                200,
                "");

            M4_Deconstructing_Range = Config.BindAndOptionsSlider(
                SectionSkills,
                nameof(M4_Deconstructing_Range),
                40f,
                0,
                200,
                "");

        }
    }
}
