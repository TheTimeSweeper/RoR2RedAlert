using System;
using RA2Mod.Modules;
using RA2Mod.Survivors.Chrono.Achievements;

namespace RA2Mod.Survivors.Chrono
{
    public static class ChronoTokens
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
            string prefix = ChronoSurvivor.TOKEN_PREFIX;

            string desc = "The Chrono Legionnaire uses manipulation of time to shake up the battlefield.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > I highly recommend setting sprint to alt or on your mouse if you can." + Environment.NewLine + Environment.NewLine
             + "< ! > I.V.A.N. bombs are great for area damage. Blink in, place one, and blink out." + Environment.NewLine + Environment.NewLine
             + "< ! > Chronosphere can be used for movement, for defense, or for grouping up enemies to better be exploded by bombs." + Environment.NewLine + Environment.NewLine
             + "< ! > While building up Chrono Sickness executes enemies with special, dealing damage is still important to get them to that threshold." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, without a trace.";
            string outroFailure = "..and so he vanished, as if he never existed.";

            Language.Add(prefix + "NAME", "Chrono Legionnaire");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "Never Existed");
            Language.Add(prefix + "LORE", "<style=cMono>//--  TRANSCRIPT OF OFFICER QUESTIONING  --//\r\n//-- SECURITY DIVISION OF UES [REDACTED] --//</style>\r\n\r\n\r\n''Thanks for coming in on such short notice. Very prompt, I like that. I'm Security Officer Koch, and no, you're not in trouble. It's nothing too serious, we've just got to clear up some confusion we were having up in management. Standard stuff, you know? Probably just some clerical errors. However, a cursory review of your files has turned up some... irregularities that need sorting out.''\r\n\r\n''Ah, yeah. That tends to happ-''\r\n\r\n''You might have gathered that we fast-tracked your admittance to the crew, based on the reputation of other agents sourced from your employer. The brass-...<i>We</i> wouldn't want to compromise such a valuable business relationship, but we do need to keep things tidy on our end.''\r\n\r\n''Oh yeah? Ask away. I'm an open book, except for the stuff I can't divulge. And, ah... Could I ask that we keep this brief? Lotta things to do, not a lotta time.''\r\n\r\n''Of course, this shouldn't take long at all. First question I have is about one of the operations credited to you in your files here. These items mention some names I've got questions about: 'Marinesko,' and a 'Romanov'...''\r\n\r\n''Man, I remember Chrono Storm like it was yesterday... Kinda jarring to blink halfway across the planet in an instant. Jetlag can <i>not</i> compare. Least I made a lotta new war buddies during the whole thing. Some even made it back home!''\r\n\r\nOh, of course. That matches the records in your file... However, outside of that, we can find no such evidence of the operation. No Marinesko shows up in our military personnel databases, nor does a Romanov. I <i>highly</i> doubt any of <i>them</i> would have still been around.''\r\n\r\n''Ah yeah, that's the thing...''\r\n\r\n''The same stands true for every single item mentioned in your reports. Operations that never happened, wars that never occurred, people that have never existed. Not a single one can be verified in our databases. I can arrive at no other conclusion than that they are falsified. So, who are you, really? What kind of work have you <i>actually</i> done?!''\r\n\r\n''I've done all of it. Everything you're reading in your reports there is true.''\r\n\r\n''Pardon me?''\r\n\r\n''I took part in every single operation and dealt with every single man named in those reports. See, the tech we used back then works in a funny way. That stuff was all real history, y'see. Just... not anymore.''\r\n\r\n''The hell is that supposed to mean? If technology like that existed, we'd know about it. You're giving me no reason to believe your sole account over our records. We will have plenty of questions as to your actual identity and operational experience, but it's just going to have to be dealt with... later.''\r\n\r\n''Yer kiddin' me. Just letting me walk free after all that?''\r\n\r\n''Need I remind you that you are currently aboard <i>our</i> ship? Consider yourself lucky that... <i>we</i> would rather not sour relations with your employer so easily, but know that I will be keeping a <i>very</i> close eye on you. In time, we will find out who you really are. We are very good at uncovering these things, and I do not expect that you would like my methods.''\r\n\r\n''Hey, now... You don't have to believe me, just gimme some time to prove myself. Maybe you'll figure out that you might can trust me.''\r\n\r\n''That will be all for now. Dismissed.''\r\n\r\n\r\n<style=cMono>//-- Transcriptions complete. --//</style>\r\n\r\n<style=cStack>NOTES: There appears to be a mistake on the record here. We've never had a Koch on our security staff, let alone as an officer. Someone run a list of all names on staff, maybe it was a transcription error?</style>");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_SPRINT_NAME", "Already There");
            Language.Add(prefix + "PASSIVE_SPRINT_DESCRIPTION", $"Instead of sprinting, you time-skip from place to place, after which, you are {Tokens.UtilityText("disabled")} for a short time based on distance.");
            #endregion


            #region Primary
            Language.Add(prefix + "PRIMARY_SHOOT_NAME", "Chrono Gun");
            Language.Add(prefix + "PRIMARY_SHOOT_DESCRIPTION", $"Fire a time-stopping rifle for {Tokens.DamageValueText(ChronoConfig.M1_Shoot_Damage.Value)}. Enemies hit are applied {Tokens.UtilityText("Chrono Sickness")}.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_BOMB_NAME", "Chrono I.V.A.N.");
            Language.Add(prefix + "SECONDARY_BOMB_DESCRIPTION", $"Attach a pulse bomb to an enemy. After 3 seconds, the bomb explodes for {Tokens.DamageValueText(ChronoConfig.M2_Bomb_Damage.Value)}.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_CHRONOSPHERE_NAME", "Chronosphere");
            Language.Add(prefix + "UTILITY_CHRONOSPHERE_DESCRIPTION", $"Highlight an area, then highlight a second area. {Tokens.UtilityText("All units")} in the first area are teleported to the second area.");
            
            Language.Add(prefix + "UTILITY_FREEZOSPHERE_NAME", "Suspend Sphere");
            Language.Add(prefix + "UTILITY_FREEZOSPHERE_DESCRIPTION", $"{Tokens.UtilityText("Stop time")} for enemies and projectiles for {Tokens.UtilityText($"{ChronoConfig.M3_Freezosphere_FreezeDuration.Value} seconds")}.");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_VANISH_NAME", "Deconstructing");
            int ticks = UnityEngine.Mathf.RoundToInt(ChronoConfig.M4_Deconstructing_Duration.Value / ChronoConfig.M4_Deconstructing_TickInterval.Value);
            Language.Add(prefix + "SPECIAL_VANISH_DESCRIPTION", $"Deal {Tokens.DamageValueText(ChronoConfig.M4_Deconstructing_TickDamage.Value * ticks)} and apply {Tokens.UtilityText("Chrono Sickness")} over {ChronoConfig.M4_Deconstructing_Duration.Value} seconds. If an enemy’s health is below the {Tokens.UtilityText("Chrono Sickness")} threshold, they vanish from existence.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(ChronoMasteryAchievement.identifier), "Chrono Legionnaire: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(ChronoMasteryAchievement.identifier), "As Chrono Legionnaire, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
