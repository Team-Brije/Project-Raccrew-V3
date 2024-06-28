using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int duration = 60;
    public int timeRemaining;
    static public bool isCountingDown = false;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timerText.text = duration.ToString();
        Begin();
    }

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    private void _tick()
    {
        if (isCountingDown) 
        {
            timeRemaining--;
                if (timeRemaining > 0)
            {
                Invoke("_tick", 1f);
            }
            else
            {
                isCountingDown = false;
            }
            timerText.text = timeRemaining.ToString();
        }
       else Invoke("_tick", 1f);
    }
}
