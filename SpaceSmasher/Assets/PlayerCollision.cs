using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private AsteroidSpawner spawner;
    [SerializeField] private PlayerGrowth growthScript;
    public AudioSource crashSound;
    public AudioSource explosionSound;

    public PlayerController controller;
    public GameObject player;
    public ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("size0"))
        {
            absorb(0, 1, collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("size1"))
        {
            if (growthScript.playerSize > 1)
                absorb(1, 2, collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("size2"))
        {
            if (growthScript.playerSize > 2)
                absorb(1, 2, collision.gameObject);
            else if (growthScript.playerSize < 2)
                die();
        }
        else if (collision.gameObject.CompareTag("size3"))
        {
            if (growthScript.playerSize > 3)
                absorb(2, 3, collision.gameObject);
            else if (growthScript.playerSize < 3)
                die();
        }
        else if (collision.gameObject.CompareTag("size4"))
        {
            if (growthScript.playerSize > 4)
                absorb(3, 4, collision.gameObject);
                
            else if (growthScript.playerSize < 4)
                die();
        }
        else if (collision.gameObject.CompareTag("size5"))
        {
            if (growthScript.playerSize < 5)
                die();
        }
    }

    private void die()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        particles.Play();
        explosionSound.Play();
        controller.pauseMovement();
        GoToGameOver();
    }

    private void absorb(int size, int points, GameObject collided)
    {
        Destroy(collided);
        crashSound.Play();
        GameScoreScript.GameScore += points;
        if (GameScoreScript.GameScore > 50)
            GoToWin();
        Debug.Log("Player size: " + GameScoreScript.GameScore);
        scoreText.text = "Score: " + GameScoreScript.GameScore;
        spawner.destroyAsteroid(size);
    }

    public void GoToGameOver()
    {
        StartCoroutine(DelayGameOverSceneLoad());
    }

    IEnumerator DelayGameOverSceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOverScreen");
    }

    public void GoToWin()
    {
        StartCoroutine(DelayWinSceneLoad());
    }

    IEnumerator DelayWinSceneLoad()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("WinScreen");
    }
}
