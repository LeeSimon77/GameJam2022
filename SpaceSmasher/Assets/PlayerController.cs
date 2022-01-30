using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private float forwardMomentum = 500f;
    public float turnSpeed = 1f;

    private bool paused = false;
    Vector2 movement;

    private Vector2 velocity;
    private float angularVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        GameScoreScript.GameScore = 1;
        //body.rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * turnSpeed;
        //movement.x = movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = forwardMomentum;
    }

    private void FixedUpdate()
    {
        //Move();
        //Turn();
        if(!paused)
        {
            body.MoveRotation(body.rotation - movement.x);
            // body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
            body.AddRelativeForce(Vector2.up * forwardMomentum * Time.fixedDeltaTime);
            // float turn = Time.fixedDeltaTime * Input.GetAxis("Horizontal");
            // Quaternion turnRotation = Quaternion.Euler(0, turn, 0);

        }

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

    // private void Move()
    // {
    //     //Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
    //     Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

    //     //Apply this movement to the rigidbody's position.
    //     m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    // }


    // private void Turn()
    // {
    //     // Determine the number of degrees to be turned based on the input, speed and time between frames.
    //     float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

    //     // Make this into a rotation in the y axis.
    //     Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

    //     // Apply this rotation to the rigidbody's rotation.
    //     m_Rigidbody.MoveRotation(body.rotation * turnRotation);
    // }
}
