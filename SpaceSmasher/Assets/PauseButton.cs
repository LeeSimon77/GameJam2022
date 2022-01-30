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
        paused = false;
    }
}
