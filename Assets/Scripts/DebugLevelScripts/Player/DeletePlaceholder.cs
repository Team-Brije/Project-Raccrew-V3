using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlaceholder : MonoBehaviour
{
    public void DeleteObjects()
    {
        if (gameObject.transform.childCount != 0)
        {
            GameObject g = this.gameObject;
            for (var i = g.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(g.transform.GetChild(i).gameObject);
            }
        }
    }
}
