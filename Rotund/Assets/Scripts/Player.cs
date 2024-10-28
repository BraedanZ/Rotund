using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Player player;
    Rigidbody2D rigidBody;

    float input;
    public float speed;
    void Start()
    {
        player = this;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }       

    private void Move() 
    {
        input = Input.GetAxisRaw("Horizontal");
        rigidBody.AddForce(new Vector2(1, 0) * input * speed);
    //     rigidBody.AddTorque(-(input), ForceMode2D.Force);
    }
}
