using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Spawn Based PowerUp")]
public class PowerUpSpawn : ScriptableObjPower
{
    public GameObject PrefabToSpawn;
    public GameObject placeholderPrefab;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerPowerupStorage>().ID = 0;
        target.GetComponent<PlayerPowerupStorage>().hasobject = false;
        target.GetComponent<PlayerPowerupStorage>().SetObjects(PrefabToSpawn,placeholderPrefab);
        target.GetComponent<PlayerPowerupStorage>().SpawnObject(1);
    }
}
