using RA2Mod.General;
using RA2Mod.Modules;
using RA2Mod.Survivors.Chrono.Components;
using RA2Mod.Survivors.Chrono.SkillDefs;
using RA2Mod.Survivors.Chrono.States;
using RobDriver.Modules.Components;
using RobDriver.Modules.Weapons;
using RoR2;
using RoR2.Skills;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;
using static DriverWeaponDef;

namespace RA2Mod.Survivors.Chrono
{
    internal class ChronoDriverCompat
    {
        public static GameObject chronoIndicatorVanishDriver;
        public static ConfigEntry<float> Driver_M1_Damage;
        public static ConfigEntry<float> Driver_M1_Duration;
        public static ConfigEntry<float> Driver_M2_Damage;
        public static ConfigEntry<float> Driver_M2_TickInterval;
        public static ConfigEntry<float> Driver_M2_Duration;

        private ushort chronoGunIndex;

        private static AssetBundle assetBundle => ChronoSurvivor.instance.assetBundle;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void Init()
        {
            RA2Mod.Hooks.RoR2.SurvivorCatalog.SetSurvivorDefs_Driver += SurvivorCatalog_SetSurvivorDefs_Driver;

            if (General.GeneralConfig.Debug.Value)
            {
                On.RoR2.CharacterBody.Update += CharacterBody_Update;
            }
        }

        private void SurvivorCatalog_SetSurvivorDefs_Driver(GameObject driverBody)
        {
            driverBody.AddComponent<ChronoTrackerVanishDriver>();
            Log.Debug("found driver. adding tracker");
            DoDriverCompat();
        }

        private void CharacterBody_Update(On.RoR2.CharacterBody.orig_Update orig, CharacterBody self)
        {
            orig(self);
            if (Input.GetKeyDown(KeyCode.G))
            {
                if(self.TryGetComponent(out DriverController cantdrive55))
                {
                    cantdrive55.PickUpWeapon(RobDriver.DriverWeaponCatalog.GetWeaponFromIndex(chronoGunIndex));
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (self.TryGetComponent(out DriverController cantdrive55))
                {
                    cantdrive55.PickUpWeapon(RobDriver.DriverWeaponCatalog.GetRandomWeapon());
                }
            }
        }

        private void DoDriverCompat()
        {
            InitConfig();
            SetTokens();
            Content.AddEntityState(typeof(ShootDriver));
            Content.AddEntityState(typeof(VanishDriver));

            chronoIndicatorVanishDriver = assetBundle.LoadAsset<GameObject>("IndicatorChronoVanishDriver");

            ChronoDriverWeapon weapon = new ChronoDriverWeapon();
            weapon.Init();
            chronoGunIndex = weapon.weaponDef.index;
        }

        private void InitConfig()
        {
            string section = "2-3. Chrono Mod Compats";

            Driver_M1_Damage = Config.BindAndOptionsSlider(
                section,
                nameof(Driver_M1_Damage),
                2.0f,
                0,
                20,
                "");

            Driver_M1_Duration = Config.BindAndOptionsSlider(
                section,
                nameof(Driver_M1_Duration),
                0.4f,
                0,
                5,
                "");

            Driver_M2_Damage = Config.BindAndOptionsSlider(
                section,
                nameof(Driver_M2_Damage),
                0.3f,
                0,
                10,
                "");

            Driver_M2_TickInterval = Config.BindAndOptionsSlider(
                section,
                nameof(Driver_M2_TickInterval),
                0.08f,
                0,
                10,
                "");

            Driver_M2_Duration = Config.BindAndOptionsSlider(
                section,
                nameof(Driver_M2_Duration),
                1f,
                0,
                20,
                "");
        }

        private static void SetTokens()
        {
            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME", "Chrono Gun");
            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION", $"Makes enemies vanish from existence.");

            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "PRIMARY_SHOOT_DRIVER_NAME", "Chrono Gun");
            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "PRIMARY_SHOOT_DRIVER_DESCRIPTION", $"Fire for {Tokens.DamageValueText(ChronoDriverCompat.Driver_M1_Damage.Value)} and apply {Tokens.UtilityText("Chrono Sickness")} to enemies.");

            int driverTicks = (int)(ChronoDriverCompat.Driver_M2_Duration.Value / ChronoDriverCompat.Driver_M2_TickInterval.Value);
            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "SPECIAL_VANISH_DRIVER_NAME", "Deconstructing");
            Modules.Language.Add(ChronoSurvivor.TOKEN_PREFIX + "SPECIAL_VANISH_DRIVER_DESCRIPTION", $"Focus your rifle for up to {Tokens.DamageValueText(ChronoDriverCompat.Driver_M2_Damage.Value * driverTicks)}. An enemy below the {Tokens.UtilityText("Chrono Sickness")} threshold will vanish from existence.");
        }

        internal class ChronoDriverWeapon : DriverCompatWeapon<ChronoDriverWeapon, ChronoSurvivor>
        {
            public override string nameToken => ChronoSurvivor.TOKEN_PREFIX + "DRIVER_GUN_NAME";
            public override string descriptionToken => ChronoSurvivor.TOKEN_PREFIX + "DRIVER_GUN_DESCRIPTION";
            public override Texture icon => assetBundle.LoadAsset<Texture2D>("texIconChronoDriverGun");
            public override DriverWeaponTier tier => DriverWeaponTier.Uncommon;
            public override int shotCount => 32;
            public override BuffType buffType => BuffType.AttackSpeed;
            public override SkillDef primarySkillDef => Skills.CreateSkillDef(new SkillDefInfo
                (
                    "chronoShoot",
                    ChronoSurvivor.TOKEN_PREFIX + "PRIMARY_SHOOT_DRIVER_NAME",
                    ChronoSurvivor.TOKEN_PREFIX + "PRIMARY_SHOOT_DRIVER_DESCRIPTION",
                    ChronoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texIconChronoPrimary"),
                    new EntityStates.SerializableEntityStateType(typeof(ShootDriver)),
                    "Weapon",
                    false
                )); 
            public override SkillDef secondarySkillDef => Skills.CreateSkillDef<ChronoTrackerSkillDefVanish>(new SkillDefInfo
            {
                skillName = "chronoVanish",
                skillNameToken = ChronoSurvivor.TOKEN_PREFIX + "SPECIAL_VANISH_DRIVER_NAME",
                skillDescriptionToken = ChronoSurvivor.TOKEN_PREFIX + "SPECIAL_VANISH_DRIVER_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texIconChronoSpecial"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(VanishDriver)),
                activationStateMachineName = "Weapon",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseMaxStock = 3,
                baseRechargeInterval = 3f,

                isCombatSkill = true,
                mustKeyPress = true,
                beginSkillCooldownOnSkillEnd = true
            });
            public override Mesh mesh => assetBundle.LoadAsset<Mesh>("meshDriverChronoGun");
            public override Material material => assetBundle.CreateHopooMaterialFromBundle("matDriverChronoGun");
            public override AnimationSet animationSet => DriverWeaponDef.AnimationSet.TwoHanded;
            public override string calloutSoundString => "Play_Chrono_Voiceline_Driver";
            public override string configIdentifier => "RA Chrono Legionnaire Gun";
            public override float dropChance => 1;
            public override bool addToPool => true;
            public override ChronoSurvivor characterBase => ChronoSurvivor.instance;
        }
    }

    internal class ChronoTrackerVanishDriver : ChronoTrackerVanish
    {
        public override float maxTrackingDistance => 80;

        public override float maxTrackingAngle => 30;

        public override BullseyeSearch.SortMode bullseyeSortMode => BullseyeSearch.SortMode.Angle;

        public override bool filterByLoS => false;

        protected override void SetIndicator()
        {
            this.indicator = new Indicator(base.gameObject, ChronoDriverCompat.chronoIndicatorVanishDriver);
        }
    }

    //public class ChronoTrackerSkillDefVanishDriver : ChronoTrackerSkillDefVanish { }


    internal class ShootDriver : ChronoShoot
    {
        public override float baseDuration => ChronoDriverCompat.Driver_M1_Duration.Value;
        public override float damageCoefficient => ChronoDriverCompat.Driver_M1_Damage.Value;
        public override float hitRadius => 1;
        public override float recoil => 0.4f;
        public override void OnEnter()
        {
            base.OnEnter();

            if (gameObject.TryGetComponent(out DriverController iDrive)) 
            { 
                iDrive.ConsumeAmmo();
            }

            muzzleString = "ShotgunMuzzle";
        }

        protected override void PlayShootAnimation()
        {
            base.PlayShootAnimation();

            PlayAnimation("Gesture, Override", "FireMachineGun", "Shoot.playbackRate", duration * 3);
        }
    }

    internal class VanishDriver : Vanish
    {
        public override float damageCoefficient => ChronoDriverCompat.Driver_M2_Damage.Value;
        public override float baseTickInterval =>  ChronoDriverCompat.Driver_M2_TickInterval.Value;
        public override float baseDuration =>      ChronoDriverCompat.Driver_M2_Duration.Value;
        public override int damageTicksPerDebuffStack => 1;

        private DriverWeaponDef cachedWeaponDef;
        private DriverController iDrive;

        public override void OnEnter()
        {
            if(gameObject.TryGetComponent(out iDrive))
            {
                cachedWeaponDef = iDrive?.weaponDef;
            }

            base.OnEnter();

            PlayAnimation("Gesture, Override", "FireMachineGun", "Shoot.playbackRate", 1000);

            muzzleTransform = FindModelChild("ShotgunMuzzle");
            if(muzzleTransform == null)
            {
                muzzleTransform = transform;
            }

            SetTetherPoints();

            if (targetingAlly)
            {
                if (iDrive)
                {
                    iDrive.ConsumeAmmo();
                }
            }
        }

        public override void DoDamage()
        {
            if (iDrive)
            {
                iDrive.ConsumeAmmo(tickInterval / baseDuration * 4f);
            }

            base.DoDamage();
        }

        public override void OnExit()
        {
            base.OnExit();
            //base.PlayCrossfade("Gesture, Override", "BufferEmpty", 0.8f);
            PlayAnimation("Gesture, Override", "FireMachineGun", "Shoot.playbackRate", 1);
        }

        public override void FixedUpdate()
        {
            if (iDrive && cachedWeaponDef != iDrive.weaponDef)
            {
                this.outer.SetNextStateToMain();
                return;
            }

            base.FixedUpdate();
        }
    }
}
