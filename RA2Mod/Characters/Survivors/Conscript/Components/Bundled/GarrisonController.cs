using RoR2.UI;
using RoR2;
using RoR2.HudOverlay;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class GarrisonController : NetworkBehaviour
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

        private bool _hasLived;

        [ClientRpc]
        public void RpcInit(GameObject ownerBody)
        {
            CharacterBody characterBody = ownerBody.GetComponent<CharacterBody>();

            if (NetworkServer.active)
            {
                ownershipComponent.ownerObject = characterBody.gameObject;
            }

            thisBody.baseMaxHealth = characterBody.maxHealth * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.baseMaxShield = characterBody.maxShield * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.armor = characterBody.armor;

            teamFilter.teamIndex = characterBody.teamComponent.teamIndex;

            ownerBody.GetComponent<GarrisonHolder>().currentGarrison = this;
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

        private void FixedUpdate()
        {
            if (!_hasLived)
            {
                _hasLived = healthComponent.health > 0;
                return;
            }
            
            if (ownershipComponent.ownerObject != null && _overlayController == null)
            {
                CreateHealthBarOverlay();
            }

            healthComponent.health -= (healthComponent.body.maxHealth / ConscriptConfig.M4_Garrison_Duration) * Time.fixedDeltaTime;

            if (NetworkServer.active)
            {
                if (healthComponent.health <= 0)
                {
                    NetworkServer.DestroyObject(gameObject);
                }
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
