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
    private bool big = false;
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
        } else if (big) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = 0.7f;
            camera.Normal();
            small = false;
            big = false;
        } else {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = 0.35f;
            camera.Small();
            big = false;
            small = true;
        }
    }

    public void Big() {
        if (big) {
            return;
        } else if (small) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = 0.7f;
            camera.Normal();
            small = false;
            big = false;
        } 
        else {
            player.transform.localScale += scaleChange;
            rigidBody.mass = 1.4f;
            camera.Big();
            small = false;
            big = true;
        }
    }
}
