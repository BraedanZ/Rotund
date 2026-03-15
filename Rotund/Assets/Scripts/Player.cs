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

    public float extraSmallMass = 0.25f;
    public float smallMass = 0.5f;
    public float normalMass = 1f;
    public float bigMass = 2f;
    public float extraBigMass = 4f;

    public float extraSmallSpeed = 5f;
    public float smallSpeed = 7.5f;
    public float normalSpeed = 10f;
    public float bigSpeed = 12.5f;
    public float extraBigSpeed = 15f;

    public float extraSmallGravity = 0.5f;
    public float smallGravity = 0.75f;
    public float normalGravity = 1f;
    public float bigGravity = 1.25f;
    public float extraBigGravity = 1.5f;

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
            rigidBody.gravityScale = extraSmallGravity;
            camera.ExtraSmall();
            extraSmall = true;
            small = false;
            speed = extraSmallSpeed;
        } else if (normal) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = smallMass;
            rigidBody.gravityScale = smallGravity;
            camera.Small();
            small = true;
            normal = false;
            speed = smallSpeed;
        } else if (big) {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = normalMass;
            rigidBody.gravityScale = normalGravity;
            camera.Normal();
            normal = true;
            big = false;
            speed = normalSpeed;
        } else {
            player.transform.localScale -= scaleChange;
            rigidBody.mass = bigMass;
            rigidBody.gravityScale = bigGravity;
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
            rigidBody.gravityScale = extraBigGravity;
            camera.ExtraBig();
            extraBig = true;
            big = false;
            speed = extraBigSpeed;
        } else if (normal) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = bigMass;
            rigidBody.gravityScale = bigGravity;
            camera.Big();
            big = true;
            normal = false;
            speed = bigSpeed;
        } else if (small) {
            player.transform.localScale += scaleChange;
            rigidBody.mass = normalMass;
            rigidBody.gravityScale = normalGravity;
            camera.Normal();
            normal = true;
            small = false;
            speed = normalSpeed;
        } else {
            player.transform.localScale += scaleChange;
            rigidBody.mass = smallMass;
            rigidBody.gravityScale = smallGravity;
            camera.Small();
            small = true;
            extraSmall = false;
            speed = smallSpeed;
        }
    }
}
