using RA2Mod.Modules.BaseStates;
using RA2Mod.Survivors.Conscript.Components;
using RA2Mod.Survivors.Conscript.Components.Bundled;
using RoR2;
using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.States
{
    public class SpawnGarrison : BaseTimedSkillState
    {
        public override float TimedBaseDuration => 1;
        public override float TimedBaseCastStartPercentTime => 1;

        private Vector3 spawnPosition;
        
        public override void OnEnter()
        {
            base.OnEnter();

            //authority will serialize the spawn position from its point of view so non-authority can read it
            if (isAuthority)
            {
                Ray aimray = GetAimRay();
                spawnPosition = aimray.origin + aimray.direction * ConscriptConfig.M4_Garrison_Range * 0.3f;
                if (Physics.Raycast(GetAimRay(), out RaycastHit hitInfo, ConscriptConfig.M4_Garrison_Range * 0.3f, RoR2.LayerIndex.world.mask))
                {
                    spawnPosition = hitInfo.point + Vector3.up * 2;
                }
            }

            if(NetworkServer.active)
            {
                //anyone reading this, don't do this. just make your spawned thing a body and give it a master and do mastersummon.perform
                GameObject garrison = UnityEngine.Object.Instantiate(ConscriptAssets.Garrison, spawnPosition, Quaternion.identity);
                NetworkServer.Spawn(garrison);

                GarrisonController garrisonController = garrison.GetComponent<GarrisonController>();
                garrisonController.RpcInit(gameObject);

                characterBody.master.AddDeployable(garrison.GetComponent<Deployable>(), DeployableSlot.PowerWard);

                //if (characterBody.master)
                //{
                //    CharacterMaster characterMaster = new MasterSummon
                //    {
                //        masterPrefab = ConscriptAssets.GarrisonMasterPrefab,
                //        position = spawnPosition,
                //        rotation = Quaternion.identity,
                //        summonerBodyObject = gameObject,
                //        ignoreTeamMemberLimit = true,
                //        //preSpawnSetupCallback = callback,
                //        //inventoryToCopy = characterBody.inventory
                //    }.Perform();
                //    //Deployable deployable = characterMaster.gameObject.AddComponent<Deployable>();
                //    //deployable.onUndeploy = new UnityEvent();
                //    Deployable deployable = characterMaster.gameObject.GetComponent<Deployable>();
                //    deployable.onUndeploy.AddListener(new UnityAction(characterMaster.TrueKill));
                //    characterBody.master.AddDeployable(deployable, DeployableSlot.PowerWard);
                //}
            }
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
            writer.Write(spawnPosition);
        }
        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            spawnPosition = reader.ReadVector3();
        }
    }
}
