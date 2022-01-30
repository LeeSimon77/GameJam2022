using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public void backToMenu()
    {
        Debug.Log("Returning to menu");
        StartCoroutine(DelaySceneLoad());
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TitleScreen");
    }
}
