﻿using BepInEx;
using R2API.Utils;
using RA2Mod.General;
using RA2Mod.Survivors.Chrono;
using RA2Mod.Survivors.Conscript;
using RA2Mod.Survivors.Desolator;
using RA2Mod.Survivors.GI;
using RA2Mod.Survivors.MCV;
using RA2Mod.Survivors.Tesla;
using RoR2;
using System;
using System.Security;
using System.Security.Permissions;
using UnityEngine;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

[assembly: HG.Reflection.SearchableAttribute.OptIn]

namespace RA2Mod
{
    [BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.johnedwa.RTAutoSprintEx", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.cwmlolzlz.skills", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.xoxfaby.BetterUI", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.KomradeSpectre.Aetherium", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.ThinkInvisible.TinkersSatchel", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.DestroyedClone.AncientScepter", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.DrBibop.VRAPI", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.weliveinasociety.CustomEmotesAPI", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class RA2Plugin : BaseUnityPlugin
    {
        public const string MODUID = "com.TheTimesweeper.RedAlert";
        public const string MODNAME = "Red Alert";
        public const string MODVERSION = "3.3.1";

        public const string DEVELOPER_PREFIX = "HABIBI";

        public static RA2Plugin instance;

        public RA2Plugin()
        {
            if (Log._startTime == default(System.DateTime))
            {
                Log._startTime = System.DateTime.Now;
            }
        }

        void Awake()
        {
            instance = this;
            Log.Init(Logger);

            //async load hopoo shader
            Modules.Materials.Init();

            GeneralConfig.Init();
            GeneralCompat.Init();
            GeneralStates.Init();
            GeneralHooks.Init();
            GeneralTokens.Init();
            Modules.Language.PrintOutput("shared.txt");

            Log.CurrentTime("START " + MODVERSION);

            Modules.Language.Init();

            new TeslaTrooperSurvivor().Initialize();
            new DesolatorSurvivor().Initialize();
            new ChronoSurvivor().Initialize();
            new ConscriptSurvivor().Initialize();
            new GISurvivor().Initialize();
            new MCVSurvivor().Initialize();
            
            new Modules.ContentPacks().Initialize();
            //sprite on loading bar
            On.LoadingScreenCanvas.Awake += LoadingScreenCanvas_Awake;

            if (GeneralConfig.Debug.Value)
            {
                RoR2.RoR2Application.onLoad += PrintLoadTime;
            }
        }

        private void PrintLoadTime()
        {
            Log.CurrentTime("LOAD FINISHED ");
            Log.AllTimes();
        }

        private void LoadingScreenCanvas_Awake(On.LoadingScreenCanvas.orig_Awake orig, LoadingScreenCanvas self)
        {
            PickRandomObjectOnAwake miniScene = self.GetComponentInChildren<PickRandomObjectOnAwake>();
            AssetBundle loadingBundle = Modules.Asset.LoadAssetBundle("ra2loading");

            Array.Resize(ref miniScene.ObjectsToSelect, miniScene.ObjectsToSelect.Length + 1);
            miniScene.ObjectsToSelect[miniScene.ObjectsToSelect.Length - 1] = Instantiate(loadingBundle.LoadAsset<GameObject>("TeslaTrooperSprite"), miniScene.transform);
            orig(self);
        }
    }
}
