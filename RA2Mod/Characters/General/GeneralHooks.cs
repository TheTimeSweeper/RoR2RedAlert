using RA2Mod.General.Components;
using RoR2;
using RoR2.ContentManagement;
using RoR2.Skills;
using System;
using System.Collections;

namespace RA2Mod.General
{
    public static class GeneralHooks
    {
        public static void Init()
        {
            On.RoR2.ModelSkinController.ApplySkinAsync += ModelSkinController_ApplySkin;
        }

        private static IEnumerator ModelSkinController_ApplySkin(On.RoR2.ModelSkinController.orig_ApplySkinAsync orig, ModelSkinController self, int skinIndex, AsyncReferenceHandleUnloadType unloadType)
        {
            yield return orig(self, skinIndex, unloadType);
            
            SkinRecolorController skinRecolorController = self.GetComponent<SkinRecolorController>();
            if (skinRecolorController)
            {
                SkillDef color = self.characterModel.body?.skillLocator?.FindSkill("LOADOUT_SKILL_COLOR")?.skillDef;
                if (color)
                    skinRecolorController.SetRecolor(color.skillName.ToLowerInvariant());
            }
        }
    }
}
