using UnityEngine;
using System.Collections;

public class ShowingPlayerToPlayer : MonoBehaviour
{
    [SerializeField] private MovementHandler movRef;
    [SerializeField] private GameObject thisIsMe;
    public MeshRenderer[] cubesThisIsMe;

    private void Start()
    {
        thisIsMe.SetActive(false);
    }
    private void OnEnable()
    {
        InputHandler.OnThisIsMe += ShowPlayerId;
    }
    void FixedUpdate()
    {
        //thisIsMe.transform.Rotate(0, 10, 0);
    }
    private void OnDisable()
    {
        InputHandler.OnThisIsMe -= ShowPlayerId;
    }

    private void ShowPlayerId(int playerId, bool isPressed)
    {
        if (isPressed && playerId == movRef.playerId)
        {
            Debug.Log($"Soy el jugador {playerId}");
            changeColorToThisMe();
            StartCoroutine(TempThisIsMe());
        }
    }

    private IEnumerator TempThisIsMe()
    {
        thisIsMe.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        thisIsMe.SetActive(false);
    }
    public void changeColorToThisMe()
    {
        switch (movRef.playerId)
        {
            case 0:
                if (ColorManagerSingleton.Instance.materialP1 != null)
                {
                    for (int i = 0; i < cubesThisIsMe.Length; i++)
                    {
                        cubesThisIsMe[i].material = ColorManagerSingleton.Instance.materialP1;
                    }
                }
                break;
            case 1:
                if (ColorManagerSingleton.Instance.materialP2 != null)
                {
                    for (int i = 0; i < cubesThisIsMe.Length; i++)
                    {
                        cubesThisIsMe[i].material = ColorManagerSingleton.Instance.materialP2;
                    }
                }
                break;
            case 2:
                if (ColorManagerSingleton.Instance.materialP3 != null)
                {
                    for (int i = 0; i < cubesThisIsMe.Length; i++)
                    {
                        cubesThisIsMe[i].material = ColorManagerSingleton.Instance.materialP3;
                    }
                }
                break;
            case 3:
                if (ColorManagerSingleton.Instance.materialP4 != null)
                {
                    for (int i = 0; i < cubesThisIsMe.Length; i++)
                    {
                        cubesThisIsMe[i].material = ColorManagerSingleton.Instance.materialP4;
                    }
                }
                break;
        }
    }
}
