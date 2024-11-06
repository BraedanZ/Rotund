using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Player player;
    Rigidbody2D rigidBody;

    private new CameraFollow camera;

    float input;
    public float speed;

    private bool small = false;
    private Vector3 scaleChange;
    void Start()
    {
        player = this;
        rigidBody = GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(0.2f, 0.2f, 0.2f);

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
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

    public void Small() {
        if (small) {
            return;
        } else {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = 0.35f;
            camera.Small();
            small = true;
        }
    }
}
