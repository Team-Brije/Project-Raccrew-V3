using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Attack Based Powerup")]
public class PowerUpAttack : ScriptableObjPower
{
    public string AnimationName;
    public override void Apply(GameObject target)
    {
        Debug.Log("Este inicia una Animacion");
    }
}
