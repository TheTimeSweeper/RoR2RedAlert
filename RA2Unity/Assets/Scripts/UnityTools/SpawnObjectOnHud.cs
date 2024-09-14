using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnHud : MonoBehaviour
{
    [System.Serializable]
    public class Spawn
    {
        public GameObject objectToSpawn;
        public string transformPath = "MainContainer/MainUIArea/CrosshairCanvas";
        public GameObject spawnedInstance;
    }

    [SerializeField]
    private Spawn[] spawns;

    public void OnInstantiated()
    {
        SpawnLaterIG();
    }

    private void SpawnLaterIG()
    {
        Debug.Log("uh");
        for (int i = 0; i < spawns.Length; i++)
        {
            spawns[i].spawnedInstance = Instantiate(spawns[i].objectToSpawn, transform.GetChild(0).Find(spawns[i].transformPath));
        }
    }
}
