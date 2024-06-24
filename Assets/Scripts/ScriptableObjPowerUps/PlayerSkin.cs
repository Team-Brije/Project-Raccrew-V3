using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkin", menuName = "Skin")]
public class PlayerSkin : ScriptableObject
{
    public Material targetMaterial;
    public Color targetColor;
    public Mesh targetMesh;
}
