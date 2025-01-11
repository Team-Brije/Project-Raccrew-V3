using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectItemStorage : MonoBehaviour
{
    public UIMovementHandler handler;
    public GameObject hat;
    public GameObject Racccoon;
    public GameObject broom;
    public MeshRenderer hatcolor;
    public enum ObjectType { cap, animal, broom, color }

    public ObjectType type;
    
    //TODO : ADD SCRIPTABLE OBJECTS FOR HAT, ANIMAL, AND BROOM;


    public PlayerSkin[] colorOptions;

    public MeshRenderer mesh;

    Material material;

    int arrnum;

    int ID;

    Color color;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        ID = handler.playerId;
        InitializeAttributes();
    }
    
    public void InitializeAttributes()
    {
        arrnum = 0;
        switch (type)
        {
            case ObjectType.cap:
                break;
            case ObjectType.animal:
                break;
            case ObjectType.broom:
                break;
            case ObjectType.color:
                mesh.material.color = colorOptions[arrnum].targetMaterial.color;
                material = colorOptions[arrnum].targetMaterial;
                break;
        }
    }

    public void ChangeAttributeUp()
    {
        switch (type)
        {
            case ObjectType.cap:
                break;
            case ObjectType.animal:
                break;
            case ObjectType.broom:
                break;
            case ObjectType.color:
                if (arrnum >= colorOptions.Length - 1) { arrnum = 0; }
                else { arrnum++; }
                mesh.material.color = colorOptions[arrnum].targetMaterial.color;
                color = colorOptions[arrnum].targetMaterial.color;
                material = colorOptions[arrnum].targetMaterial;
                break;
        }
    }

    public void ChangeAttributeDown()
    {
        switch (type)
        {
            case ObjectType.cap:
                break;
            case ObjectType.animal:
                break;
            case ObjectType.broom:
                break;
            case ObjectType.color:
                if (arrnum <= 0) { arrnum = colorOptions.Length - 1; }
                else { arrnum--; }
                mesh.material.color = colorOptions[arrnum].targetMaterial.color;
                color = colorOptions[arrnum].targetMaterial.color;
                material = colorOptions[arrnum].targetMaterial;
                break;
        }
    }

    public void SetAttribute()
    {
        switch (type)
        {
            case ObjectType.cap:
                break;
            case ObjectType.animal:
                break;
            case ObjectType.broom:
                break;
            case ObjectType.color:
                if (ID == 0) { ColorManagerSingleton.Instance.colorP1 = color; ColorManagerSingleton.Instance.materialP1 = material; }
                if (ID == 1) { ColorManagerSingleton.Instance.colorP2 = color; ColorManagerSingleton.Instance.materialP2 = material; }
                if (ID == 2) { ColorManagerSingleton.Instance.colorP3 = color; ColorManagerSingleton.Instance.materialP3 = material; }
                if (ID == 3) { ColorManagerSingleton.Instance.colorP4 = color; ColorManagerSingleton.Instance.materialP4 = material; }
                hatcolor.material = material;
                break;
        }
    }
}
