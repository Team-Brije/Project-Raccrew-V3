using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenVictory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textWinner;
    [SerializeField] private Image imageWinner;
    void Start()
    {
        textWinner.text = "The Winner is :\n" + ColorManagerSingleton.Instance.WinnerName;
       imageWinner.color = ColorManagerSingleton.Instance.colorWinner;
    }

}
