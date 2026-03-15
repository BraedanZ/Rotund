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

    private bool extraSmall = false;
    private bool small = false;
    private bool normal = true;
    private bool big = false;
    private bool extraBig = false;

    private Vector3 scaleChange;

    private float extraSmallMass = 0.1f;
    private float smallMass = 0.3f;
    private float normalMass = 1f;
    private float bigMass = 3f;
    private float extraBigMass = 10f;

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
        if (extraSmall) {
            return;
        } else if (small) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = extraSmallMass;
            camera.ExtraSmall();
            extraSmall = true;
            small = false;
        } else if (normal) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = smallMass;
            camera.Small();
            small = true;
            normal = false;
        } else if (big) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = normalMass;
            camera.Normal();
            normal = true;
            big = false;
        } else {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = bigMass;
            camera.Big();
            big = true;
            extraBig = false;
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
