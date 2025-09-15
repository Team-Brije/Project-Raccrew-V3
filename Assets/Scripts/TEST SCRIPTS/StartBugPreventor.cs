using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBugPreventor : MonoBehaviour
{
    private void Awake()
    {
        PlayerSelectScript.isInPlayerSelectScreen = false;
    }
}
