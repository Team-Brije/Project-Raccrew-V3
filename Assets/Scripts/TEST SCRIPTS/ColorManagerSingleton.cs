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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
