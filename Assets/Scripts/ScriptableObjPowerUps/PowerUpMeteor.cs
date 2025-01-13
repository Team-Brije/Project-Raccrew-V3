using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Meteor Like PowerUp")]
public class PowerUpMeteor : ScriptableObjPower
{
    public GameObject newPlayerPos;
    public int duration;
    public GameObject area;
    
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerPowerupStorage>().ChangePosition(newPlayerPos, duration);
    }
}