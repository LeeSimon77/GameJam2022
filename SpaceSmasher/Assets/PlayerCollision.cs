using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private AsteroidSpawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            GameScoreScript.GameScore++;
            Debug.Log("Player size: " + GameScoreScript.GameScore);
            scoreText.text = "Size: " + GameScoreScript.GameScore;
            spawner.destroyAsteroid();
        }
    }
}
