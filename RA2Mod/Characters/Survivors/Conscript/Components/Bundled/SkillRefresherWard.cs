using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
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
        public float Radius { get => radius; set => radius = value; }

        private List<SkillLocator> _currentBodies = new List<SkillLocator>();
        private List<SkillLocator> _alreadyAffectedBodies = new List<SkillLocator>();

        private float _searchTim;
        private float _primaryResetTim;
        private TeamFilter _teamFilter;

        private void Awake()
        {
            this._teamFilter = base.GetComponent<TeamFilter>();
        }

        void FixedUpdate()
        {
            _searchTim -= Time.fixedDeltaTime;
            if (_searchTim <= 0)
            {
                _searchTim = searchInterval;
                SearchForTeamBodies();
            }

            _primaryResetTim -= Time.fixedDeltaTime;
            if (_primaryResetTim <= 0)
            {
                _primaryResetTim = primaryResetInterval;
                ResetPrimaries();
            }
        }

        private void ResetPrimaries()
        {
            for (int i = 0; i < _currentBodies.Count; i++)
            {
                SkillLocator skillLocator = _currentBodies[i];
                if (_currentBodies[i] != null)
                {
                    if (skillLocator.primary != null)
                    {
                        skillLocator.primary.stock = skillLocator.primary.skillDef.requiredStock * 2;
                    }

                    if (!_alreadyAffectedBodies.Contains(_currentBodies[i]) && skillLocator.secondary != null)
                    {
                        _alreadyAffectedBodies.Add(_currentBodies[i]);
                        skillLocator.secondary.stock = skillLocator.secondary.maxStock;
                    }
                }
            }
        }

        private void SearchForTeamBodies()
        {
            var teamComponents = TeamComponent.GetTeamMembers(_teamFilter.teamIndex);
            foreach (var teamComponent in teamComponents)
            {
                if (teamComponent.body && teamComponent.TryGetComponent(out SkillLocator skillLocator))
                {
                    if (Vector3.SqrMagnitude(teamComponent.transform.position - transform.position) > radius * radius)
                    {
                        _currentBodies.Remove(skillLocator);
                    }
                    else
                    {
                        _currentBodies.Add(skillLocator);
                    }
                }
            }
        }
    }
}
