using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public void backToMenu()
    {
        Debug.Log("Returning to menu");
        SceneManager.LoadScene("TitleScreen");
    }
}
