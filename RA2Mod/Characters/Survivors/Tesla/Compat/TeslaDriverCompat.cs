using RA2Mod.General;
using RA2Mod.Modules;
using RA2Mod.Survivors.Chrono.SkillDefs;
using RA2Mod.Survivors.Chrono;
using RA2Mod.Survivors.Tesla.SkillDefs;
using RA2Mod.Survivors.Tesla.States;
using RobDriver.Modules.Components;
using RoR2;
using RoR2.Skills;
using System.Runtime.CompilerServices;
using UnityEngine;
using static DriverWeaponDef;
using EntityStates;

namespace RA2Mod.Survivors.Tesla.Compat
{
    internal class TeslaDriverCompat
    {
        private ushort teslaGunIndex;

        private static AssetBundle assetBundle => TeslaTrooperSurvivor.instance.assetBundle;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void Init()
        {
            Hooks.RoR2.SurvivorCatalog.SetSurvivorDefs_Driver += SurvivorCatalog_SetSurvivorDefs_Driver;

            //InitConfig();

            #region tokens
            Modules.Language.Add(TeslaTrooperSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME", "Tesla Gauntlet");
            Modules.Language.Add(TeslaTrooperSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION", $"2000 volts coming up.");

            //Modules.Language.Add(TeslaTrooperSurvivor.TESLA_PREFIX + "PRIMARY_SHOOT_DRIVER_NAME", "Chrono Gun");
            //Modules.Language.Add(TeslaTrooperSurvivor.TESLA_PREFIX + "PRIMARY_SHOOT_DRIVER_DESCRIPTION", $"Fire for {Tokens.DamageValueText(DriverCompat.DriverGunM1Damage.Value)} and apply {Tokens.UtilityText("Chrono Sickness")} to enemies.");

            //int driverTicks = (int)(DriverCompat.DriverGunM2Duration.Value / DriverCompat.DriverGunM2TickInterval.Value);
            //Modules.Language.Add(TeslaTrooperSurvivor.TESLA_PREFIX + "SPECIAL_VANISH_DRIVER_NAME", "Deconstructing");
            //Modules.Language.Add(TeslaTrooperSurvivor.TESLA_PREFIX + "SPECIAL_VANISH_DRIVER_DESCRIPTION", $"Focus your rifle for up to {Tokens.DamageValueText(DriverCompat.DriverGunM2Damage.Value * driverTicks)}. An enemy below the {Tokens.UtilityText("Chrono Sickness")} threshold will vanish from existence.");
            #endregion tokens

            if (General.GeneralConfig.Debug.Value)
            {
                On.RoR2.CharacterBody.Update += CharacterBody_Update;
            }
        }

        private void SurvivorCatalog_SetSurvivorDefs_Driver(GameObject driverBody)
        {
            driverBody.AddComponent<TeslaTrackerComponent>();
            driverBody.AddComponent<TeslaTrackerComponentZap>();
            driverBody.AddComponent<TeslaTowerControllerControllerGuest>();
            Log.Debug("found driver. adding tracker");
            DoDriverCompat();
        }

        private void CharacterBody_Update(On.RoR2.CharacterBody.orig_Update orig, CharacterBody self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (self.TryGetComponent(out DriverController cantdrive55))
                {
                    cantdrive55.PickUpWeapon(RobDriver.DriverWeaponCatalog.GetWeaponFromIndex(teslaGunIndex));
                }
            }
        }

        private void DoDriverCompat()
        {
            TeslaDriverWeapon weapon = new TeslaDriverWeapon();
            weapon.Init();
            teslaGunIndex = weapon.weaponDef.index;
        }

        internal class TeslaDriverWeapon : DriverCompatWeapon<TeslaDriverWeapon, TeslaTrooperSurvivor>
        {
            public override string nameToken => TeslaTrooperSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME";
            public override string descriptionToken => TeslaTrooperSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION";
            public override Texture icon => assetBundle.LoadAsset<Texture2D>("texIconTeslaRA2");
            public override DriverWeaponTier tier => DriverWeaponTier.Uncommon;
            public override int shotCount => 10;//
            public override BuffType buffType => BuffType.Damage;
            public override SkillDef primarySkillDef =>
                Skills.CreateSkillDef<TeslaTrackingSkillDef>(new SkillDefInfo("Tesla_Primary_Zap",
                                                                              TeslaTrooperSurvivor.TOKEN_PREFIX + "PRIMARY_ZAP_NAME",
                                                                              TeslaTrooperSurvivor.TOKEN_PREFIX + "PRIMARY_ZAP_DESCRIPTION",
                                                                              assetBundle.LoadAsset<Sprite>("texTeslaSkillPrimary"),
                                                                              new EntityStates.SerializableEntityStateType(typeof(DriverZap)),
                                                                              "Weapon",
                                                                              false));
            public override SkillDef secondarySkillDef =>
                Modules.Skills.CreateSkillDef(new SkillDefInfo
                {
                    skillName = "Tesla_Secondary_BigZap",
                    skillNameToken = TeslaTrooperSurvivor.TOKEN_PREFIX + "SECONDARY_BIGZAP_NAME",
                    skillDescriptionToken = TeslaTrooperSurvivor.TOKEN_PREFIX + "SECONDARY_BIGZAP_DESCRIPTION",
                    skillIcon = assetBundle.LoadAsset<Sprite>("texTeslaSkillSecondary"),
                    activationState = new EntityStates.SerializableEntityStateType(typeof(DriverAimBigZap)),
                    activationStateMachineName = "Weapon",
                    baseMaxStock = 1,
                    baseRechargeInterval = 5.5f,
                    beginSkillCooldownOnSkillEnd = true,
                    canceledFromSprinting = false,
                    forceSprintDuringState = false,
                    fullRestockOnAssign = true,
                    interruptPriority = EntityStates.InterruptPriority.Skill,
                    resetCooldownTimerOnUse = false,
                    isCombatSkill = true,
                    mustKeyPress = false,
                    cancelSprintingOnActivation = true,
                    rechargeStock = 1,
                    requiredStock = 1,
                    stockToConsume = 1,
                    keywordTokens = new string[] { "KEYWORD_STUNNING", "KEYWORD_SHOCKING" }
                });

            public override Mesh mesh => assetBundle.LoadAsset<Mesh>("meshDriverTeslaGauntlet");
            public override Material material => assetBundle.CreateHopooMaterialFromBundle("matTesla_original_Armor");
            public override AnimationSet animationSet => DriverWeaponDef.AnimationSet.Default;
            public override string calloutSoundString => "Play_Voiceline_Driver";
            public override string configIdentifier => "Tesla Gauntlet";
            public override float dropChance => 1;
            public override bool addToPool => true;
            public override TeslaTrooperSurvivor characterBase => TeslaTrooperSurvivor.instance;
        }

        public class DriverZap : Zap
        {
            protected override string zapMuzzle => "PistolMuzzle";

            public override void OnEnter()
            {
                base.OnEnter();

                if (gameObject.TryGetComponent(out DriverController iDrive))
                {
                    iDrive.ConsumeAmmo();
                }
            }

            protected override void SetAnimatorHandOut() { }
            protected override void UnSetAnimatorHandOut() { }

            protected override void PlayZapAnimation()
            {
                PlayAnimation("Gesture, Override", "Shoot", "Shoot.playbackRate", this.duration * 1.5f);
            }
        }

        public class DriverAimBigZap : AimBigZap
        {
            protected override void EnterAnimation()
            {
                base.PlayAnimation("Gesture, Override", "SteadyAim", "Action.playbackRate", 0.25f);
            }

            public override EntityState PickNextState()
            {
                castSuccessful = true;
                return new DriverBigZap() { aimPoint = currentTrajectoryInfo.hitPoint };
            }
        }

        public class DriverBigZap : BigZap
        {
            public override void OnEnter()
            {
                base.OnEnter();

                if (gameObject.TryGetComponent(out DriverController iDrive))
                {
                    iDrive.ConsumeAmmo(2);
                }
            }

            protected override void ExitAnimation() { }

            protected override void PlayShockAnimation()
            {
                PlayAnimation("Gesture, Override", "Shoot", "Shoot.playbackRate", this.duration * 1.5f);
            }

            protected override void PlayShockAnimationTower()
            {
                PlayShockAnimation();
            }
        }
    }
}
