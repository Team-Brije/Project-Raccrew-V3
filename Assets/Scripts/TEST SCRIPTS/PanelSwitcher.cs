using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject panel;

    private void OnDisable()
    {
        panel.SetActive(true);
    }
}
