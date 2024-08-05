using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFireClosing : MonoBehaviour
{
    public Transform RingSize;
    public float scaleRate;

    // Update is called once per frame
    void Update()
    { if(RingSize.localScale.x>0.01)
        for (int i = 0; i <= 10; i++)
        {
            RingSize.localScale = new Vector3(RingSize.localScale.x - scaleRate, RingSize.localScale.y , RingSize.localScale.z - scaleRate);
        }
    }
}
