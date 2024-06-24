using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Spawn Based PowerUp")]
public class PowerUpSpawn : ScriptableObjPower
{
    public GameObject PrefabToSpawn;
    public override void Apply(GameObject target)
    {
        
        Debug.Log("Spawnea Algo");
    }
}
