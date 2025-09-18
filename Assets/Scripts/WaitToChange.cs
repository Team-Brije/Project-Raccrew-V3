using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitToChange : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("gameselect");
    }
}
