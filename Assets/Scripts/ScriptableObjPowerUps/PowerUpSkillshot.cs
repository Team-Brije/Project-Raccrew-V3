using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Skillshot Based PowerUp")]
public class PowerUpSkillshot : ScriptableObjPower
{
    public GameObject BulletToSpawn;
    public GameObject Trajectory;
    public override void Apply(GameObject target)
    {
        Debug.Log("Spawnea Un Proyectil");
    }
}
