using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public Rigidbody2D asteroidBody;
    private Vector2 currVelocity;

    // Start is called before the first frame update
    void Start()
    {
        currVelocity = asteroidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Vector2 surfaceNormal = collision.contacts[0].normal;
            asteroidBody.velocity = Vector2.Reflect(currVelocity, surfaceNormal);
            currVelocity = asteroidBody.velocity;
        }
    }
}
