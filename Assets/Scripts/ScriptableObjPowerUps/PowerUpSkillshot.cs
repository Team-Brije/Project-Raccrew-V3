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
        target.GetComponent<PlayerPowerupStorage>().ID = 1;
        target.GetComponent<PlayerPowerupStorage>().hasobject = false;
        target.GetComponent<PlayerPowerupStorage>().SetObjects(BulletToSpawn, Trajectory);
        target.GetComponent<PlayerPowerupStorage>().SpawnObject();
    }
}
