using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public static event Action DisableAbilites;
    // Start is called before the first frame update
    void Start()
    {
        DisableAbilites?.Invoke();
    }
}
