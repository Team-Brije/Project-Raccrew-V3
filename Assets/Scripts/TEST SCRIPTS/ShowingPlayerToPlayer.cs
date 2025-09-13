using UnityEngine;
using System.Collections;

public class ShowingPlayerToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject thisIsMe;

    private void Start()
    {
        thisIsMe.SetActive(false);
    }
    private void OnEnable()
    {
        InputHandler.OnThisIsMe += ShowPlayerId;
    }

    private void OnDisable()
    {
        InputHandler.OnThisIsMe -= ShowPlayerId;
    }

    private void ShowPlayerId(int playerId, bool isPressed)
    {
        if (isPressed)
        {
            Debug.Log($"Soy el jugador {playerId}");
            StartCoroutine(TempThisIsMe());
        }
    }

    private IEnumerator TempThisIsMe()
    {
        thisIsMe.SetActive(true);
        yield return new WaitForSeconds(2f);
        thisIsMe.SetActive(false);
    }
}
