using RA2Mod.Minions.TeslaTower;
using RoR2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TeslaTowerControllerControllerGuest : TeslaTowerControllerController
{
    private List<GameObject> _allTowers = new List<GameObject>();

    private TeamComponent _teamComponent;

    private float _updateTim = 0.2f;
    private bool _towersUpdated;

    protected override List<GameObject> teslaTowers
    {
        get
        {
            if (!_towersUpdated)
            {
                RefreshTowers();
            }

            _towersUpdated = true;

            return _allTowers;
        }
    }

    private void RefreshTowers()
    {
        _allTowers.Clear();

        ReadOnlyCollection<TeamComponent> teammates = TeamComponent.GetTeamMembers(_teamComponent.teamIndex);

        for (int i = 0; i < teammates.Count; i++)
        {
            if(teammates[i].gameObject.TryGetComponent(out CharacterBody body))
            {
                if(body.bodyIndex == TeslaTowerNotSurvivor.GetBodyIndexSafe() ||
                    body.bodyIndex == TeslaTowerScepter.GetBodyIndexSafe())
                {
                    _allTowers.Add(body.gameObject);
                }
            }
        }

    }

    void Awake()
    {
        _teamComponent = GetComponent<TeamComponent>();
    }
    void FixedUpdate()
    {
        _updateTim -= Time.fixedTime;
        if(_updateTim <= 0)
        {
            _updateTim = 0.2f;

            _towersUpdated = false;
        }
    }
}
