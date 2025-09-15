using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagerSingleton : MonoBehaviour
{
    private static ColorManagerSingleton instance;

    public static ColorManagerSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject colormanager = new GameObject();
                instance = colormanager.AddComponent<ColorManagerSingleton>();
                colormanager.name = "Color Manager Singleton";
                colormanager.tag = "ColorManager";
            }
            return instance;
        }
    }


    public Color colorP1 = Color.white;
    public Color colorP2 = Color.white;
    public Color colorP3 = Color.white;
    public Color colorP4 = Color.white;

    public Material materialP1;
    public Material materialP2;
    public Material materialP3;
    public Material materialP4;

    [Header("For Liverpool")]
    public PlayerSkin P1Skin;
    public PlayerSkin P2Skin;
    public PlayerSkin P3Skin;
    public PlayerSkin P4Skin;
    public Color colorWinner;
    public String WinnerName;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LiverPoolLogic();
    }

    public void LiverPoolLogic()
    {
        materialP1 = P1Skin.targetMaterial;
        materialP2 = P2Skin.targetMaterial;
        materialP3 = P3Skin.targetMaterial;
        materialP4 = P4Skin.targetMaterial;
        colorP1 = materialP1.color;
        colorP2 = materialP2.color;
        colorP3 = materialP3.color;
        colorP4 = materialP4.color;
    }
}
