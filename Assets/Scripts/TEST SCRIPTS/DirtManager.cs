using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtManager : MonoBehaviour
{
    public Material DirtPlayer1;
    public Material DirtPlayer2;
    public Material DirtPlayer3;
    public Material DirtPlayer4;
    float convertedDirtP1;
    float convertedDirtP2;
    float convertedDirtP3;
    float convertedDirtP4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        convertedDirtP1 = convertFloat(GameManager.DirtP1);
        convertedDirtP2 = convertFloat(GameManager.DirtP2);
        convertedDirtP3 = convertFloat(GameManager.DirtP3);
        convertedDirtP4 = convertFloat(GameManager.DirtP4);
        SetValues();
    }

    public float convertFloat(float dirt)
    {
        float convertedDirt = (dirt * -1f) + 2;
        if (convertedDirt < 0f) { convertedDirt = 0f; }
        return convertedDirt;
    }

    public void SetValues()
    {
        DirtPlayer1.SetFloat("_DirtAmount", convertedDirtP1);
        DirtPlayer2.SetFloat("_DirtAmount", convertedDirtP2);
        DirtPlayer3.SetFloat("_DirtAmount", convertedDirtP3);
        DirtPlayer4.SetFloat("_DirtAmount", convertedDirtP4);
    }
}
