using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public PlayerController controller;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public AudioSource gameMusic;
    public AudioSource pauseMusic;

    private GameObject[] size0;
    private GameObject[] size1;
    private GameObject[] size2;
    private GameObject[] size3;
    private GameObject[] size4;
    private GameObject[] size5;
    private Vector2[] vectorsSize0;
    private Vector2[] vectorsSize1;
    private Vector2[] vectorsSize2;
    private Vector2[] vectorsSize3;
    private Vector2[] vectorsSize4;
    private Vector2[] vectorsSize5;
    private bool paused = false;

    public void onClick()
    {
        if (paused)
            playGame();
        else pauseGame();
    }

    public void pauseGame()
    {
        controller.pauseMovement();
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        pauseMenu.SetActive(true);
        gameMusic.Pause();
        pauseMusic.Play();
        pauseAsteroids();
        paused = true;
    }

    public void playGame()
    {
        controller.resumeMovement();
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        pauseMenu.SetActive(false);
        pauseMusic.Stop();
        gameMusic.Play();
        playAsteroids();
        paused = false;
    }

    public void pauseAsteroids()
    {
        size0 = GameObject.FindGameObjectsWithTag("size0");
        vectorsSize0 = new Vector2[size0.Length];
        size1 = GameObject.FindGameObjectsWithTag("size1");
        vectorsSize1 = new Vector2[size1.Length];
        size2 = GameObject.FindGameObjectsWithTag("size2");
        vectorsSize2 = new Vector2[size2.Length];
        size3 = GameObject.FindGameObjectsWithTag("size3");
        vectorsSize3 = new Vector2[size3.Length];
        size4 = GameObject.FindGameObjectsWithTag("size4");
        vectorsSize4 = new Vector2[size4.Length];
        size5 = GameObject.FindGameObjectsWithTag("size5");
        vectorsSize5 = new Vector2[size5.Length];

        for (int i = 0; i < size0.Length; i++)
        {
            vectorsSize0[i] = size0[i].GetComponent<Rigidbody2D>().velocity;
            size0[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < size1.Length; i++)
        {
            vectorsSize1[i] = size1[i].GetComponent<Rigidbody2D>().velocity;
            size1[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < size2.Length; i++)
        {
            vectorsSize2[i] = size2[i].GetComponent<Rigidbody2D>().velocity;
            size2[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < size3.Length; i++)
        {
            vectorsSize3[i] = size3[i].GetComponent<Rigidbody2D>().velocity;
            size3[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < size4.Length; i++)
        {
            vectorsSize4[i] = size4[i].GetComponent<Rigidbody2D>().velocity;
            size4[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        for (int i = 0; i < size5.Length; i++)
        {
            vectorsSize5[i] = size5[i].GetComponent<Rigidbody2D>().velocity;
            size5[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void playAsteroids()
    {
        for (int i = 0; i < size0.Length; i++)
          size0[i].GetComponent<Rigidbody2D>().velocity = vectorsSize0[i];

        for (int i = 0; i < size1.Length; i++)
            size1[i].GetComponent<Rigidbody2D>().velocity = vectorsSize1[i];

        for (int i = 0; i < size2.Length; i++)
            size2[i].GetComponent<Rigidbody2D>().velocity = vectorsSize2[i];

        for (int i = 0; i < size3.Length; i++)
            size3[i].GetComponent<Rigidbody2D>().velocity = vectorsSize3[i];

        for (int i = 0; i < size4.Length; i++)
            size4[i].GetComponent<Rigidbody2D>().velocity = vectorsSize4[i];

        for (int i = 0; i < size5.Length; i++)
            size5[i].GetComponent<Rigidbody2D>().velocity = vectorsSize5[i];
    }
}
