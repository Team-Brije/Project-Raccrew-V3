using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Self Assigned PowerUp")]
public class PowerUpSelf : ScriptableObjPower
{
    public int Speed;
    public Material materialChange;
    public override void Apply(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
