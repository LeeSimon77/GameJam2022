using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    private int playerSize = 1;
    [SerializeField] private Text scoreText;
    [SerializeField] private AsteroidSpawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            playerSize++;
            Debug.Log("Player size: " + playerSize);
            scoreText.text = "Score: " + playerSize;
            spawner.destroyAsteroid();
        }
    }
}
