using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Self Assigned PowerUp")]
public class PowerUpSelf : ScriptableObjPower
{
    public enum AbilityType { Speed,Scale,Dash };
    public AbilityType abilityType;
    public float Speed;
    public int duration;
    public float Scale;
    public Material materialChange;

    public override void Apply(GameObject target)
    {
        if(abilityType == AbilityType.Speed) { 
            target.GetComponent<PlayerPowerupStorage>().ChangeSpeed(Speed, duration); 

        }

        if(abilityType == AbilityType.Scale) { 
            target.GetComponent<PlayerPowerupStorage>().ChangeScale(Scale, duration);
            target.GetComponent<PlayerPowerupStorage>().ChangeSpeed(Speed, duration);
        }
    }
}
