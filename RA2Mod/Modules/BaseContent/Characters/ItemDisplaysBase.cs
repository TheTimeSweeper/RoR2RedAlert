using RoR2;
using System.Collections.Generic;

namespace RA2Mod.Modules.Characters
{
    public abstract class ItemDisplaysBase
    {
        public void SetItemDisplays(ItemDisplayRuleSet itemDisplayRuleSet)
        {
            ItemDisplays.SetItemDisplaysWhenReady(() =>
            {
                List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules = new List<ItemDisplayRuleSet.KeyAssetRuleGroup>();
                SetItemDisplayRules(itemDisplayRules);

                for (global::System.Int32 i = itemDisplayRules.Count - (1); i >= 0; i--)
                {
                    if (itemDisplayRules[i].keyAsset == null)
                    {
                        itemDisplayRules.RemoveAt(i);
                    }
                }
                itemDisplayRuleSet.keyAssetRuleGroups = itemDisplayRules.ToArray();
            });
        }

        protected abstract void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules);
    }
}
