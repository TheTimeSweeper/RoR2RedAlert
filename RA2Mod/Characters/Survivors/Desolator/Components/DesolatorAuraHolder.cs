using RA2Mod.Survivors.Chrono.Components;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Desolator.Components
{
    public class DesolatorAuraHolder : NetworkBehaviour
    {
        private DesolatorAuraController _spawnedAura = null;

        void Start()
        {
            if (NetworkServer.active)
            {
                SpawnAuraServer();
            }
        }

        [Server]
        public void SpawnAuraServer()
        {
            GameObject spawnedAuraObject = Instantiate(DesolatorAssets.DesolatorAuraPrefab, base.transform.position, Quaternion.identity);
            _spawnedAura = spawnedAuraObject.GetComponent<DesolatorAuraController>();
            NetworkServer.Spawn(spawnedAuraObject);
            RpcSendAura(spawnedAuraObject);
        }

        [ClientRpc]
        private void RpcSendAura(GameObject spawnedAuraObject)
        {
            _spawnedAura = spawnedAuraObject.GetComponent<DesolatorAuraController>();
            if (NetworkServer.active)
            {
                _spawnedAura.RpcSetOwner(gameObject);
            }
        }

        public void ActivateAura()
        {
            if (_spawnedAura.Owner == null)
            {
                if (NetworkServer.active)
                {
                    _spawnedAura.RpcSetOwner(gameObject);
                }
            }

            _spawnedAura?.Activate(true);

            if(_spawnedAura == null)
            {
                Log.Warning("aura is null. help");
            }
        }

        public void DeactivateAura()
        {
            _spawnedAura?.Activate(false);
        }

        void OnDestroy()
        {
            if (_spawnedAura)
            {
                NetworkServer.Destroy(_spawnedAura.gameObject);
            }
        }
    }
}