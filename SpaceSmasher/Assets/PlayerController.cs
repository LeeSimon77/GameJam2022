using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private float forwardMomentum = 2;
    public float moveSpeed = 5f;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        //body.rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        movement.x = 0;
        movement.y = forwardMomentum;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
        float turn = Time.fixedDeltaTime * Input.GetAxis("Horizontal");
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);

        body.MoveRotation(body.rotation + turn);
    }
}
