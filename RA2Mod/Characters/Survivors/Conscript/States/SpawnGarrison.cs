using RA2Mod.Modules.BaseStates;
using RA2Mod.Survivors.Conscript.Components;
using RA2Mod.Survivors.Conscript.Components.Bundled;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.States
{
    public class SpawnGarrison : BaseTimedSkillState
    {
        public override float TimedBaseDuration => 1;
        public override float TimedBaseCastStartPercentTime => 1;
        
        public override void OnEnter()
        {
            base.OnEnter();

            Ray aimray = GetAimRay();
            Vector3 pos = aimray.origin + aimray.direction * ConscriptConfig.M4_Garrison_Range * 0.3f; 
            if (Physics.Raycast(GetAimRay(), out RaycastHit hitInfo, ConscriptConfig.M4_Garrison_Range*0.3f, RoR2.LayerIndex.world.mask))
            {
                pos = hitInfo.point+ Vector3.up * 2;
            }

            if(NetworkServer.active)
            {
                GameObject garrison = UnityEngine.Object.Instantiate(ConscriptAssets.Garrison, pos, Quaternion.identity);

                GarrisonController garrisonController = garrison.GetComponent<GarrisonController>();

                NetworkServer.Spawn(garrison);

                garrisonController.RpcInit(gameObject);

                characterBody.master.AddDeployable(garrison.GetComponent<Deployable>(), DeployableSlot.PowerWard);
            }
        }
    }
}
