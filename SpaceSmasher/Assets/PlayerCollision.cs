using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private AsteroidSpawner spawner;
    public AudioSource crashSound;
    public AudioSource explosionSound;

    public PlayerController controller;
    public GameObject player;
    public ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("size0"))
        {
            Destroy(collision.gameObject);
            crashSound.Play();
            GameScoreScript.GameScore++;
            Debug.Log("Player size: " + GameScoreScript.GameScore);
            scoreText.text = "Score: " + GameScoreScript.GameScore;
            spawner.destroyAsteroid(0);
        }
        else if(collision.gameObject.CompareTag("size5") || collision.gameObject.CompareTag("size4") || collision.gameObject.CompareTag("size3") || collision.gameObject.CompareTag("size2"))
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            particles.Play();
            explosionSound.Play();
            controller.pauseMovement();
            GoToGameOver();
        }
    }

    public void GoToGameOver()
    {
        StartCoroutine(DelaySceneLoad());
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOverScreen");
    }
}
