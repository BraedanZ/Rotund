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

    private float extraSmallMass = 0.25f;
    private float smallMass = 0.5f;
    private float normalMass = 1f;
    private float bigMass = 2f;
    private float extraBigMass = 4f;

    private float extraSmallSpeed = 5f;
    private float smallSpeed = 7.5f;
    private float normalSpeed = 10f;
    private float bigSpeed = 12.5f;
    private float extraBigSpeed = 15f;

    void Start()
    {
        player = this;
        rigidBody = GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(0.125f, 0.125f, 0.125f);

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
            speed = extraSmallSpeed;
        } else if (normal) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = smallMass;
            camera.Small();
            small = true;
            normal = false;
            speed = smallSpeed;
        } else if (big) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = normalMass;
            camera.Normal();
            normal = true;
            big = false;
            speed = normalSpeed;
        } else {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = bigMass;
            camera.Big();
            big = true;
            extraBig = false;
            speed = bigSpeed;
        }
    }

    public void Big() {
        if (extraBig) {
            return;
        } else if (big) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = extraBigMass;
            camera.ExtraBig();
            extraBig = true;
            big = false;
            speed = extraBigSpeed;
        } else if (normal) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = bigMass;
            camera.Big();
            big = true;
            normal = false;
            speed = bigSpeed;
        } else if (small) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = normalMass;
            camera.Normal();
            normal = true;
            small = false;
            speed = normalSpeed;
        } else {
            player.transform.localScale += scaleChange;
            rigidBody.mass = smallMass;
            camera.Small();
            small = true;
            extraSmall = false;
            speed = smallSpeed;
        }
    }
}
