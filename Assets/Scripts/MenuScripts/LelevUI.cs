using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LelevUI : MonoBehaviour
{
    public CanvasGroup FireRingUI;
    public CanvasGroup SpikeSpawnUI;
    public CanvasGroup GoldenGunUI;
    public CanvasGroup BombRainUI;
    public bool fadeAway;

    private void Start()
    {
        FireRingUI.alpha = 0f;
        BombRainUI.alpha = 0f;
        fadeAway = false;
    }
    public void FireUI()
    {
        StartCoroutine(FadePanel(FireRingUI));
     }
    public void SpikesUI()
    {
        StartCoroutine(FadePanel(SpikeSpawnUI));
    }
    public void GunUI()
    {
        StartCoroutine(FadePanel(GoldenGunUI));
    }
    public void BombsUI()
    {
        StartCoroutine(FadePanel(BombRainUI));
    }

    IEnumerator FadePanel(CanvasGroup panel)
        {
            if (fadeAway)
            {
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    panel.alpha = i;
                    yield return null;
                }
                fadeAway = false;
            }
            else
            {
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    panel.alpha = i;
                    yield return null;
                }
                fadeAway=true;
            }
        }
    }
