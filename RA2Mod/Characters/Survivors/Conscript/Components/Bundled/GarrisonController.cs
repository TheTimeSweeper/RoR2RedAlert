using RoR2.UI;
using RoR2;
using RoR2.HudOverlay;
using System;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class GarrisonController : MonoBehaviour
    {
        [SerializeField]
        private CharacterBody thisBody;
        [SerializeField]
        private GenericOwnership ownershipComponent;
        [SerializeField]
        private HealthComponent healthComponent;
        [SerializeField]
        private TeamFilter teamFilter;
        [SerializeField]
        private GarrisonModel model;

        private OverlayController _overlayController;

        private float _gracePeriod = 0.2f;

        public void Init(CharacterBody characterBody, TeamIndex teamIndex)
        {
            thisBody.baseMaxHealth = characterBody.maxHealth * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.baseMaxShield = characterBody.maxShield * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.armor = characterBody.armor;
            ownershipComponent.ownerObject = characterBody.gameObject;
            teamFilter.teamIndex = teamIndex;
        }

        public void ShowGarrison(bool shouldShow)
        {
            model.Show(shouldShow);

            if (shouldShow)
            {
                if (Physics.Raycast(base.transform.position, Vector3.down, out RaycastHit raycastHit, 500f, LayerIndex.world.mask))
                {
                    base.transform.position = raycastHit.point;
                    base.transform.up = raycastHit.normal;
                }
            }
        }

        private void Start()
        {
            CreateHealthBarOverlay();
        }

        private void FixedUpdate()
        {
            ////if needs to happen after start
            //if (_overlayController == null)
            //{
            //    CreateHealthBarOverlay();
            //}
            
            _gracePeriod -= Time.fixedDeltaTime;
            if (_gracePeriod > 0)
                return;

            healthComponent.health -= (healthComponent.body.maxHealth / ConscriptConfig.M4_Garrison_Duration) * Time.fixedDeltaTime;
            if(healthComponent.health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void CreateHealthBarOverlay()
        {
            _overlayController = HudOverlayManager.AddOverlay(ownershipComponent.ownerObject, new OverlayCreationParams
            {
                prefab = ConscriptAssets.GarrisonHealthBarPrefab,
                childLocatorEntry = "BottomLeftCluster"
            });

            _overlayController.onInstanceAdded += OverlayController_onInstanceAdded;
        }

        private void OverlayController_onInstanceAdded(OverlayController controller, GameObject instanceObject)
        {
            instanceObject.GetComponentInChildren<HealthBar>().source = healthComponent;

            if (Input.GetKey(KeyCode.G))
            {
                instanceObject.transform.localPosition = Vector3.zero;
                instanceObject.transform.localRotation = Quaternion.identity;
                instanceObject.transform.localScale = Vector3.one;
            }
        }

        public void Die()
        {
            healthComponent.health = 0;
        }

        private void OnDestroy()
        {
            if (_overlayController != null)
            {
                _overlayController.onInstanceAdded -= OverlayController_onInstanceAdded;
                HudOverlayManager.RemoveOverlay(_overlayController);
            }
        }
    }
}
