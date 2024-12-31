using HG;
using RoR2;
using RoR2.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class TerrorDroneTargetViewer : SniperTargetViewer
    {
        new private void Update()
        {
            List<HurtBox> list = CollectionPool<HurtBox, List<HurtBox>>.RentCollection();
            if (this.hud && this.hud.targetMaster)
            {
                TeamIndex teamIndex = this.hud.targetMaster.teamIndex;
                IReadOnlyList<HurtBox> readOnlySniperTargetsList = TerrorDroneHurtBox.readOnlyTerrorDroneHurtBoxList;
                int i = 0;
                int count = readOnlySniperTargetsList.Count;
                while (i < count)
                {
                    HurtBox hurtBox = readOnlySniperTargetsList[i];
                    if (hurtBox.healthComponent && hurtBox.healthComponent.alive && FriendlyFireManager.ShouldDirectHitProceed(hurtBox.healthComponent, teamIndex) && hurtBox.healthComponent.body != this.hud.targetMaster.GetBody())
                    {
                        list.Add(hurtBox);
                    }
                    i++;
                }
            }
            this.SetDisplayedTargets(list);
            list = CollectionPool<HurtBox, List<HurtBox>>.ReturnCollection(list);
        }
    }
}
