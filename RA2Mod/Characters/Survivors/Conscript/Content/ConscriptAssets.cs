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
using RoR2.UI;
using RA2Mod.Survivors.Conscript.Components;
using UnityEngine.UI;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptAssets
    {
        public static GameObject Garrison;
        public static GameObject GarrisonMasterPrefab;
        public static GameObject GarrisonHealthBarPrefab;
        public static GameObject Molotov;
        public static GameObject RunSpeedEffect;
        public static AsyncAsset<GameObject> blastEffect;
        public static GameObject TerrorDronePrefab;
        public static GameObject TerrorDroneHudOverlayPrefab;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;

            CreateGarrison();

            CreateGarrisonHealthBar();

            WheewBoyMakeATerrorDrone();

            RunSpeedEffect = assetBundle.LoadAsset<GameObject>("fxRunSpeedLines").DebugClone(true);
            Content.CreateAndAddEffectDef(RunSpeedEffect);

            //todo async
            blastEffect = Modules.Asset.AddAsyncAsset<GameObject>("RoR2/Base/LemurianBruiser/OmniExplosionVFXLemurianBruiserFireballImpact.prefab");
            CreateMolotov();

            CreateTerrorDroneTargetViewer();

            //blast = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/OmniExplosionVFXLemurianBruiserFireballImpact.prefab").WaitForCompletion();

            _assetBundle.LoadAssetAsync<EntityStateConfiguration>("escConscriptJumpOnEnemy", (resultESC) =>
            {       
                Content.AddEntityStateConfiguration(resultESC);
            });
        }

        private static void CreateGarrisonHealthBar()
        {
            Asset.LoadAssetAsync<GameObject>("RoR2/Base/UI/HUDSimple.prefab", (hudResult) =>
            {
                GarrisonHealthBarPrefab = hudResult.transform.Find("MainContainer/MainUIArea/SpringCanvas/BottomLeftCluster/BarRoots").gameObject.InstantiateClone("GarrisonHealthBarRoots", false);
                UnityEngine.Object.Destroy(GarrisonHealthBarPrefab.GetComponent<VerticalLayoutGroup>());
                UnityEngine.Object.Destroy(GarrisonHealthBarPrefab.transform.Find("LevelDisplayCluster").gameObject);
                GarrisonHealthBarPrefab.transform.Find("HealthbarRoot").localPosition = new Vector3(0, -26.6f, 0);
                GarrisonHealthBarPrefab.transform.Find("HealthbarRoot").GetComponent<RectTransform>().sizeDelta = new Vector2(360, 24);
                //GarrisonHealthBarPrefab.transform.Find("HealthbarRoot")

            });
        }

        private static void CreateTerrorDroneTargetViewer()
        {
            TerrorDroneHudOverlayPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Railgunner/RailgunnerScopeHeavyOverlay.prefab").WaitForCompletion().InstantiateClone("ConscriptHudOverlay", false);
            
            TerrorDroneHudOverlayPrefab.transform.Find("ScopeOverlay").gameObject.SetActive(false);

            UnityEngine.Object.Destroy(TerrorDroneHudOverlayPrefab.transform.Find("SniperTargetViewer").GetComponent<SniperTargetViewer>());

            TerrorDroneTargetHudViewer targetViewer = TerrorDroneHudOverlayPrefab.gameObject.AddComponent<TerrorDroneTargetHudViewer>();
            targetViewer.visualizerPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Railgunner/RailgunnerSniperTargetVisualizerHeavy.prefab").WaitForCompletion();
            targetViewer.pointViewer = TerrorDroneHudOverlayPrefab.transform.Find("SniperTargetViewer").GetComponent<PointViewer>();
        }

        private static void CreateMolotov()
        {
            _assetBundle.LoadAssetAsync("Molotov", (Action<GameObject>)((resultMolotov) =>
            {
                Molotov = resultMolotov.DebugClone(true);
                GameObject equipMolotov = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Molotov/MolotovSingleProjectile.prefab").WaitForCompletion();

                Molotov.GetComponent<ProjectileController>().ghostPrefab = equipMolotov.GetComponent<ProjectileController>().ghostPrefab;

                Molotov.GetComponentInChildren<TerrorDroneHurtBox>().trackedTarget = Molotov.AddComponent<TerrorDroneTrackedTarget>();

                ProjectileImpactExplosion equipProjectileImpact = equipMolotov.GetComponent<ProjectileImpactExplosion>();

                ProjectileImpactExplosion[] projectileImpactComponents = Molotov.GetComponentsInChildren<ProjectileImpactExplosion>();

                GameObject molotovChildProjectile = equipProjectileImpact.childrenProjectilePrefab.InstantiateClone("ConscriptMolotovDotZone", true);
                molotovChildProjectile.transform.GetChild(0).localScale = Vector3.one * 13f;
                ProjectileDotZone projectileDotZone = molotovChildProjectile.GetComponent<ProjectileDotZone>();
                projectileDotZone.lifetime = 3;
                projectileDotZone.fireFrequency = 1;
                projectileDotZone.resetFrequency = 1;
                float dotZoneDamage = 0.5f / (projectileDotZone.lifetime * projectileDotZone.fireFrequency);
                projectileDotZone.damageCoefficient = dotZoneDamage;

                ProjectileImpactExplosion childrenOnImpactComponent = projectileImpactComponents[0];
                childrenOnImpactComponent.childrenProjectilePrefab = molotovChildProjectile;
                childrenOnImpactComponent.impactEffect = equipProjectileImpact.impactEffect;
                childrenOnImpactComponent.blastDamageCoefficient = dotZoneDamage;

                ProjectileImpactExplosion explosionOnHurtComponent = projectileImpactComponents[1];
                explosionOnHurtComponent.explosionEffect = blastEffect;
                explosionOnHurtComponent.impactEffect = blastEffect;


                Content.NetworkAndAddProjectilePrefab(Molotov);
                Content.AddCharacterBodyPrefab(Molotov);
            }));
        }
        
        private static void CreateGarrison()
        {
            Garrison = _assetBundle.LoadAsset<GameObject>("GarrisonBody");
            BuffWard garrisonBuffWard = Garrison.GetComponent<BuffWard>();
            garrisonBuffWard.buffDef = ConscriptBuffs.magazineBuff;
            garrisonBuffWard.expireDuration = ConscriptConfig.M4_Garrison_Duration;
            garrisonBuffWard.radius = ConscriptConfig.M4_Garrison_Range;
            Garrison.GetComponent<SkillRefresherWard>().Radius = ConscriptConfig.M4_Garrison_Range;
            Material wallMaterial = Addressables.LoadAssetAsync<Material>("RoR2/Base/WardOnLevel/matWarbannerSphereIndicator2.mat").WaitForCompletion();
            wallMaterial = new Material(wallMaterial);
            wallMaterial.SetFloat("_RimStrength", 0.35f);
            wallMaterial.SetFloat("_Cull", 2f);
            Garrison.transform.Find("Scaler/mdlGarrison/Bunker Walls").GetComponent<MeshRenderer>().sharedMaterial =
                wallMaterial;
            Garrison.transform.Find("Scaler/mdlGarrison/Bunker Walls2").GetComponent<MeshRenderer>().sharedMaterial =
                wallMaterial;
            Garrison.transform.Find("Scaler/mdlGarrison/Bunker Wall Low").GetComponent<MeshRenderer>().sharedMaterial =
                Addressables.LoadAssetAsync<Material>("RoR2/Base/WardOnLevel/matWarbannerSphereIndicator.mat").WaitForCompletion();
            Garrison.transform.Find("Scaler/mdlGarrison/Bunker corners").GetComponent<MeshRenderer>().sharedMaterial.SetHopooMaterial();

            Content.AddNetworkedObject(Garrison, true);
            Content.AddCharacterBodyPrefab(Garrison);
            //GarrisonMasterPrefab = _assetBundle.LoadAsset<GameObject>("GarrisonMaster");
            //PrefabAPI.RegisterNetworkPrefab(GarrisonMasterPrefab);
            //Content.AddMasterPrefab(GarrisonMasterPrefab);
        }

        private static void WheewBoyMakeATerrorDrone()
        {
            Asset.LoadAssetAsync<GameObject>("RoR2/Base/Engi/SpiderMine.prefab", (result) =>
            {
                TerrorDronePrefab = result.InstantiateClone("ConscriptTerrorDrone", true);

                Asset.LoadAssetAsync<GameObject>(_assetBundle, "TerrorDroneHurtBox", (hurtBox) =>
                {
                    Transform NewHurtBox = hurtBox.InstantiateClone("TerrorDroneHurtBox", false).transform;
                    NewHurtBox.SetParent(TerrorDronePrefab.transform);
                    NewHurtBox.localPosition = Vector3.zero;
                    NewHurtBox.localRotation = Quaternion.identity;
                    //HurtBoxTransform.localScale = Vector3.one;
                    NewHurtBox.gameObject.SetActive(false);

                                                                              //if you wanna use this code pleas change number thank
                    NewHurtBox.GetComponent<HurtBox>().damageModifier = (HurtBox.DamageModifier)ConscriptSurvivor.TERROR_DRONE_HURTBOX;
                    TerrorDroneTrackedTarget terrorDroneTrackedTarget = TerrorDronePrefab.AddComponent<TerrorDroneTrackedTarget>();
                    NewHurtBox.GetComponent<TerrorDroneHurtBox>().trackedTarget = terrorDroneTrackedTarget;

                    TerrorDronePrefab.AddComponent<ChildLocator>().transformPairs = new ChildLocator.NameTransformPair[]
                    {
                        new ChildLocator.NameTransformPair
                        {
                            name = "HurtBox",
                            transform = NewHurtBox
                        }
                    };

                    TerrorDronePrefab.GetComponent<EntityStateMachine>().customName = "ConscriptTerrorDroneESM";
                    UnityEngine.Object.Destroy(TerrorDronePrefab.GetComponent<ProjectileDeployToOwner>());
                    UnityEngine.Object.Destroy(TerrorDronePrefab.GetComponent<Deployable>());
                    //Deployable deployable = TerrorDronePrefab.GetComponent<Deployable>();
                    //deployable.onUndeploy.RemoveAllListeners();
                    //deployable.onUndeploy.AddListener(deployable.gameObject, ((Action<GameObject>)UnityEngine.Object.Destroy).Method); //did not work

                    DestroyOnTimer destroyOnTimer = TerrorDronePrefab.AddComponent<DestroyOnTimer>();
                    destroyOnTimer.duration = ConscriptConfig.M2_TerrorDrone_LifeDuration;
                    destroyOnTimer.enabled = false;

                    Content.AddProjectilePrefab(TerrorDronePrefab); 
                });
            });
        }
    }
}
