using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirtShow : MonoBehaviour
{
    public int player;
    public Image img;

    void Update()
    {
        float dirtPercentage = setDirt(player);
        setFill(dirtPercentage);
    }

    public float setDirt(int player)
    {
        switch (player)
        {
            case 1:
                return GameManager.DirtP1;
            case 2:
                return GameManager.DirtP2;
            case 3:
                return GameManager.DirtP3;
            case 4:
                return GameManager.DirtP4;
        }
        return 0;
    }

    public void setFill(float dirtBase)
    {
        img.fillAmount = dirtBase/2;
    }
}
