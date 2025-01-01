using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{

    [RequireComponent(typeof(TeamFilter))]
    public class SkillRefresherWard : MonoBehaviour
    {
        [SerializeField]
        private float searchInterval = 0.2f;

        [SerializeField]
        private float primaryResetInterval = 0.2f;

        [SerializeField]
        private float radius = 30;
    }
}
