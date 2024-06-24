using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupStorage : MonoBehaviour
{
    PlayerMovement player;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }
    public void ChangeSpeed(float speed, int duration)
    {
        StartCoroutine(Timer(duration, speed));
    }

    public IEnumerator Timer(int duration, float speed)
    {
        float originalspeed = player.initialspeed;
        player.initialspeed = speed;
        Debug.Log("No");
        yield return new WaitForSeconds(duration);
        Debug.Log("Si");
        player.initialspeed = originalspeed;
    }
}
