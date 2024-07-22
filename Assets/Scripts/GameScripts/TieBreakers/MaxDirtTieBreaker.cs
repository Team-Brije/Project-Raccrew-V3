using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDirtTieBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.DirtCap = false;
        GameManager.DirtP1 = 5;
        GameManager.DirtP2 = 5;
        GameManager.DirtP3 = 5;
        GameManager.DirtP4 = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
