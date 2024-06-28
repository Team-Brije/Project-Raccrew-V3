using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObjects : MonoBehaviour
{
    [Header ("Game Objects")]
    public List<GameObject> gameObjects;
    [Header ("Buttons")]
    public List<Button> buttons;

    void Start()
    {
        // Verifier
        if (buttons.Count != gameObjects.Count)
        {
            Debug.LogError("La cantidad de bttns tienen que ser iguales a la cantidad de GO");
            return;
        }

        //Toogle
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => ToggleGameObject(index));
        }
    }

    void ToggleGameObject(int index)
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
        gameObjects[index].SetActive(true);
    }
}
