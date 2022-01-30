using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private float forwardMomentum = 500f;
    private float boostMultiplier = 5f;
    public float turnSpeed = 1f;

    private bool paused = false;
    Vector2 movement;
    private bool boosting;
    private Vector2 forwardMovementSpeed;

    private Vector2 velocity;
    private float angularVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        GameScoreScript.GameScore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * turnSpeed;
        boosting = Input.GetKey("space");
    }

    private void FixedUpdate()
    {
        if(!paused)
        {
            Turn();
            Move();
        }
    }

    private void Turn()
    {
        body.MoveRotation(body.rotation - movement.x);
    }

    private void Move()
    { 
        forwardMovementSpeed = Vector2.up* forwardMomentum * Time.fixedDeltaTime;
        if (boosting)
        {
            forwardMovementSpeed *= boostMultiplier;
        }
        body.AddRelativeForce(forwardMovementSpeed);
    }

    public void pauseMovement()
    {
        velocity = body.velocity;
        angularVelocity = body.angularVelocity;
        body.velocity = new Vector2(0, 0);
        body.angularVelocity = 0;
        paused = true;
    }

    public void resumeMovement()
    {
        body.velocity = velocity;
        body.angularVelocity = angularVelocity;
        paused = false;
    }
}
