using RA2Mod.Modules;
using RA2Mod.Modules.Characters;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

/* for custom copy format in keb's helper
{childName},
                    {localPos}, 
                    {localAngles},
                    {localScale})
*/

namespace RA2Mod.Survivors.Chrono
{
    public class ChronoItemDisplays : ItemDisplaysBase
    {
        protected override void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules)
        {
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("AlienHead"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAlienHead"),
                    "Pelvis",
                    new Vector3(0.116F, 0.08009F, -0.20432F),
                    new Vector3(71.40205F, 321.5087F, 3.36629F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ArmorPlate"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                    "ThighR",
                    new Vector3(-0.04634F, 0.4971F, -0.13443F),
                    new Vector3(83.77988F, 180F, 180F),
                    new Vector3(0.30373F, 0.30373F, 0.30373F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ArmorReductionOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarhammer"),
                    "weapon_gripfront",
                    new Vector3(0.0064F, -0.4603F, -0.00013F),
                    new Vector3(89.19741F, 90.26239F, 198.7524F),
                    new Vector3(0.26182F, 0.24575F, 0.26182F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("AttackSpeedAndMoveSpeed"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCoffee"),
                    "Pelvis",
                    new Vector3(-0.05693F, -0.03478F, 0.26187F),
                    new Vector3(0F, 0F, 184.2968F),
                    new Vector3(0.2639F, 0.2639F, 0.2639F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("AttackSpeedOnCrit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                    "backpack_base",
                    new Vector3(-0.44171F, 0.25785F, 0.00634F),
                    new Vector3(0F, 274.1406F, 0F),
                    new Vector3(0.33846F, 0.33846F, 0.33846F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("AutoCastEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFossil"),
                    "Pelvis",
                    new Vector3(0.14079F, 0.10707F, 0.14872F),
                    new Vector3(300.7356F, 171.5991F, 168.6073F),
                    new Vector3(0.60748F, 0.60748F, 0.60748F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Bandolier"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBandolier"),
                    "Chest",
                    new Vector3(0.02596F, 0.01249F, 0.00807F),
                    new Vector3(327.3257F, 350.2057F, 287.7323F),
                    new Vector3(0.91298F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BarrierOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrooch"),
                    "Chest_Item",
                    new Vector3(-0.17752F, 0.06986F, -0.04827F),
                    new Vector3(80.09303F, 82.86595F, 101.3917F),
                    new Vector3(0.5754F, 0.5754F, 0.5754F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BarrierOnOverHeal"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAegis"),
                    "LowerArmR",
                    new Vector3(-0.02308F, 0.22321F, 0.16487F),
                    new Vector3(352.7374F, 76.00277F, 271.805F),
                    new Vector3(0.28351F, 0.28351F, 0.28351F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Bear"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBear"),
                    "backpack_base",
                    new Vector3(-0.33214F, -0.33418F, 0.1566F),
                    new Vector3(10.03311F, 278.4412F, 359.9647F),
                    new Vector3(0.32136F, 0.32136F, 0.317F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BearVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBearVoid"),
                    "backpack_base",
                    new Vector3(-0.33214F, -0.33418F, 0.1566F),
                    new Vector3(10.03311F, 278.4412F, 359.9647F),
                    new Vector3(0.32136F, 0.32136F, 0.317F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BeetleGland"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                    "Pelvis",
                    new Vector3(0.19942F, 0.06873F, 0.29803F),
                    new Vector3(7.18841F, 119.0995F, 356.3386F),
                    new Vector3(0.09067F, 0.09067F, 0.09067F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Behemoth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBehemoth"),
                    "weaponLens2",
                    new Vector3(-0.28625F, -0.03764F, -0.25799F),
                    new Vector3(0F, 225.3975F, 0F),
                    new Vector3(0.10125F, 0.10125F, 0.10125F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BleedOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTip"),
                    "weaponLens3",
                    new Vector3(0.00002F, -0.00003F, -0.18617F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.73578F, 0.73578F, 0.73578F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BleedOnHitVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTipVoid"),
                    "weaponLens3",
                    new Vector3(0.00002F, -0.00003F, -0.18617F),
                    new Vector3(270F, 170.8299F, 0F),
                    new Vector3(0.73578F, 0.73578F, 0.73578F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BleedOnHitAndExplode"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                    "weapon_base",
                    new Vector3(-0.00871F, 0.66698F, -0.30955F),
                    new Vector3(0F, 185.9906F, 0F),
                    new Vector3(0.11402F, 0.11402F, 0.11402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BonusGoldPackOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTome"),
                    "backpack_base",
                    new Vector3(-0.31398F, -0.03188F, 0.38987F),
                    new Vector3(0F, 290.6997F, 0F),
                    new Vector3(0.09011F, 0.09011F, 0.09011F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BoostAllStats"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrowthNectar"),
                    "backpack_base",
                    new Vector3(-0.32172F, 0.30398F, -0.19047F),
                    new Vector3(0F, 240.1703F, 0F),
                    new Vector3(2.48287F, 2.48287F, 2.48287F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BossDamageBonus"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAPRound"),
                    "UpperArmR",
                    new Vector3(-0.10858F, 0.15211F, 0.16529F),
                    new Vector3(74.80302F, 290.9568F, 352.3151F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BounceNearby"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHook"),
                    "backpack_base",
                    new Vector3(-0.15033F, 0.42169F, -0.00372F),
                    new Vector3(0F, 358.5722F, 0F),
                    new Vector3(0.59841F, 0.59841F, 0.59841F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ChainLightning"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkulele"),
                    "weapon_base",
                    new Vector3(-0.24836F, 0.57837F, -0.0086F),
                    new Vector3(0F, 277.7447F, 284.5695F),
                    new Vector3(0.64047F, 0.64047F, 0.64047F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ChainLightningVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkuleleVoid"),
                    "weapon_base",
                    new Vector3(-0.24836F, 0.57837F, -0.0086F),
                    new Vector3(0F, 277.7447F, 284.5695F),
                    new Vector3(0.64047F, 0.64047F, 0.64047F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Clover"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayClover"),
                    "Head",
                    new Vector3(-0.12325F, 0.28181F, -0.15532F),
                    new Vector3(286.8319F, 65.97968F, 342.6355F),
                    new Vector3(0.44747F, 0.44747F, 0.44747F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CloverVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCloverVoid"),
                    "Head",
                    new Vector3(-0.12325F, 0.28181F, -0.15532F),
                    new Vector3(286.8319F, 65.97968F, 342.6355F),
                    new Vector3(0.44747F, 0.44747F, 0.44747F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CooldownOnCrit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkull"),
                    "weapon_base",
                    new Vector3(-0.44689F, -0.06921F, -0.22833F),
                    new Vector3(0F, 0F, 272.9147F),
                    new Vector3(0.26049F, 0.26049F, 0.26049F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CritDamage"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserSight"),
                    "weaponLens2",
                    new Vector3(0.00005F, 0.00002F, 0.14001F),
                    new Vector3(0F, 270F, 270F),
                    new Vector3(0.11454F, 0.11454F, 0.11454F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CritGlasses"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlasses"),
                    "Head",
                    new Vector3(0.25792F, 0.17959F, 0.07896F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.35645F, 0.3887F, 0.38387F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CritGlassesVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlassesVoid"),
                    "Head",
                    new Vector3(0.25792F, 0.17959F, 0.07896F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.35645F, 0.3887F, 0.38387F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Crowbar"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCrowbar"),
                    "weapon_base",
                    new Vector3(-0.2627F, 0.98521F, -0.19948F),
                    new Vector3(36.24606F, 288.0356F, 298.8418F),
                    new Vector3(0.48691F, 0.48691F, 0.48691F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Dagger"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDagger"),
                    "UpperArmR",
                    new Vector3(-0.09978F, -0.17532F, 0.07187F),
                    new Vector3(9.13394F, 43.92914F, 127.8636F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("DeathMark"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathMark"),
                    "weapon_gripfront",
                    new Vector3(-0.19493F, 0.06741F, 0.0958F),
                    new Vector3(0F, 0F, 270F),
                    new Vector3(0.0683F, 0.0683F, 0.0683F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("DelayedDamage"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelayedDamage"),
                    "ThighL",
                    new Vector3(0.12451F, 0.25891F, -0.1361F),
                    new Vector3(0F, 141.5322F, 0F),
                    new Vector3(0.43604F, 0.43604F, 0.43604F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ElementalRingVoid"),//re
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVoidRing"),
                    "weaponLens1",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(270.6104F, 180F, 180F),
                    new Vector3(1.84075F, 1.84075F, 1.84075F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EnergizedOnEquipmentUse"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarHorn"),
                    "ThighR",
                    new Vector3(0.00449F, 0.19772F, -0.30572F),
                    new Vector3(8.0111F, 231.5167F, 143.45F),
                    new Vector3(0.44253F, 0.44253F, 0.44253F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EquipmentMagazine"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBattery"),
                    "backpack_base",
                    new Vector3(-0.27495F, 0.02307F, -0.42621F),
                    new Vector3(275.6131F, 319.1859F, 262.9353F),
                    new Vector3(0.22781F, 0.22781F, 0.22781F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EquipmentMagazineVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFuelCellVoid"),
                    "backpack_base",
                    new Vector3(-0.27495F, 0.02307F, -0.42621F),
                    new Vector3(275.6131F, 319.1859F, 262.9353F),
                    new Vector3(0.22781F, 0.22781F, 0.22781F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExecuteLowHealthElite"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGuillotine"),
                    "weapon_base",
                    new Vector3(-0.49295F, 0.21382F, -0.40428F),
                    new Vector3(52.9192F, 331.128F, 251.0603F),
                    new Vector3(0.24505F, 0.24505F, 0.24505F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExplodeOnDeath"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                    "ThighR",
                    new Vector3(0.0384F, 0.11189F, -0.18872F),
                    new Vector3(13.43903F, 180F, 208.1933F),
                    new Vector3(0.11248F, 0.11248F, 0.11248F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExplodeOnDeathVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWillowWispVoid"),
                    "ThighR",
                    new Vector3(0.0384F, 0.11189F, -0.18872F),
                    new Vector3(13.43903F, 180F, 208.1933F),
                    new Vector3(0.11248F, 0.11248F, 0.11248F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExtraLife"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippo"),
                    "backpack_base",
                    new Vector3(-0.32497F, -0.27166F, -0.1197F),
                    new Vector3(10.53585F, 262.2248F, 354.911F),
                    new Vector3(0.31292F, 0.31292F, 0.31292F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExtraLifeVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippoVoid"),
                    "backpack_base",
                    new Vector3(-0.32497F, -0.27166F, -0.1197F),
                    new Vector3(10.53585F, 262.2248F, 354.911F),
                    new Vector3(0.31292F, 0.31292F, 0.31292F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExtraShrineItem"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChanceDoll"),
                    "backpack_base",
                    new Vector3(-0.18938F, -0.34151F, 0.40997F),
                    new Vector3(344.1418F, 0F, 0F),
                    new Vector3(0.34055F, 0.34055F, 0.34055F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ExtraStatsOnLevelUp"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPrayerBeads"),
                    "HandR",
                    new Vector3(0.02309F, 0.22299F, 0.00022F),
                    new Vector3(354.394F, 286.6812F, 231.2865F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FallBoots"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "CalfL",
                    new Vector3(-0.00001F, 0.65305F, -0.00599F),
                    new Vector3(0.78281F, 258.9019F, 183.9842F),
                    new Vector3(0.3963854f, 0.3963854f, 0.3963854f)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "CalfR",
                    new Vector3(-0.00001F, 0.65305F, -0.00599F),
                    new Vector3(0.78281F, 258.9019F, 183.9842F),
                    new Vector3(0.3963854f, 0.3963854f, 0.3963854f)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Feather"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFeather"),
                    "UpperArmR",
                    new Vector3(-0.07725F, -0.12093F, 0.01172F),
                    new Vector3(5.00582F, 107.6738F, 95.24085F),
                    new Vector3(0.07188F, 0.07188F, 0.07188F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FireballsOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                    "weaponLens3",
                    new Vector3(-0.24861F, 0.17663F, 0.02842F),
                    new Vector3(270.9198F, 280.81F, 179.9998F),
                    new Vector3(0.11863F, 0.11863F, 0.11863F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FireRing"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireRing"),
                    "weaponLens2",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(90F, 0F, 0F),
                    new Vector3(1.75118F, 1.75118F, 1.75118F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Firework"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFirework"),
                    "ThighL",
                    new Vector3(-0.1421F, 0.13226F, -0.12369F),
                    new Vector3(63.2368F, 162.6651F, 147.9878F),
                    new Vector3(0.38658F, 0.38658F, 0.38658F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FlatHealth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                    "Chest",
                    new Vector3(-0.04441F, -0.29333F, 0.29171F),
                    new Vector3(57.66123F, 36.99063F, 224.2618F),
                    new Vector3(0.13459F, 0.13459F, 0.13459F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FocusConvergence"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                    "Root",
                    new Vector3(-0.90495F, 1.45269F, 0.12039F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.08071F, 0.08071F, 0.08071F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FragileDamageBonus"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelicateWatch"),
                    "HandR",
                    new Vector3(0.01625F, 0.11421F, 0.02479F),
                    new Vector3(295.1586F, 222.1801F, 308.4323F),
                    new Vector3(1.09026F, 1.09026F, 1.09026F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FreeChest"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShippingRequestForm"),
                    "ThighL",
                    new Vector3(-0.1095F, 0.3699F, -0.14966F),
                    new Vector3(349.7032F, 297.4547F, 87.54746F),
                    new Vector3(0.55498F, 0.55498F, 0.55498F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GhostOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMask"),
                    "Head",
                    new Vector3(0.19666F, 0.18409F, -0.06249F),
                    new Vector3(0F, 100.2211F, 0F),
                    new Vector3(0.81444F, 0.81444F, 0.81444F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GoldOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                    "Head",
                    new Vector3(-0.00962F, 0.23145F, 0.00126F),
                    new Vector3(0F, 96.54121F, 0F),
                    new Vector3(1.63498F, 1.42842F, 1.42842F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GoldOnHurt"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRollOfPennies"),
                    "ThighL",
                    new Vector3(0.07751F, 0.15306F, -0.14706F),
                    new Vector3(12.03281F, 147.4187F, 134.6788F),
                    new Vector3(0.97605F, 0.97605F, 0.97605F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GoldOnStageStart"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTreasuryDividends"),
                    "backpack_base",
                    new Vector3(-0.20451F, -0.54322F, 0.17727F),
                    new Vector3(23.10767F, 296.3819F, 3.0973F),
                    new Vector3(1.95414F, 1.95414F, 1.95414F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HalfAttackSpeedHalfCooldowns"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderNature"),
                    "UpperArmL",
                    new Vector3(-0.00607F, -0.01481F, 0.16823F),
                    new Vector3(359.6572F, 269.295F, 227.3063F),
                    new Vector3(0.96252F, 0.96252F, 0.96252F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HalfSpeedDoubleHealth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderStone"),
                    "UpperArmL",
                    new Vector3(-0.02573F, -0.18798F, 0.18772F),
                    new Vector3(351.5416F, 261.0686F, 173.8407F),
                    new Vector3(0.8415F, 0.8415F, 0.8415F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HeadHunter"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkullcrown"),
                    "Pelvis",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.05239F, 269.5999F, 187.459F),
                    new Vector3(0.99384F, 0.26374F, 0.23928F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HealOnCrit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScythe"),
                    "weapon_base",
                    new Vector3(-0.23413F, 0.88719F, 0.08587F),
                    new Vector3(326.2806F, 354.3849F, 280.0434F),
                    new Vector3(0.33987F, 0.33987F, 0.33987F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HealWhileSafe"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySnail"),
                    "UpperArmL",
                    new Vector3(-0.08442F, -0.01381F, 0.02486F),
                    new Vector3(349.19F, 202.216F, 282.7836F),
                    new Vector3(0.10465F, 0.10465F, 0.10465F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HealingPotion"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealingPotion"),
                    "Chest",
                    new Vector3(0.11321F, -0.07388F, -0.33753F),
                    new Vector3(56.1844F, 252.9852F, 356.5692F),
                    new Vector3(0.06003F, 0.06003F, 0.06003F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Hoof"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHoof"),
                    "CalfR",
                    new Vector3(-0.09803F, 0.47872F, 0.0435F),
                    new Vector3(75.68243F, 112.9173F, 7.01632F),
                    new Vector3(0.14222F, 0.14222F, 0.14268F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightCalf)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IceRing"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIceRing"),
                    "weaponLens1",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(270.6104F, 180F, 180F),
                    new Vector3(1.84075F, 1.84075F, 1.84075F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Icicle"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                    "Root",
                    new Vector3(0.78714F, 2.42446F, -0.78148F),
                    new Vector3(270.696F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IgniteOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasoline"),
                    "weapon_base",
                    new Vector3(-0.15523F, -0.55665F, -0.50736F),
                    new Vector3(23.16002F, 1.54233F, 180.421F),
                    new Vector3(0.77463F, 0.77463F, 0.77463F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ImmuneToDebuff"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRainCoatBelt"),
                    "CalfL",
                    new Vector3(-0.00506F, 0F, -0.00222F),
                    new Vector3(0F, 246.3079F, 177.3291F),
                    new Vector3(0.89749F, 0.89749F, 0.89749F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IncreaseDamageOnMultiKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreaseDamageOnMultiKill"),
                    "backpack_base",
                    new Vector3(-0.13101F, -0.16476F, -0.35714F),
                    new Vector3(89.26752F, 179.9996F, 171.5419F),
                    new Vector3(0.28009F, 0.28009F, 0.28009F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IncreaseHealing"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(0.02727F, 0.23716F, 0.15055F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.3912F, 0.3912F, 0.3912F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(0.00743F, 0.2539F, -0.15462F),
                    new Vector3(0F, 171.9527F, 0F),
                    new Vector3(0.3912F, 0.3912F, 0.3912F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IncreasePrimaryDamage"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreasePrimaryDamage"),
                    "weapon_base",
                    new Vector3(-0.24633F, 0.74334F, -0.01845F),
                    new Vector3(355.2237F, 267.1333F, 84.96774F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Incubator"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAncestralIncubator"),
                    "backpack_base",
                    new Vector3(-0.15013F, 0.33243F, -0.12158F),
                    new Vector3(332.1804F, 0F, 0F),
                    new Vector3(0.04353F, 0.04353F, 0.04353F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Infusion"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInfusion"),
                   "Stomach",
                    new Vector3(-0.16254F, -0.11878F, -0.1191F),
                    new Vector3(0F, 251.1181F, 0F),
                    new Vector3(0.50391F, 0.50391F, 0.50391F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("JumpBoost"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaxBird"),
                    "backpack_base",
                    new Vector3(-0.12784F, -0.28438F, 0.07832F),
                    new Vector3(0F, 178.6006F, 0F),
                    new Vector3(1.07346F, 1.07346F, 1.07346F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("KillEliteFrenzy"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                    "Head",
                    new Vector3(-0.01244F, 0.10703F, 0.01881F),
                    new Vector3(0F, 56.50036F, 0F),
                    new Vector3(0.4431F, 0.88457F, 0.37278F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("KnockBackHitEnemies"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnockbackFin"),
                    "Head",
                    new Vector3(0.02073F, 0.40807F, -0.00001F),
                    new Vector3(25.19357F, 90F, 0F),
                    new Vector3(0.80697F, 0.80697F, 0.80697F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Knurl"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnurl"),
                    "backpack_base",
                    new Vector3(-0.27016F, -0.31119F, 0.28465F),
                    new Vector3(311.6927F, 298.3708F, 235.214F),
                    new Vector3(0.07743F, 0.07743F, 0.07743F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LaserTurbine"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                    "backpack_base",
                    new Vector3(-0.18195F, 0.34636F, 0.24151F),
                    new Vector3(0.06946F, 269.2195F, 337.8656F),
                    new Vector3(0.35619F, 0.35619F, 0.35619F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LightningStrikeOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChargedPerforator"),
                    "weaponLens3",
                    new Vector3(0.18739F, 0.0701F, -0.01193F),
                    new Vector3(0.42801F, 106.334F, 183.7917F),
                    new Vector3(2.01675F, 2.01675F, 2.01675F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LowerHealthHigherDamage"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRageCrystal"),
                    "backpack_base",
                    new Vector3(-0.01322F, -0.53943F, -0.25355F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.7389F, 1.7389F, 1.7389F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LowerPricedChests"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLowerPricedChests"),
                    "Root",
                    new Vector3(1.09939F, 2.88111F, 0.53603F),
                    new Vector3(272.9224F, 180F, 180F),
                    new Vector3(0.59733F, 0.59733F, 0.59733F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarDagger"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarDagger"),
                    "weapon_base",
                    new Vector3(-0.53209F, -0.11986F, -0.40068F),
                    new Vector3(286.5413F, 333.6286F, 295.7045F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarPrimaryReplacement"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdEye"),
                   "Head",
                    new Vector3(0.26976F, 0.17505F, -0.00001F),
                    new Vector3(0F, 0F, 90.65562F),
                    new Vector3(0.30379F, 0.30379F, 0.30379F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarSecondaryReplacement"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdClaw"),
                    "LowerArmR",
                    new Vector3(-0.00517F, 0.03868F, 0.06415F),
                    new Vector3(0F, 90.26244F, 0F),
                    new Vector3(0.764F, 0.764F, 0.764F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarSpecialReplacement"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdHeart"),
                    "Root",
                    new Vector3(1.11752F, 1.82619F, -1.07527F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.38831F, 0.38831F, 0.38831F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarSun"),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Head",
                    new Vector3(0.02733F, -0.07127F, 0.01671F),
                    new Vector3(14.2767F, 160.5365F, 27.32745F),
                    new Vector3(1.70347F, 1.70347F, 1.70347F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(0.00001F, 0.15891F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.51016F, 1.51016F, 1.51016F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EmpowerAlways"),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Head",
                    new Vector3(0.02733F, -0.07127F, 0.01671F),
                    new Vector3(14.2767F, 160.5365F, 27.32745F),
                    new Vector3(1.70347F, 1.70347F, 1.70347F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(0.00001F, 0.15891F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.51016F, 1.51016F, 1.51016F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarTrinket"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeads"),
                    "HandL",
                    new Vector3(-0.01163F, 0.09947F, 0.0193F),
                    new Vector3(41.02614F, 344.4212F, 17.44033F),
                    new Vector3(1.53935F, 1.53935F, 1.53935F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarUtilityReplacement"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdFoot"),
                    "ThighR",
                    new Vector3(-0.13405F, 0.4199F, -0.21044F),
                    new Vector3(0F, 302.3421F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Medkit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMedkit"),
                    "ThighL",
                    new Vector3(0.13601F, 0.46066F, -0.07816F),
                    new Vector3(87.26749F, 66.39127F, 123.1098F),
                    new Vector3(0.79846F, 0.79846F, 0.79846F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MeteorAttackOnHighDamage"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteorAttackOnHighDamage"),
                    "weapon_base",
                    new Vector3(-0.59078F, 0.01955F, -0.06141F),
                    new Vector3(34.48789F, 359.8729F, 99.61075F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MinorConstructOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDefenseNucleus"),
                    "Root",
                    new Vector3(-1.04742F, 2.06439F, 0.59675F),
                    new Vector3(0F, 20.41998F, 0F),
                    new Vector3(0.29287F, 0.29287F, 0.29287F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Missile"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                    "weapon_base",
                    new Vector3(0.00003F, 1.09079F, 0.65703F),
                    new Vector3(270F, 180F, 0F),
                    new Vector3(0.1422F, 0.1422F, 0.1422F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MissileVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncherVoid"),
                    "weapon_base",
                    new Vector3(0.00003F, 1.09079F, 0.65703F),
                    new Vector3(270F, 180F, 0F),
                    new Vector3(0.1422F, 0.1422F, 0.1422F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MonstersOnShrineUse"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMonstersOnShrineUse"),
                    "CalfL",
                    new Vector3(-0.19393F, 0.24035F, -0.0228F),
                    new Vector3(46.04933F, 333.4655F, 0F),
                    new Vector3(0.15539F, 0.15539F, 0.15539F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MoreMissile"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayICBM"),
                    "weaponLens3",
                    new Vector3(0.00015F, 0.10143F, 0.16869F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.17849F, 0.17849F, 0.17849F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MoveSpeedOnKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrappleHook"),
                    "weapon_base",
                    new Vector3(0.00001F, -0.69346F, -0.47747F),
                    new Vector3(0.38471F, 270.559F, 325.4644F),
                    new Vector3(0.395F, 0.395F, 0.395F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Mushroom"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroom"),
                   "CalfR",
                    new Vector3(0.13204F, 0.21123F, -0.08481F),
                    new Vector3(282.7637F, 180F, 143.6206F),
                    new Vector3(0.13551F, 0.13551F, 0.13551F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MushroomVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroomVoid"),
                    "CalfR",
                    new Vector3(0.13204F, 0.21123F, -0.08481F),
                    new Vector3(282.7637F, 180F, 143.6206F),
                    new Vector3(0.13551F, 0.13551F, 0.13551F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("NearbyDamageBonus"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDiamond"),
                    "weaponLens3",
                    new Vector3(0.00003F, 0.07465F, 0.00494F),
                    new Vector3(273.8659F, 0F, 0F),
                    new Vector3(0.16147F, 0.16147F, 0.16147F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("NegateAttack"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntlerShieldLeft"),
                    "Head",
                    new Vector3(0.0748F, 0.1868F, -0.10258F),
                    new Vector3(20.35466F, 266.1595F, 0F),
                    new Vector3(0.65849F, 0.65849F, 0.65849F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntlerShieldRight"),
                    "Head",
                    new Vector3(0.09359F, 0.19496F, 0.09562F),
                    new Vector3(20.64244F, 276.2393F, 7.10999F),
                    new Vector3(0.65849F, 0.65849F, 0.65849F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("NovaOnHeal"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(0.01377F, 0.18245F, -0.13753F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.68985F, 0.68985F, 0.68985F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(0.01377F, 0.18245F, 0.13753F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(-0.68985F, 0.68985F, 0.68985F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("NovaOnLowHealth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                    "Head",
                    new Vector3(-0.14036F, 0.00837F, 0.09394F),
                    new Vector3(357.652F, 92.3745F, 349.733F),
                    new Vector3(0.20244F, 0.20244F, 0.20244F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("OnLevelUpFreeUnlock"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlockTablet"),
                    "Root",
                    new Vector3(-0.99994F, 2.14185F, -0.91967F),
                    new Vector3(359.7499F, 186.8571F, 351.1669F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlock"),
                    "Root",
                    new Vector3(-0.79934F, 2.33757F, -0.89954F),
                    new Vector3(6.32369F, 180F, 180F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("OutOfCombatArmor"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOddlyShapedOpal"),
                    "Chest_Item",
                    new Vector3(0.20764F, 0.06951F, -0.03091F),
                    new Vector3(359.9188F, 10.61001F, 348.7333F),
                    new Vector3(0.29251F, 0.29251F, 0.29251F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ParentEgg"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayParentEgg"),
                    "Stomach",
                    new Vector3(0.25154F, 0.01171F, -0.10223F),
                    new Vector3(344.0982F, 0F, 0F),
                    new Vector3(0.12509F, 0.12509F, 0.12509F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Pearl"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPearl"),
                    "backpack_spinner",
                    new Vector3(-0.24906F, -0.00005F, 0.00001F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.0881F, 0.0881F, 0.0881F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ShinyPearl"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                    "backpack_spinner",
                    new Vector3(-0.3326F, -0.0001F, 0.00002F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.0881F, 0.0881F, 0.0881F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("PermanentDebuffOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScorpion"),
                    "backpack_base",
                    new Vector3(-0.24813F, 0.35856F, 0.00002F),
                    new Vector3(71.27603F, 90F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("PersonalShield"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                    "Chest_Item",
                    new Vector3(-0.00004F, 0.10363F, -0.00385F),
                    new Vector3(270.1908F, 180F, 180F),
                    new Vector3(0.24829F, 0.24587F, 0.24587F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Phasing"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStealthkit"),
                    "Stomach",
                    new Vector3(0.00013F, -0.00301F, -0.3066F),
                    new Vector3(68.03385F, 180.0671F, 178.8082F),
                    new Vector3(0.44525F, 0.44525F, 0.44525F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Plant"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                    "weapon_base",
                    new Vector3(-0.19228F, 0.00001F, 0.31261F),
                    new Vector3(0F, 322.1406F, 0F),
                    new Vector3(0.12252F, 0.12252F, 0.12252F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("PrimarySkillShuriken"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShuriken"),
                    "weapon_base",
                    new Vector3(-0.43298F, -0.07983F, -0.26234F),
                    new Vector3(0F, 90F, 48.82911F),
                    new Vector3(1.79069F, 1.79069F, 1.26054F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("RandomDamageZone"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                    "backpack_base",
                    new Vector3(-0.15459F, 0.24245F, -0.38769F),
                    new Vector3(20.86894F, 359.1998F, 0F),
                    new Vector3(0.12089F, 0.12089F, 0.12089F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("RandomEquipmentTrigger"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBottledChaos"),
                   "backpack_base",
                    new Vector3(-0.14243F, -0.63684F, -0.1701F),
                    new Vector3(23.87501F, 271.027F, 19.18652F),
                    new Vector3(0.30081F, 0.30081F, 0.30081F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("RandomlyLunar"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDomino"),
                    "Root",
                    new Vector3(-1.11413F, 2.50588F, 0F),
                    new Vector3(63.03075F, 180F, 160.9146F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("RegeneratingScrap"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRegeneratingScrap"),
                    "backpack_base",
                    new Vector3(-0.07994F, -0.65455F, 0.27684F),
                    new Vector3(282.928F, 96.94169F, 359.2634F),
                    new Vector3(0.35333F, 0.37497F, 0.37497F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("RepeatHeal"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCorpseflower"),
                    "Chest_Item",
                    new Vector3(-0.11494F, 0.20266F, -0.03566F),
                    new Vector3(12.8754F, 268.1311F, 300.8477F),
                    new Vector3(0.36112F, 0.36112F, 0.36112F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ResetChests"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySonorousEcho"),
                    "Chest",
                    new Vector3(-0.01988F, -0.16375F, -0.35531F),
                    new Vector3(21.00062F, 133.2828F, 336.0586F),
                    new Vector3(1.1678F, 1.1678F, 1.1678F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SecondarySkillMagazine"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                    "weapon_base",
                    new Vector3(-0.04193F, 1.04671F, -0.45012F),
                    new Vector3(275.1106F, 134.4021F, 42.90421F),
                    new Vector3(0.13261F, 0.13261F, 0.13261F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Seed"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySeed"),
                    "UpperArmR",
                    new Vector3(-0.19155F, 0.38862F, 0.03952F),
                    new Vector3(1.50254F, 327.4763F, 92.35478F),
                    new Vector3(0.06067F, 0.06067F, 0.06067F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ShieldOnly"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(0.11838F, 0.39124F, -0.11775F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.51685F, 0.51685F, 0.51685F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(0.12279F, 0.36443F, 0.11873F),
                    new Vector3(6.20601F, 0.93935F, 359.2854F),
                    new Vector3(0.51685F, 0.51685F, -0.51685F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ShockNearby"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                    "backpack_spinner",
                    new Vector3(-0.12783F, 0.00694F, 0.00003F),
                    new Vector3(0F, 0F, 86.844F),
                    new Vector3(0.64252F, 0.64252F, 0.64252F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SiphonOnLowHealth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                    "Pelvis",
                    new Vector3(0F, 0.03748F, -0.33335F),
                    new Vector3(7.41449F, 176.131F, 179.5F),
                    new Vector3(0.10253F, 0.10253F, 0.10253F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SlowOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBauble"),
                    "Pelvis",
                    new Vector3(0.44462F, 0.37421F, 0.04996F),
                    new Vector3(16.27357F, 137.7162F, 193.9336F),
                    new Vector3(0.46867F, 0.46867F, 0.46867F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SlowOnHitVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBaubleVoid"),
                    "Pelvis",
                    new Vector3(0.44462F, 0.37421F, 0.04996F),
                    new Vector3(16.27357F, 137.7162F, 193.9336F),
                    new Vector3(0.46867F, 0.46867F, 0.46867F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SprintArmor"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBuckler"),
                    "LowerArmL",
                    new Vector3(0.00005F, 0.21642F, 0.13917F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.25398F, 0.25398F, 0.25398F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SprintBonus"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySoda"),
                    "ThighL",
                    new Vector3(-0.00006F, 0.08015F, -0.18534F),
                    new Vector3(75.99728F, -0.0002F, 322.7082F),
                    new Vector3(0.44761F, 0.44761F, 0.44761F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SprintOutOfCombat"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWhip"),
                    "Pelvis",
                    new Vector3(0.25826F, 0.05979F, -0.13605F),
                    new Vector3(348.9121F, 2.77213F, 139.0554F),
                    new Vector3(0.41525F, 0.41525F, 0.41525F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("SprintWisp"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                    "backpack_base",
                    new Vector3(-0.29402F, 0.165F, 0.30877F),
                    new Vector3(343.4185F, 317.4984F, 2.21011F),
                    new Vector3(0.22034F, 0.22034F, 0.22034F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Squid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                    "backpack_base",
                    new Vector3(-0.1157F, -0.50145F, 0.32228F),
                    new Vector3(3.80901F, 244.1962F, 264.5363F),
                    new Vector3(0.07074F, 0.07074F, 0.07074F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("StickyBomb"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                    "weapon_base",
                    new Vector3(-0.16395F, 0.93763F, -0.23738F),
                    new Vector3(7.21707F, 252.5581F, 87.86289F),
                    new Vector3(0.40765F, 0.40765F, 0.40765F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("StrengthenBurn"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasTank"),
                    "CalfR",
                    new Vector3(-0.0274F, 0.20258F, -0.11964F),
                    new Vector3(1.90105F, 180F, 200.9193F),
                    new Vector3(0.27391F, 0.27391F, 0.27391F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("StunAndPierce"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElectricBoomerang"),
                    "weaponLens1",
                    new Vector3(0.00001F, -0.06227F, -0.00002F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.96212F, 0.96212F, 0.96212F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("StunChanceOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                    "weapon_base",
                    new Vector3(-0.34647F, -0.40149F, -0.0926F),
                    new Vector3(335.3737F, 0F, 0F),
                    new Vector3(1.34215F, 1.34215F, 1.34215F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Syringe"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                    "UpperArmR",
                    new Vector3(0.08871F, -0.00462F, 0.08462F),
                    new Vector3(61.46315F, 42.3457F, 347.7867F),
                    new Vector3(0.31832F, 0.31832F, 0.31832F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TPHealingNova"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                    "backpack_base",
                    new Vector3(-0.32181F, -0.13679F, -0.3796F),
                    new Vector3(8.76722F, 226.548F, 343.5572F),
                    new Vector3(0.63902F, 0.63902F, 0.63902F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Talisman"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTalisman"),
                    "backpack_base",
                    new Vector3(-0.48735F, -0.82299F, -0.04948F),
                    new Vector3(8.76722F, 226.548F, 343.5572F),
                    new Vector3(0.63902F, 0.63902F, 0.63902F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TeleportOnLowHealth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeleportOnLowHealth"),
                    "backpack_base",
                    new Vector3(-0.27933F, -0.75635F, 0.00494F),
                    new Vector3(0F, 267.181F, 0F),
                    new Vector3(1.89516F, 1.89516F, 0.94733F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Thorns"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                    "Chest",
                    new Vector3(2, 2, 2),
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 1)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TitanGoldDuringTP"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                    "ThighR",
                    new Vector3(0.19637F, 0.25679F, 0.00002F),
                    new Vector3(331.9592F, 98.47086F, 351.4304F),
                    new Vector3(0.33707F, 0.33707F, 0.33707F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Tooth"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                    "Chest_Item",
                    new Vector3(-0.00001F, 0.00323F, 0.00491F),
                    new Vector3(7.66177F, 0F, 0F),
                    new Vector3(3.58014F, 3.58014F, 3.58014F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest_Item",
                    new Vector3(0.09109F, -0.02416F, 0.00123F),
                    new Vector3(7.66177F, 0F, 340.3589F),
                    new Vector3(2.88983F, 2.88983F, 2.88983F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest_Item",
                    new Vector3(0.1526F, -0.05828F, -0.00336F),
                    new Vector3(7.66178F, 0F, 346.9604F),
                    new Vector3(2.54944F, 2.54944F, 2.54944F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest_Item",
                    new Vector3(-0.18801F, -0.05602F, -0.01578F),
                    new Vector3(10.006F, 345.6985F, 8.26586F),
                    new Vector3(2.80169F, 2.80169F, 2.80169F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                   "Chest_Item",
                    new Vector3(-0.1072F, -0.02392F, 0.00126F),
                    new Vector3(7.66177F, 0F, 21.52076F),
                    new Vector3(3.31853F, 3.31853F, 3.31853F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TreasureCache"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKey"),
                   "ThighL",
                    new Vector3(0.00561F, 0.52325F, -0.13546F),
                    new Vector3(281.1142F, 60.58013F, 299.8863F),
                    new Vector3(1.92684F, 1.92684F, 1.92684F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TreasureCacheVoid"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKeyVoid"),
                    "ThighL",
                    new Vector3(0.00561F, 0.52325F, -0.13546F),
                    new Vector3(281.1142F, 60.58013F, 299.8863F),
                    new Vector3(1.92684F, 1.92684F, 1.92684F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TriggerEnemyDebuffs"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNoxiousThorn"),
                    "backpack_base",
                    new Vector3(-0.29423F, 0.17726F, -0.25085F),
                    new Vector3(24.0023F, 306.8707F, 62.29744F),
                    new Vector3(0.80834F, 0.80834F, 0.80834F) 
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("UtilitySkillMagazine"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmR",
                    new Vector3(0.04858F, -0.0686F, -0.08941F),
                    new Vector3(280.4542F, -0.00007F, 311.8234F),
                    new Vector3(1.20726F, 1.20726F, 1.20726F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmL",
                    new Vector3(0.00224F, -0.0584F, -0.14457F),
                    new Vector3(280.4542F, -0.00007F, 32.59544F),
                    new Vector3(1.20726F, 1.20726F, 1.20726F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("VoidMegaCrabItem"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMegaCrabItem"),
                    "ThighR",
                    new Vector3(0.18366F, 0.27531F, -0.06026F),
                    new Vector3(7.86757F, 115.0415F, 78.6731F),
                    new Vector3(0.20933F, 0.20933F, 0.20933F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("WarCryOnMultiKill"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPauldron"),
                    "UpperArmR",
                    new Vector3(0.00003F, -0.06298F, 0.19105F),
                    new Vector3(62.27732F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("WardOnLevel"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarbanner"),
                    "Pelvis",
                    new Vector3(0.15088F, -0.02994F, 0.00113F),
                    new Vector3(41.55707F, 88.10091F, 87.13852F),
                    new Vector3(0.50001F, 0.50001F, 0.50001F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BFG"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBFG"),
                    "weapon_base",
                    new Vector3(-0.19255F, 1.06701F, -0.02932F),
                    new Vector3(271.7732F, 41.59996F, 42.45608F),
                    new Vector3(0.64798F, 0.64798F, 0.64798F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Blackhole"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravCube"),
                    "Root",
                    new Vector3(-0.17085F, 1.65166F, -1.02707F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.57087F, 0.57087F, 0.57087F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BossHunter"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornGhost"),
                    "Head",
                    new Vector3(-0.04608F, 0.42399F, 0F),
                    new Vector3(26.1535F, 90F, 0F),
                    new Vector3(1.12654F, 1.12654F, 1.12654F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBlunderbuss"),
                    "Root",
                    new Vector3(-1.43696F, 2.16611F, 0F),
                    new Vector3(90F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BossHunterConsumed"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornUsed"),
                    "Head",
                    new Vector3(-0.04608F, 0.42399F, 0F),
                    new Vector3(26.1535F, 90F, 0F),
                    new Vector3(1.12654F, 1.12654F, 1.12654F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("BurnNearby"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPotion"),
                    "backpack_base",
                    new Vector3(-0.09018F, -0.52487F, -0.39686F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.06722F, 0.06722F, 0.06722F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Cleanse"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaterPack"),
                    "backpack_base",
                    new Vector3(-0.34328F, -0.24068F, 0.0001F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.19179F, 0.19179F, 0.19179F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CommandMissile"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileRack"),
                    "backpack_base",
                    new Vector3(-0.04994F, -0.49996F, -0.30668F),
                    new Vector3(81.34052F, 348.5397F, 168.667F),
                    new Vector3(0.64514F, 0.64514F, 0.64514F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CrippleWard"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEffigy"),
                    "backpack_base",
                    new Vector3(-0.0021F, -0.80086F, -0.35547F),
                    new Vector3(0F, 0F, 32.95721F),
                    new Vector3(0.97368F, 0.97368F, 0.97368F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("CritOnUse"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                    "Head",
                    new Vector3(0.38545F, 0.19161F, 0F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.26725F, 0.26725F, 0.26725F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("DeathProjectile"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                    "backpack_base",
                    new Vector3(-0.08228F, -0.63321F, -0.43666F),
                    new Vector3(349.3648F, 199.0677F, 327.2069F),
                    new Vector3(0.18149F, 0.18149F, 0.18149F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("DroneBackup"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRadio"),
                    "backpack_base",
                    new Vector3(-0.09999F, -0.5135F, -0.3768F),
                    new Vector3(5.93354F, 183.7227F, 323.1921F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteAurelioniteEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteAurelioniteEquipment"),
                    "Head",
                    new Vector3(0.24442F, 0.36429F, -0.0197F),
                    new Vector3(349.1216F, 90.24615F, 356.5761F),
                    new Vector3(0.54549F, 0.54549F, 0.54549F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteBeadEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteBeadSpike"),
                    "Head",
                    new Vector3(0F, 0.3557F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.02939F, 0.02939F, 0.02939F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteEarthEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteMendingAntlers"),
                    "Head",
                    new Vector3(0.13817F, 0.27868F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteFireEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(0.14555F, 0.19775F, -0.00844F),
                    new Vector3(12.7201F, 91.43581F, 9.26119F),
                    new Vector3(-0.17967F, 0.17967F, 0.17967F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(0.14555F, 0.19775F, -0.00844F),
                    new Vector3(12.7201F, 91.43581F, 9.26119F),
                    new Vector3(-0.17967F, 0.17967F, 0.17967F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteHauntedEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                    "Head",
                    new Vector3(0.00002F, 0.5416F, 0F),
                    new Vector3(270F, 90F, 0F),
                    new Vector3(0.09371F, 0.09371F, 0.09371F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteIceEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                   "Head",
                    new Vector3(-0.02763F, 0.52251F, -0.00001F),
                    new Vector3(270F, 90F, 0F),
                    new Vector3(0.03862F, 0.04063F, 0.04063F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteLightningEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(0.219F, 0.33842F, -0.00001F),
                    new Vector3(282.1982F, 90F, 0F),
                    new Vector3(0.44255F, 0.44255F, 0.44255F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-0.0137F, 0.42972F, -0.00001F),
                    new Vector3(283.4476F, 270F, 180F),
                    new Vector3(0.26967F, 0.26967F, 0.26967F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteLunarEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteLunar,Eye"),
                    "Head",
                    new Vector3(0.48685F, 0.20181F, 0F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.4823F, 0.4823F, 0.4823F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("ElitePoisonEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                    "Head",
                    new Vector3(0.00001F, 0.36824F, 0F),
                    new Vector3(270F, 90F, 0F),
                    new Vector3(0.1062F, 0.1062F, 0.1062F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("EliteVoidEquipment"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAffixVoid"),
                    "Head",
                    new Vector3(0.21665F, 0.13638F, 0F),
                    new Vector3(90F, 90F, 0F),
                    new Vector3(0.30466F, 0.30466F, 0.30466F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("FireBallDash"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEgg"),
                    "backpack_base",
                    new Vector3(-0.05645F, -0.58237F, -0.35628F),
                    new Vector3(308.5075F, 243.2431F, 111.3534F),
                    new Vector3(0.52895F, 0.52895F, 0.52895F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Fruit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFruit"),
                    "backpack_base",
                    new Vector3(0.10146F, -1.02881F, -0.23801F),
                    new Vector3(331.9561F, 68.85749F, 31.35033F),
                    new Vector3(0.37767F, 0.37767F, 0.37767F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GainArmor"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                    "backpack_base",
                    new Vector3(-0.02746F, -0.59112F, -0.36794F),
                    new Vector3(332.3364F, 280.3968F, 10.94887F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Gateway"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVase"),
                    "backpack_base",
                    new Vector3(0.00004F, -0.69054F, -0.37137F),
                    new Vector3(346.4803F, 180F, 180F),
                    new Vector3(0.37623F, 0.37623F, 0.37623F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GoldGat"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldGat"),
                    "UpperArmL",
                    new Vector3(-0.11984F, -0.43291F, 0.07181F),
                    new Vector3(358.5466F, 233.9762F, 190.1096F),
                    new Vector3(0.15652F, 0.15652F, 0.15652F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("GummyClone"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGummyClone"),
                    "backpack_base",
                    new Vector3(-0.19417F, -0.44061F, -0.33637F),
                    new Vector3(0F, 0F, 55.49944F),
                    new Vector3(0.39912F, 0.39912F, 0.39912F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("HealAndRevive"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealAndRevive"),
                    "backpack_base",
                    new Vector3(-0.06655F, -0.5302F, -0.35405F),
                    new Vector3(29.55474F, 257.6591F, 28.99035F),
                    new Vector3(1.50213F, 1.50213F, 1.50213F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("IrradiatingLaser"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIrradiatingLaser"),
                    "weapon_base",
                    new Vector3(-0.47928F, -0.01859F, -0.24851F),
                    new Vector3(280.7621F, 113.9172F, 336.4574F),
                    new Vector3(0.33411F, 0.33411F, 0.33411F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Jetpack"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBugWings"),
                    "backpack_base",
                    new Vector3(-0.41577F, 0.01412F, 0.00005F),
                    new Vector3(345.9272F, 90F, 0F),
                    new Vector3(0.24957F, 0.24957F, 0.24957F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LifestealOnHit"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                    "backpack_base",
                    new Vector3(-0.08077F, -0.58527F, -0.48743F),
                    new Vector3(327.5999F, 0.00001F, 330.5048F),
                    new Vector3(0.1455F, 0.1455F, 0.1455F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Lightning"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLightningArmRight"),
                    "backpack_base",
                    new Vector3(2, 2, 2),
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 1)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightArm)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("LunarPortalOnUse"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarPortalOnUse"),
                    "Root",
                    new Vector3(-0.24301F, 1.54877F, -1.08539F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.70109F, 0.70109F, 0.70109F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Meteor"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteor"),
                    "Root",
                    new Vector3(-0.14477F, 1.79951F, -1.12184F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.75924F, 0.75924F, 0.75924F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Molotov"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMolotov"),
                    "backpack_base",
                    new Vector3(0.0078F, -0.6384F, -0.31966F),
                    new Vector3(32.4553F, 213.793F, 321.2761F),
                    new Vector3(0.44261F, 0.44261F, 0.44261F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("MultiShopCard"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayExecutiveCard"),
                    "backpack_base",
                    new Vector3(-0.00017F, -0.52701F, -0.32454F),
                    new Vector3(82.67574F, 83.80247F, 270F),
                    new Vector3(1.65121F, 1.65121F, 1.65121F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("QuestVolatileBattery"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                    "backpack_spinner",
                    new Vector3(-0.17771F, -0.00012F, -0.00457F),
                    new Vector3(0F, 268.5137F, 0F),
                    new Vector3(0.55286F, 0.55286F, 0.55286F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Recycle"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRecycler"),
                    "backpack_base",
                    new Vector3(-0.02735F, -0.56458F, -0.40139F),
                    new Vector3(0F, 95.83913F, 0F),
                    new Vector3(0.11574F, 0.10498F, 0.10498F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Saw"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySawmerangFollower"),
                    "Root",
                    new Vector3(-0.85487F, 2.30484F, 0.94187F),
                    new Vector3(86.31735F, 180F, 180F),
                    new Vector3(0.18444F, 0.18444F, 0.18444F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Scanner"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScanner"),
                    "backpack_base",
                    new Vector3(-0.09659F, -0.6237F, -0.28054F),
                    new Vector3(2.41636F, 221.3338F, 184.845F),
                    new Vector3(0.24427F, 0.24427F, 0.24427F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("TeamWarCry"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                    "backpack_base",
                    new Vector3(-0.06176F, -0.59324F, -0.36515F),
                    new Vector3(10.57515F, 178.9739F, 3.08356F),
                    new Vector3(0.10728F, 0.10728F, 0.10728F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("Tonic"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTonic"),
                    "backpack_base",
                    new Vector3(-0.13736F, -0.51023F, -0.37626F),
                    new Vector3(0F, 0F, 42.70369F),
                    new Vector3(0.44476F, 0.44476F, 0.44476F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.GetKeyAsset("VendingMachine"),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVendingMachine"),
                    "backpack_base",
                    new Vector3(-0.13422F, -0.4276F, -0.32188F),
                    new Vector3(21.3583F, 165.6164F, 318.935F),
                    new Vector3(0.29607F, 0.29607F, 0.29607F)
                    )
                ));

            ItemDisplayCheck.PrintUnused(itemDisplayRules);
        }
    }
}