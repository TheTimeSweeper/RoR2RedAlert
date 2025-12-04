using System;
using RA2Mod.Modules;
using RA2Mod.Survivors.Conscript.Achievements;
using RA2Mod.Survivors.GI.Achievements;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptTokens
    {
        public static void Init()
        {
            AddHenryTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Henry.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddHenryTokens()
        {
            string prefix = ConscriptSurvivor.TOKEN_PREFIX;

            string desc = "ra2 quote.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > ra2 quote." + Environment.NewLine + Environment.NewLine
             + "< ! > ra2 quote." + Environment.NewLine + Environment.NewLine
             + "< ! > ra2 quote." + Environment.NewLine + Environment.NewLine
             + "< ! > ra2 quote." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, ra2 quote.";
            string outroFailure = "..and so he vanished, ra2 quote.";

            Language.Add(prefix + "NAME", "Conscript (Beta)");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "ra2 quote");
            Language.Add(prefix + "LORE", "ra2 quote");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            //#region Skins
            //Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            //#endregion

            //#region Passive
            //Language.Add(prefix + "PASSIVE_NAME", "Henry passive");
            //Language.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            //#endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_GUN_NAME", "Gun");
            Language.Add(prefix + "PRIMARY_GUN_DESCRIPTION", $"Fire gun for {Tokens.DamageValueText(ConscriptConfig.M1_Gun_Damage)}. Has to reload");

            Language.Add(prefix + "PRIMARY_FLAK_NAME", "Flak Cannon");
            Language.Add(prefix + "PRIMARY_FLAK_DESCRIPTION", $"Shoot an instant blast for {Tokens.DamageValueText(ConscriptConfig.M1_Flak_Damage)}. Has to reload");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_MOLOTOV_NAME", "Molotov");
            Language.Add(prefix + "SECONDARY_MOLOTOV_DESCRIPTION", $"Throw a molotov that leaves a pool of fire on the ground in a {Tokens.UtilityText("wide area")} for dealing {Tokens.DamageText("320% damage")} over 4 seconds. Can be shot mid-air to explode for {Tokens.DamageValueText(ConscriptConfig.M2_Molotov_BaseDamage)} in a {Tokens.UtilityText("smaller area")}.");


            Language.Add(prefix + "SECONDARY_TERROR_NAME", "Terror Drone");
            Language.Add(prefix + "SECONDARY_TERROR_DESCRIPTION", $"Throw a small drone that seeks and attaches to enemies. {Tokens.DamageText("Explodes when hit")} for {Tokens.DamageValueText(ConscriptConfig.M2_TerrorDrone_BlastDamage)}.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_MARCH_NAME", "Hell March");
            Language.Add(prefix + "UTILITY_MARCH_DESCRIPTION", $"Gain {Tokens.UtilityText("200 armor")}, and charge through enemies for {Tokens.DamageValueText(ConscriptConfig.M3_March_ChargeDamage)}, {Tokens.UtilityText("stunning them")} and {Tokens.UtilityText("knocking them up")}. Stomp at the end for {Tokens.DamageValueText(ConscriptConfig.M3_March_StompDamage)}. Repositions Garrisons");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_GARRISON_NAME", "Garrison");
            Language.Add(prefix + "SPECIAL_GARRISON_DESCRIPTION", $"Deploy a small garrison for {Tokens.UtilityText($"{ConscriptConfig.M4_Garrison_Duration.Value} seconds")} that {Tokens.UtilityText("removes the cooldown")} of primary and {Tokens.UtilityText("refreshes stocks")} of secondary. Provides cover from damage but {Tokens.HealthText("can be destroyed")}");
            

            
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(ConscriptMasteryAchievement.identifier), "Conscript : Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(ConscriptMasteryAchievement.identifier), "As Conscript, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
