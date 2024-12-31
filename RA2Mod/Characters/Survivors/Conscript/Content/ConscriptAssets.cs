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
using RA2Mod.Survivors.Conscript.Components.Bundled;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptAssets
    {
        public static GameObject Garrison;
        public static GameObject Molotov;
        public static GameObject RunSpeedEffect;
        public static AsyncAsset<GameObject> blastEffect;
        public static GameObject TerrorDronePrefab;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;

            CreateGarrison(assetBundle);

            WheewBoyMakeATerrorDrone();

            RunSpeedEffect = assetBundle.LoadAsset<GameObject>("fxRunSpeedLines").DebugClone(true);
            Content.CreateAndAddEffectDef(RunSpeedEffect);

            //todo async
            blastEffect = Modules.Asset.AddAsyncAsset<GameObject>("RoR2/Base/LemurianBruiser/OmniExplosionVFXLemurianBruiserFireballImpact.prefab");
            CreateMolotov();



            //blast = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/OmniExplosionVFXLemurianBruiserFireballImpact.prefab").WaitForCompletion();

            _assetBundle.LoadAssetAsync<EntityStateConfiguration>("escConscriptJumpOnEnemy", (resultESC) =>
            {
                Content.AddEntityStateConfiguration(resultESC);
            });
        }

        private static void CreateMolotov()
        {
            _assetBundle.LoadAssetAsync("Molotov", (Action<GameObject>)((resultMolotov) =>
            {
                Molotov = resultMolotov.DebugClone(true);

                GameObject equipMolotov = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Molotov/MolotovSingleProjectile.prefab").WaitForCompletion();

                Molotov.GetComponent<ProjectileController>().ghostPrefab = equipMolotov.GetComponent<ProjectileController>().ghostPrefab;

                ProjectileImpactExplosion equipProjectileImpact = equipMolotov.GetComponent<ProjectileImpactExplosion>();

                ProjectileImpactExplosion[] projectileImpactComponents = Molotov.GetComponentsInChildren<ProjectileImpactExplosion>();

                GameObject childMolotov = equipProjectileImpact.childrenProjectilePrefab.InstantiateClone("ConscriptMolotovDotZone", true);
                childMolotov.transform.localScale = Vector3.one * 2.6f;
                ProjectileDotZone projectileDotZone = childMolotov.GetComponent<ProjectileDotZone>();
                projectileDotZone.lifetime = 3;
                projectileDotZone.fireFrequency = 1;
                projectileDotZone.resetFrequency = 1;
                projectileDotZone.damageCoefficient = 0.5f / (projectileDotZone.lifetime * projectileDotZone.fireFrequency);

                ProjectileImpactExplosion childrenOnImpactComponent = projectileImpactComponents[0];
                childrenOnImpactComponent.childrenProjectilePrefab = equipProjectileImpact.childrenProjectilePrefab;
                childrenOnImpactComponent.impactEffect = equipProjectileImpact.impactEffect;

                ProjectileImpactExplosion explosionOnHurtComponent = projectileImpactComponents[1];
                Log.Warning($"blastdone {blastEffect.isDone}");
                explosionOnHurtComponent.explosionEffect = blastEffect;
                explosionOnHurtComponent.impactEffect = blastEffect;

                Content.NetworkAndAddProjectilePrefab(Molotov);
                Content.AddCharacterBodyPrefab(Molotov);
            }));

        }

        private static void CreateGarrison(AssetBundle assetBundle)
        {
            Garrison = assetBundle.LoadAsset<GameObject>("Garrison").DebugClone(true);
            BuffWard garrisonBuffWard = Garrison.GetComponent<BuffWard>();
            garrisonBuffWard.buffDef = ConscriptBuffs.magazineBuff;
            garrisonBuffWard.expireDuration = ConscriptConfig.M4_Garrison_Duration;
            garrisonBuffWard.radius = ConscriptConfig.M4_Garrison_Range;
            Garrison.GetComponent<GarrisonControllerNotBuffWard>().Radius = ConscriptConfig.M4_Garrison_Range;
            Garrison.transform.Find("RangeIndicator/Sphere").GetComponent<MeshRenderer>().sharedMaterial =
                Addressables.LoadAssetAsync<Material>("RoR2/Base/WardOnLevel/matWarbannerSphereIndicator2.mat").WaitForCompletion();
        }

        private static void WheewBoyMakeATerrorDrone()
        {
            Asset.LoadAssetAsync<GameObject>("RoR2/Base/Engi/SpiderMine.prefab", (result) =>
            {
                TerrorDronePrefab = result.InstantiateClone("ConscriptTerrorDrone", true);

                Asset.LoadAssetAsync<GameObject>(_assetBundle, "TerrorDroneHurtBox", (hurtBox) =>
                {
                    Transform HurtBoxTransform = hurtBox.InstantiateClone("TerrorDroneHurtBox", false).transform;
                    HurtBoxTransform.SetParent(TerrorDronePrefab.transform);
                    HurtBoxTransform.localPosition = Vector3.zero;
                    HurtBoxTransform.localRotation = Quaternion.identity;
                    //HurtBoxTransform.localScale = Vector3.one;
                    HurtBoxTransform.gameObject.SetActive(false);

                    //todo terror drone fuck                                  //if you wanna use this code pleas change number thank
                    HurtBoxTransform.GetComponent<HurtBox>().damageModifier = (HurtBox.DamageModifier)ConscriptSurvivor.TERROR_DRONE_HURTBOX;

                    TerrorDronePrefab.AddComponent<ChildLocator>().transformPairs = new ChildLocator.NameTransformPair[]
                    {
                        new ChildLocator.NameTransformPair
                        {
                            name = "HurtBox",
                            transform = HurtBoxTransform
                        }
                    };

                    TerrorDronePrefab.GetComponent<EntityStateMachine>().customName = "ConscriptTerrorDroneESM";
                    UnityEngine.Object.Destroy(TerrorDronePrefab.GetComponent<Deployable>());
                    //Deployable deployable = TerrorDronePrefab.GetComponent<Deployable>();
                    //deployable.onUndeploy.RemoveAllListeners();
                    //deployable.onUndeploy.AddListener(deployable.gameObject, ((Action<GameObject>)UnityEngine.Object.Destroy).Method); //did not work

                    DestroyOnTimer destroyOnTimer = TerrorDronePrefab.AddComponent<DestroyOnTimer>();
                    destroyOnTimer.duration = ConscriptConfig.M2_TerrorDrone_LifeDuration;
                    destroyOnTimer.enabled = false;
                });
            });
        }
    }
}
