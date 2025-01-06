using BepInEx.Configuration;
using EntityStates;
using EntityStates.Engi.Mine;
using EntityStates.Engi.SpiderMine;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using RA2Mod.General.Components;
using RA2Mod.Modules;
using RA2Mod.Modules.Characters;
using RA2Mod.Survivors.Conscript.Components;
using RA2Mod.Survivors.Conscript.SkillDefs;
using RA2Mod.Survivors.Conscript.States;
using RA2Mod.Survivors.Conscript.States.TerrorDrone;
using RA2Mod.Survivors.Desolator;
using RoR2;
using RoR2.Projectile;
using RoR2.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript
{
    public class ConscriptSurvivor : SurvivorBase<ConscriptSurvivor>
    {
        public override string assetBundleName => "conscript";

        public override string bodyName => "RA2ConscriptBody";
        
        public override string masterName => "ConscriptMonsterMaster";

        public override string modelPrefabName => "mdlConscript";
        public override string displayPrefabName => "ConscriptDisplay";

        public const string TOKEN_PREFIX = RA2Plugin.DEVELOPER_PREFIX + "_CONSCRIPT_";

        public override string survivorTokenPrefix => TOKEN_PREFIX;

        public override BodyInfo bodyInfo => new BodyInfo
        {
            bodyName = bodyName,
            bodyNameToken = TOKEN_PREFIX + "NAME",
            subtitleNameToken = TOKEN_PREFIX + "SUBTITLE",

            characterPortrait = assetBundle.LoadAsset<Texture>("texIconConscript"),
            bodyColor = Color.red,
            sortPosition = 69.4f,
            
            //crosshairBundlePath = "GICrosshair",
            crosshairAddressablePath = "RoR2/Base/UI/StandardCrosshair.prefab",
            podPrefabAddressablePath = "RoR2/Base/SurvivorPod/SurvivorPod.prefab",

            maxHealth = 130f,
            healthRegen = 2.0f,
            armor = 10f,

            jumpCount = 1,
        };

        public override UnlockableDef characterUnlockableDef => null;// GIUnlockables.characterUnlockableDef;

        public override ItemDisplaysBase itemDisplays { get; }// = new RA2Mod.General.JoeItemDisplays();

        public override CustomRendererInfo[] customRendererInfos => new CustomRendererInfo[0];

        //public List<HurtBox> readOnlyTerrorDroneHurtboxes = new List<HurtBox>();
        public const int TERROR_DRONE_HURTBOX = 9090975;

        public override void Initialize()
        {
            if (!General.GeneralConfig.ConscriptEnabled.Value)
                return;

            base.Initialize();
        }

        public override void OnCharacterInitialized()
        {
            Config.ConfigureBody(prefabCharacterBody, ConscriptConfig.SectionBody);

            ConscriptConfig.Init();

            //GIUnlockables.Init();

            ConscriptStates.Init();
            ConscriptTokens.Init();
            Modules.Language.PrintOutput("conscript.txt");

            ConscriptBuffs.Init(assetBundle);
            ConscriptAssets.Init(assetBundle);

            InitializeEntityStateMachines();
            InitializeSkills();
            InitializeSkins();
            InitializeCharacterMaster();

            AdditionalBodySetup();

            AddHooks();
        }
        
        private void AdditionalBodySetup()
        {
            VoiceLineController voiceLineController = bodyPrefab.AddComponent<VoiceLineController>();
            voiceLineController.voiceLineContext = new VoiceLineContext("Conscript", 4, 3, 4);

            bodyPrefab.AddComponent<TerrorDroneTrackerBody>();
            bodyPrefab.AddComponent<GarrisonHolder>();

            prefabCharacterModel.baseRendererInfos[0].defaultMaterial.SetSpecular(0.2205176f, 1.476989f);
        }

        public override void InitializeEntityStateMachines() 
        {
            //clear existing state machines from your cloned body (probably commando)
            //omit all this if you want to just keep theirs
            Prefabs.ClearEntityStateMachines(bodyPrefab);

            //if you set up a custom main characterstate, set it up here
                //don't forget to register custom entitystates in your HenryStates.cs
            //the main "body" state machine has some special properties
            Prefabs.AddMainEntityStateMachine(bodyPrefab, "Body", typeof(EntityStates.GenericCharacterMain), typeof(EntityStates.SpawnTeleporterState));
            
            Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon");
            Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon2");
        }

        #region skills
        public override void InitializeSkills()
        {
            Skills.ClearGenericSkills(bodyPrefab);

            Skills.CreateSkillFamilies(bodyPrefab);
            AddPrimarySkills();
            AddSecondarySkills();
            AddUtiitySkills();
            AddSpecialSkills();
            AddRecolorSkills();
        }

        private void AddPrimarySkills()
        {
            MagazineSkillDef primarySkillDef1 = Skills.CreateSkillDef<MagazineSkillDef>(new SkillDefInfo
            {
                skillName = "conscript_gun",
                skillNameToken = TOKEN_PREFIX + "PRIMARY_GUN_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "PRIMARY_GUN_DESCRIPTION",
                //keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(States.ShootConscriptGun)),
                activationStateMachineName = "Weapon",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseRechargeInterval = 0,
                baseMaxStock = 12,

                rechargeStock = 0,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });

            primarySkillDef1.reloadState = new SerializableEntityStateType(typeof(Reload));
            primarySkillDef1.hasMagazineReloadState = new SerializableEntityStateType(typeof(ReloadFast));
            primarySkillDef1.reloadInterruptPriority = InterruptPriority.Any;
            primarySkillDef1.graceDuration = 0.5f;
            Config.ConfigureSkillDef(primarySkillDef1, ConscriptConfig.SectionBody, "M1 Gun");

            MagazineSkillDef primarySkillDef2 = Skills.CreateSkillDef<MagazineSkillDef>(new SkillDefInfo
            {
                skillName = "conscript_flak",
                skillNameToken = TOKEN_PREFIX + "PRIMARY_FLAK_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "PRIMARY_FLAK_DESCRIPTION",
                //keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(States.ShootFlak)),
                activationStateMachineName = "Weapon",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseRechargeInterval = 0,
                baseMaxStock = 4,

                rechargeStock = 0,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });

            primarySkillDef2.reloadState = new SerializableEntityStateType(typeof(FlakReload));
            primarySkillDef2.hasMagazineReloadState = new SerializableEntityStateType(typeof(ReloadFast));
            primarySkillDef2.reloadInterruptPriority = InterruptPriority.Any;
            primarySkillDef2.graceDuration = 0.5f;
            Config.ConfigureSkillDef(primarySkillDef2, ConscriptConfig.SectionBody, "M1 Flak");

            Skills.AddPrimarySkills(bodyPrefab, primarySkillDef1, primarySkillDef2);
        }

        private void AddSecondarySkills()
        {
            TargetOverlaySkillDef secondarySkillDef1 = Skills.CreateSkillDef<TargetOverlaySkillDef>(new SkillDefInfo
            {
                skillName = "conscript_molotov",
                skillNameToken = TOKEN_PREFIX + "SECONDARY_MOLOTOV_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "SECONDARY_MOLOTOV_DESCRIPTION",
                //keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowMolotov)),
                activationStateMachineName = "Weapon2",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseRechargeInterval = 6f,
                baseMaxStock = 2,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = true,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });
            secondarySkillDef1.hudOverlayPrefab = ConscriptAssets.TerrorDroneHudOverlayPrefab;
            Config.ConfigureSkillDef(secondarySkillDef1, ConscriptConfig.SectionBody, "M2 Molotov");

            //here is a basic skill def with all fields accounted for
            TargetOverlaySkillDef secondarySkillDef2 = Skills.CreateSkillDef<TargetOverlaySkillDef>(new SkillDefInfo
            {
                skillName = "conscript_terrorDrone",
                skillNameToken = TOKEN_PREFIX + "SECONDARY_TERROR_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "SECONDARY_TERROR_DESCRIPTION",
                //keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texSecondaryIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(ThrowTerrorDrone)),
                activationStateMachineName = "Weapon2",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseRechargeInterval = 6f,
                baseMaxStock = 2,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = true,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
            });
            secondarySkillDef2.hudOverlayPrefab = ConscriptAssets.TerrorDroneHudOverlayPrefab;
            Config.ConfigureSkillDef(secondarySkillDef2, ConscriptConfig.SectionBody, "M2 Terror Drone");

            Skills.AddSecondarySkills(bodyPrefab, secondarySkillDef1, secondarySkillDef2);
        }

        private void AddUtiitySkills()
        {
            //here's a skilldef of a typical movement skill.
            SkillDef utilitySkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "conscript_march",
                skillNameToken = TOKEN_PREFIX + "UTILITY_MARCH_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "UTILITY_MARCH_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texUtilityIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(HellMarch)),
                activationStateMachineName = "Body",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseRechargeInterval = 10f,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = true,

                isCombatSkill = false,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = true,
            });
            Config.ConfigureSkillDef(utilitySkillDef1, ConscriptConfig.SectionBody, "M3 March");

            Skills.AddUtilitySkills(bodyPrefab, utilitySkillDef1);
        }

        private void AddSpecialSkills()
        {
            //a basic skill. some fields are omitted and will just have default values
            SkillDef specialSkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "conscript_garrison",
                skillNameToken = TOKEN_PREFIX + "SPECIAL_GARRISON_NAME",
                skillDescriptionToken = TOKEN_PREFIX + "SPECIAL_GARRISON_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texSpecialIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(SpawnGarrison)),
                //setting this to the "weapon2" EntityStateMachine allows us to cast this skill at the same time primary, which is set to the "weapon" EntityStateMachine
                activationStateMachineName = "Weapon",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseMaxStock = 1,
                baseRechargeInterval = 24f,

                isCombatSkill = true,
                mustKeyPress = false,
            });
            Config.ConfigureSkillDef(specialSkillDef1, ConscriptConfig.SectionBody, "M4 Garrison");

            Skills.AddSpecialSkills(bodyPrefab, specialSkillDef1);
        }

        private void AddRecolorSkills()
        {
            if (characterModelObject.GetComponent<SkinRecolorController>().Recolors == null)
            {
                Log.Warning("Could not load recolors. types not serialized?");
                return;
            }

            SkillFamily recolorFamily = Modules.Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, "LOADOUT_SKILL_COLOR", "Recolor", true).skillFamily;
            
            SkinRecolorController recolorController = characterModelObject.GetComponent<SkinRecolorController>();

            List<SkillDef> skilldefs = new List<SkillDef> {
                recolorController.createRecolorSkillDef("Red"),
                recolorController.createRecolorSkillDef("Blue"),
                recolorController.createRecolorSkillDef("Green"),
                recolorController.createRecolorSkillDef("Yellow"),
                recolorController.createRecolorSkillDef("Orange"),
                recolorController.createRecolorSkillDef("Cyan"),
                recolorController.createRecolorSkillDef("Purple"),
                recolorController.createRecolorSkillDef("Pink"),
            };

            if (General.GeneralConfig.NewColor.Value)
            {
                skilldefs.Add(recolorController.createRecolorSkillDef("Black"));
            }
            for (int i = 0; i < skilldefs.Count; i++)
            {

                Modules.Skills.AddSkillToFamily(recolorFamily, skilldefs[i], null/*i == 0 ? null : null*/);

                AddCssPreviewSkill(i, recolorFamily, skilldefs[i]);
            }

            FinalizeCSSPreviewDisplayController();
        }
        #endregion skills

        #region skins
        public override void InitializeSkins()
        {
            ModelSkinController skinController = prefabCharacterModel.gameObject.GetComponent<ModelSkinController>();
            ChildLocator childLocator = prefabCharacterModel.GetComponent<ChildLocator>();

            CharacterModel.RendererInfo[] defaultRendererinfos = prefabCharacterModel.baseRendererInfos;

            List<SkinDef> skins = new List<SkinDef>();

            #region DefaultSkin
            //this creates a SkinDef with all default fields
            SkinDef defaultSkin = Skins.CreateSkinDef("DEFAULT_SKIN",
                assetBundle.LoadAsset<Sprite>("texMainSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            //these are your Mesh Replacements. The order here is based on your CustomRendererInfos from earlier
            //pass in meshes as they are named in your assetbundle
            //currently not needed as with only 1 skin they will simply take the default meshes
            //uncomment this when you have another skin
            //defaultSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshHenrySword",
            //    "meshHenryGun",
            //    "meshHenry");

            //add new skindef to our list of skindefs. this is what we'll be passing to the SkinController
            skins.Add(defaultSkin);
            #endregion

            //uncomment this when you have a mastery skin
            #region MasterySkin

            ////creating a new skindef as we did before
            //SkinDef masterySkin = Modules.Skins.CreateSkinDef(HENRY_PREFIX + "MASTERY_SKIN_NAME",
            //    assetBundle.LoadAsset<Sprite>("texMasteryAchievement"),
            //    defaultRendererinfos,
            //    prefabCharacterModel.gameObject,
            //    HenryUnlockables.masterySkinUnlockableDef);

            ////adding the mesh replacements as above. 
            ////if you don't want to replace the mesh (for example, you only want to replace the material), pass in null so the order is preserved
            //masterySkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshHenrySwordAlt",
            //    null,//no gun mesh replacement. use same gun mesh
            //    "meshHenryAlt");

            ////masterySkin has a new set of RendererInfos (based on default rendererinfos)
            ////you can simply access the RendererInfos' materials and set them to the new materials for your skin.
            //masterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("matHenryAlt");
            //masterySkin.rendererInfos[1].defaultMaterial = assetBundle.LoadMaterial("matHenryAlt");
            //masterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("matHenryAlt");

            ////here's a barebones example of using gameobjectactivations that could probably be streamlined or rewritten entirely, truthfully, but it works
            //masterySkin.gameObjectActivations = new SkinDef.GameObjectActivation[]
            //{
            //    new SkinDef.GameObjectActivation
            //    {
            //        gameObject = childLocator.FindChildGameObject("GunModel"),
            //        shouldActivate = false,
            //    }
            //};
            ////simply find an object on your child locator you want to activate/deactivate and set if you want to activate/deacitvate it with this skin

            //skins.Add(masterySkin);

            #endregion
            
            skinController.skins = skins.ToArray();
        }
        #endregion skins

        //Character Master is what governs the AI of your character when it is not controlled by a player (artifact of vengeance, goobo)
        public override void InitializeCharacterMaster()
        {
            //you must only do one of these. adding duplicate masters breaks the game.

            //if you're lazy or prototyping you can simply copy the AI of a different character to be used
            //Modules.Prefabs.CloneDopplegangerMaster(bodyPrefab, masterName, "Merc");

            //how to set up AI in code
            ConscriptAI.Init(bodyPrefab, masterName);

            //how to load a master set up in unity, can be an empty gameobject with just AISkillDriver components
            //assetBundle.LoadMaster(bodyPrefab, masterName);
        }

        public static bool IsTerrorDroneTargetHit(ref BulletAttack.BulletHit hitInfo, out HurtBox weakHurtBox)
        {
            if (hitInfo.hitHurtBox && hitInfo.hitHurtBox.hurtBoxGroup)
            {
                foreach (HurtBox hurtBox in hitInfo.hitHurtBox.hurtBoxGroup.hurtBoxes)
                {
                    if (hurtBox && hurtBox.damageModifier == (HurtBox.DamageModifier)TERROR_DRONE_HURTBOX && Vector3.ProjectOnPlane(hitInfo.point - hurtBox.transform.position, hitInfo.direction).sqrMagnitude <= HurtBox.sniperTargetRadiusSqr)
                    {
                        weakHurtBox = hurtBox;
                        return true;
                    }
                }
            }
            weakHurtBox = null;
            return false;
        }

        private void AddHooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.EntityStates.Engi.SpiderMine.Detonate.OnEnter += Detonate_OnEnter;
            //On.RoR2.HurtBox.OnEnable += HurtBox_OnEnable;
            //On.RoR2.HurtBox.OnDisable += HurtBox_OnDisable;
            IL.EntityStates.Engi.SpiderMine.ChaseTarget.FixedUpdate += ChaseTarget_FixedUpdate;

            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);
        }

        private void ChaseTarget_FixedUpdate(MonoMod.Cil.ILContext il)
        {
            //if (!this.passedDetonationRadius && magnitude <= ChaseTarget.triggerRadius)
            ILCursor cursor = new ILCursor(il);
            cursor.GotoNext(MoveType.After,
                instruction => instruction.MatchBrtrue(out _),
                instruction => instruction.MatchLdloc(2),
                instruction => instruction.MatchLdsfld<ChaseTarget>(nameof(ChaseTarget.triggerRadius))
                );
            cursor.Index--; 
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.EmitDelegate<Func<float, ChaseTarget, float>>(fuckWithMagnitude);
            cursor.Emit(OpCodes.Stloc_2);
            cursor.Emit(OpCodes.Ldloc_2);
        }

        private float fuckWithMagnitude(float origMagnitude, ChaseTarget self)
        {
            if (self.outer.customName.Contains("ConscriptTerrorDroneESM"))
            {
                //subtracting from detected distance so it detonates sooner (triggerRadius is static so I can't change it for just this drone)
                return origMagnitude - 10;
            }

            return origMagnitude;
        }

        //private void HurtBox_OnDisable(On.RoR2.HurtBox.orig_OnDisable orig, HurtBox self)
        //{
        //    orig(self);
        //    if (self.damageModifier == (HurtBox.DamageModifier)69)
        //    {
        //        readOnlyTerrorDroneHurtboxes.Remove(self);
        //    }
        //}

        //private void HurtBox_OnEnable(On.RoR2.HurtBox.orig_OnEnable orig, HurtBox self)
        //{
        //    orig(self);
        //    if(self.damageModifier == (HurtBox.DamageModifier)69)
        //    {
        //        readOnlyTerrorDroneHurtboxes.Add(self);
        //    }
        //}

        private void Detonate_OnEnter(On.EntityStates.Engi.SpiderMine.Detonate.orig_OnEnter orig, EntityStates.Engi.SpiderMine.Detonate self)
        {
            if (!self.outer.customName.Contains("ConscriptTerrorDroneESM"))
            {
                orig(self);
            }

            self.outer.SetNextState(new Conscript.States.TerrorDrone.JumpOnEnemy());
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, R2API.RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(ConscriptBuffs.armorBuff))
            {
                args.armorAdd += 100;
                args.moveSpeedMultAdd += 0.5f;
            }

            if (sender.HasBuff(ConscriptBuffs.chargeBuff))
            {
                args.armorAdd += ConscriptConfig.M3_March_Armor;
                args.moveSpeedMultAdd += ConscriptConfig.M3_March_Speed;
            }

            if (sender.HasBuff(ConscriptBuffs.magazineBuff) || sender.HasBuff(ConscriptBuffs.garrisonBuff))
            {
                args.regenMultAdd += ConscriptConfig.M4_Garrison_Regen;
            }
        }
    }
}