using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEnabler : MonoBehaviour
{
    public GameObject Object;
    private void OnEnable()
    {
        Object.SetActive(true);
    }
}
