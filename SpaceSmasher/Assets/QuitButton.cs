using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{ 
    public void QuitGame()
    {
        StartCoroutine(DelayQuitGame());
    }

    IEnumerator DelayQuitGame()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }
}
