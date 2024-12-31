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

            Language.Add(prefix + "NAME", "Conscript");
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
            Language.Add(prefix + "PRIMARY_GUN_DESCRIPTION", $"Fire gun. has to reload");

            //Language.Add(prefix + "PRIMARY_ROCKET_NAME", "Missile");
            //Language.Add(prefix + "PRIMARY_ROCKET_DESCRIPTION", $"Fire a rocket for {Tokens.DamageValueText(GIConfig.M1_Missile_Damage.Value)}.\nWhile deployed, {heavyMissile}");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_MOLOTOV_NAME", "Molotov");
            Language.Add(prefix + "SECONDARY_MOLOTOV_DESCRIPTION", $"Throw literally the molotov projectile from the equipment");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_MARCH_NAME", "Hell March");
            Language.Add(prefix + "UTILITY_MARCH_DESCRIPTION", $"Gain {Tokens.UtilityText("200 armor")}, and charge through enemies, {Tokens.UtilityText("stunning them")} and {Tokens.UtilityText("knocking them up")}. Stomp at the end");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_GARRISON_NAME", "Garrison");
            Language.Add(prefix + "SPECIAL_GARRISON_DESCRIPTION", $"Deploy a small garrison that {Tokens.UtilityText("removes the cooldown")} of primary and {Tokens.UtilityText("refreshes stocks")} of secondary. Also provides regeneration");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(ConscriptMasteryAchievement.identifier), "Conscript : Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(ConscriptMasteryAchievement.identifier), "As Conscript, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
