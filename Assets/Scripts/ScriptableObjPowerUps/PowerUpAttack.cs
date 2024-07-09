using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Attack Based Powerup")]
public class PowerUpAttack : ScriptableObjPower
{
    public string AnimationName;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerPowerupStorage>().ResetObjects();
        target.GetComponent<PlayerPowerupStorage>().hasAnim = true;
        target.GetComponent<PlayerPowerupStorage>().AnimName = AnimationName;
        //target.GetComponent<PlayerPowerupStorage>().StartAnim(AnimationName);
    }
}
