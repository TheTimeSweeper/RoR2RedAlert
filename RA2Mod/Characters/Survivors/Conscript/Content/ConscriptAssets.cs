using RoR2;
using UnityEngine;
using RA2Mod.Modules;
using System;
using RoR2.Projectile;
using UnityEngine.AddressableAssets;
using R2API;
using UnityEngine;
using EntityStates;
using RA2Mod.General.Components;
using System.Collections;
using System.Collections.Generic;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptAssets
    {
        public static GameObject Garrison;
        public static GameObject Molotov;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;

            Garrison = assetBundle.LoadAsset<GameObject>("Garrison").DebugClone(true);
            Garrison.GetComponent<BuffWard>().buffDef = ConscriptBuffs.magazineBuff;
            Garrison.GetComponent<BuffWard>().expireDuration = ConscriptConfig.M4_Garrison_Duration;

            Molotov = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Molotov/MolotovSingleProjectile.prefab").WaitForCompletion();
        }
    }
}
