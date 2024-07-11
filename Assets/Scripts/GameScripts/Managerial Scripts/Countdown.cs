using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int duration = 60;
    public int timeRemaining;
    public bool isCountingDown = false;
    public TextMeshProUGUI timerText;
    public GameObject[] tieBreakersPrefabs;
    private void Start()
    {
        timerText.text = duration.ToString();
        timeRemaining = duration;
        Begin();
    }

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            Invoke("_tick", 1f);
        }
    }


    public void Stop()
    {
        isCountingDown = false;
        timerText.text = timeRemaining.ToString();
    }

    private void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0 && isCountingDown)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
            TieBreakersSpawner();
        }
        timerText.text = timeRemaining.ToString();
    }
    private void TieBreakersSpawner(){
        int tieBreakerIndex = Random.Range(0, tieBreakersPrefabs.Length);
        Instantiate(tieBreakersPrefabs[tieBreakerIndex],Vector3.zero,Quaternion.identity);
    }
}
