using EntityStates;
using RA2Mod.General;
using RA2Mod.Modules;
using RA2Mod.Survivors.Desolator.SkillDefs;
using RA2Mod.Survivors.Desolator.States;
using RA2Mod.Survivors.Tesla.SkillDefs;
using RA2Mod.Survivors.Tesla.States;
using RA2Mod.Survivors.Tesla;
using RobDriver.Modules.Components;
using RoR2;
using RoR2.Skills;
using System.Runtime.CompilerServices;
using UnityEngine;
using static DriverWeaponDef;
using static RA2Mod.Survivors.Tesla.Compat.TeslaDriverCompat;
using R2API;
using RA2Mod.Survivors.Chrono;

namespace RA2Mod.Survivors.Desolator.Compat
{
    internal class DesolatorDriverCompat
    {
        private ushort desolatorGunIndex;

        private static AssetBundle assetBundle => DesolatorSurvivor.instance.assetBundle;

        private static ConfigEntry<float> Driver_M1_Damage;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void Init()
        {
            if (General.GeneralConfig.Debug.Value)
            {
                On.RoR2.CharacterBody.Update += CharacterBody_Update;
            }

            Hooks.RoR2.SurvivorCatalog.SetSurvivorDefs_Driver += SurvivorCatalog_SetSurvivorDefs_Driver;
        }

        private void CharacterBody_Update(On.RoR2.CharacterBody.orig_Update orig, CharacterBody self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (self.TryGetComponent(out DriverController cantdrive55))
                {
                    cantdrive55.PickUpWeapon(RobDriver.DriverWeaponCatalog.GetWeaponFromIndex(desolatorGunIndex));
                }
            }
        }

        private void SurvivorCatalog_SetSurvivorDefs_Driver(GameObject driverBody)
        {
            DoDriverCompat();
        }

        private void DoDriverCompat()
        {
            InitConfig();

            Modules.Language.Add(DesolatorSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME", "Rad Cannon");
            Modules.Language.Add(DesolatorSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION", $"Make it glow.");

            Modules.Language.Add(DesolatorSurvivor.TOKEN_PREFIX + "PRIMARY_BEAM_DRIVER_DESCRIPTION",
                $"Shoot an enemy with a beam of radiation for {Tokens.DamageValueText(Driver_M1_Damage)} and deal {Tokens.DamageText($"{Mathf.FloorToInt(RadBeam.RadPrimaryStacks * RadBeam.RadDamageMultiplier * DesolatorSurvivor.TotalDotDamage * 100)}% <style=cIsHealing>Radiation</style> damage")} over {Tokens.UtilityText($"{DesolatorSurvivor.DotDuration} seconds")}");

            Modules.Language.Add(DesolatorSurvivor.TOKEN_PREFIX + "SPECIAL_DEPLOY_DESCRIPTION",
                $"Shoot an enemy with a beam of radiation for {Tokens.DamageValueText(Driver_M1_Damage)} and deal {Tokens.DamageText($"{Mathf.FloorToInt(RadBeam.RadPrimaryStacks * RadBeam.RadDamageMultiplier * DesolatorSurvivor.TotalDotDamage * 100)}% <style=cIsHealing>Radiation</style> damage")} over {Tokens.UtilityText($"{DesolatorSurvivor.DotDuration} seconds")}");


            DesolatorDriverWeapon weapon = new DesolatorDriverWeapon();
            weapon.Init();
            desolatorGunIndex = weapon.weaponDef.index;

            Content.AddEntityState(typeof(DriverDeployIrradiate));
            Content.AddEntityState(typeof(DriverDeployEnter));
            Content.AddEntityState(typeof(DriverRadBeam));
        }

        private void InitConfig()
        {
            string section = "2-2. Deso Mod Compats";

            Driver_M1_Damage = Config.BindAndOptions(
                section,
                nameof(Driver_M1_Damage),
                3.0f,
                0,
                20,
                "");
        }


        internal class DesolatorDriverWeapon : DriverCompatWeapon<DesolatorDriverWeapon, DesolatorSurvivor>
        {
            public override string nameToken => DesolatorSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME";
            public override string descriptionToken => DesolatorSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION";
            public override Texture icon => assetBundle.LoadAsset<Texture2D>("texIconDesolatorDriverGun");
            public override DriverWeaponTier tier => DriverWeaponTier.Uncommon;
            public override int shotCount => 20;//
            public override BuffType buffType => BuffType.Damage;
            public override SkillDef primarySkillDef =>
                Skills.CreateSkillDef(new SkillDefInfo("Desolator_Driver_Primary_Beam",
                                                       DesolatorSurvivor.TOKEN_PREFIX + "PRIMARY_BEAM_NAME",
                                                       DesolatorSurvivor.TOKEN_PREFIX + "PRIMARY_BEAM_DRIVER_DESCRIPTION",
                                                       assetBundle.LoadAsset<Sprite>("texDesolatorSkillPrimary"),
                                                       new SerializableEntityStateType(typeof(DriverRadBeam)),
                                                       "Weapon",
                                                       false));
            public override SkillDef secondarySkillDef
            {
                get
                {
                    FuckingDesolatorDeploySkillDef deploySkillDef = Modules.Skills.CreateSkillDef<FuckingDesolatorDeploySkillDef>(new SkillDefInfo
                    {
                        skillName = "Desolator_Driver_Secondary_Deploy",
                        skillNameToken = DesolatorSurvivor.TOKEN_PREFIX + "SPECIAL_DEPLOY_NAME",
                        skillDescriptionToken = DesolatorSurvivor.TOKEN_PREFIX + "SPECIAL_DEPLOY_DESCRIPTION",
                        skillIcon = assetBundle.LoadAsset<Sprite>("texDesolatorSkillSpecial"),
                        activationState = new SerializableEntityStateType(typeof(DriverDeployEnter)),
                        activationStateMachineName = "Body",
                        baseMaxStock = 1,
                        baseRechargeInterval = 6f,
                        beginSkillCooldownOnSkillEnd = true,
                        canceledFromSprinting = false,
                        forceSprintDuringState = false,
                        fullRestockOnAssign = true,
                        interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                        resetCooldownTimerOnUse = false,
                        isCombatSkill = true,
                        mustKeyPress = true,
                        cancelSprintingOnActivation = true,
                        rechargeStock = 1,
                        requiredStock = 1,
                        stockToConsume = 1,
                        keywordTokens = new string[] { "KEYWORD_RADIATION_SPECIAL" }
                    });
                    deploySkillDef.actualActivationState = new SerializableEntityStateType(typeof(DriverDeployEnter));
                    deploySkillDef.cancelIcon = assetBundle.LoadAsset<Sprite>("texDesolatorSkillSpecialCancel");
                    return deploySkillDef;
                }
            }

            public override Mesh mesh => assetBundle.LoadAsset<Mesh>("meshDriverDesolatorGun");
            public override Material material => assetBundle.CreateHopooMaterialFromBundle("matDesolatorCannon");
            public override AnimationSet animationSet => DriverWeaponDef.AnimationSet.TwoHanded;
            public override string calloutSoundString => "Play_Desolator_Voiceline_Driver";
            public override string configIdentifier => "RA Desolator Rad Cannon";
            public override float dropChance => 1;
            public override bool addToPool => true;
            public override DesolatorSurvivor characterBase => DesolatorSurvivor.instance;
        }

        public class DriverRadBeam : RadBeam
        {
            public override string muzzleString => "ShotgunMuzzle";
            public override float damageCoefficient => Driver_M1_Damage;
            public override float BaseDuration => 1.2f;

            DriverController iDrive;

            public override void OnEnter()
            {
                if (gameObject.TryGetComponent(out iDrive))
                {
                    iDrive.ConsumeAmmo();
                }
                base.OnEnter();
            }

            protected override void ModifyBulletAttack(BulletAttack bulletAttack)
            {
                bulletAttack.AddModdedDamageType(iDrive.ModdedDamageType);
            }

            protected override void PlayShootAnimation()
            {
                PlayAnimation("Gesture, Override", "FireTwohand");
                GetComponent<DriverController>().ConsumeAmmo();
            }
        }

        public class DriverDeployEnter : DeployEnter
        {
            protected override void PlayCannonAnimations(Animator animator)
            {
                //no fancy spinning for driver
            }
            protected override void PlayEnterAnimation()
            {
                PlayCrossfade("FullBody, Override", "Heal", "Action.playbackRate", duration, 0.05f);
            }
            protected override void SetNextState()
            {
                _complete = true;
                var state = new DriverDeployIrradiate { aimRequest = this.aimRequest, fromEnter = true, activatorSkillSlot = activatorSkillSlot };
                outer.SetNextState(state);
            }
        }

        public class DriverDeployIrradiate : DeployIrradiate
        {
            private DriverWeaponDef cachedWeaponDef;
            private DriverController iDrive;

            public override void OnEnter()
            {
                base.OnEnter();

                if (gameObject.TryGetComponent(out iDrive))
                {
                    iDrive.ConsumeAmmo(4);
                    cachedWeaponDef = iDrive?.weaponDef;
                }
            }

            protected override void PlayPumpAnimation()
            {
                PlayAnimation("FullBody, Override", "HealLoop", "Action.playbackRate", duration, 0.05f);
            }
            protected override void UpdateCannonSpin()
            {
                //no spin :c
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();


                if (iDrive && cachedWeaponDef != iDrive.weaponDef)
                {
                    PlayAnimation("FullBody, Override", "BufferEmpty");
                    this.outer.SetNextStateToMain();
                    return;
                }
            }

            protected override void SetNextState()
            {
                _complete = true;
                var state = new DriverDeployIrradiate { aimRequest = this.aimRequest, fromEnter = true, activatorSkillSlot = activatorSkillSlot };
                outer.SetNextState(state);
            }
        }
    }
}