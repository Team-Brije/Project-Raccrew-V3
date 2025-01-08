using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    private void OnEnable()
    {
        BulletGun.DisableAbilites += KillObject;
    }

    private void OnDisable()
    {
        BulletGun.DisableAbilites -= KillObject;
    }

    public void KillObject()
    {
        Destroy(gameObject);
    }
}
