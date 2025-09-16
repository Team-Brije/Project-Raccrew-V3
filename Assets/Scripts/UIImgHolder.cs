using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImgHolder : MonoBehaviour
{
    public Sprite[] imgs;
    public Image Image;

    public void switchImage (string imageName)
    {
        switch(imageName)
        {
            case "blank":
                Image.sprite = imgs[0];
                break;
            case "Ghost":
                Image.sprite = imgs[1];
                break;
            case "GoldenGun":
                Image.sprite = imgs[7];
                break;
            case "Grenade":
                Image.sprite = imgs[2];
                break;
            case "RPG":
                Image.sprite = imgs[6];
                break;
            case "Spin":
                Image.sprite = imgs[8];
                break;
            case "Thumper":
                Image.sprite = imgs[3];
                break;
            case "WaterBucket":
                Image.sprite = imgs[4];
                break;
            case "WindWave":
                Image.sprite = imgs[5];
                break;
        }
    }
}
