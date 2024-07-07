using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Self Assigned PowerUp")]
public class PowerUpSelf : ScriptableObjPower
{
    public float Speed;
    public int duration;
    public Material materialChange;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerPowerupStorage>().ChangeSpeed(Speed, duration);
    }
}
