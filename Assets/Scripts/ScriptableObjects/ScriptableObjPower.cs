using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power", menuName = "Powers")]
public class ScriptableObjPower : ScriptableObject
{
    public string PowerName;
    public string PowerID;
    public Sprite PowerSprite;
    public GameObject Power;



}
