using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power", menuName = "Power-Up")]
public class ScriptableObjPower : ScriptableObject
{
    [SerializeField] private string PowerName;
    [SerializeField] private int ID;
    [SerializeField] private Sprite PowerImg;

    public int PowerID { get { return ID; } }
    public Sprite PowerSprite { get { return PowerImg; } }
    public string powname { get { return PowerName; } }
    
}
