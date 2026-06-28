using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Player player;
    Rigidbody2D rigidBody;

    public GameMaster gameMaster;

    private new CameraFollow camera;

    public Vector3 startPosition;

    float input;
    public float speed;

    private bool lost;

    // private bool extraSmall = false;
    private bool small = true;
    // private bool normal = true;
    private bool big = false;
    // private bool extraBig = false;

    private Vector3 scaleChange;

    // public float extraSmallMass = 1f;
    public float smallMass = 1;
    // public float normalMass = 1f;
    public float bigMass = 1f;
    // public float extraBigMass = 1f;

    // public float extraSmallSpeed = 3f;
    public float smallSpeed = 3f;
    // public float normalSpeed = 3f;
    public float bigSpeed = 3f;
    // public float extraBigSpeed = 3f;

    // public float extraSmallGravity = 1f;
    public float smallGravity = 1.5f;
    // public float normalGravity = 2f;
    public float bigGravity = 2.5f;
    // public float extraBigGravity = 3f;
    private bool finished = false;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;

    public float swipeThreshold = 75f;

    private DayOfWeek currentDayOfWeek;
    private int dayIndex;

    void Start()
    {
        player = this;
        rigidBody = GetComponent<Rigidbody2D>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        scaleChange = new Vector3(0.25f, 0.25f, 0.25f);

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        SetStartPosition();

        player.transform.localScale -= scaleChange;
        rigidBody.mass = smallMass;
        rigidBody.gravityScale = smallGravity;
        camera.Big();
        small = true;
        big = false;
        speed = smallSpeed;

        lost = false;
        Big();
    }

    // void FixedUpdate()
    // {
    //     Move();
    // }      

    void Update() {
        DetectInput();
        TestMovement();
    } 

    public void Restart() {
        finished = false;
        Big();
        rigidBody.drag = 0.1f;
        player.transform.position = startPosition;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = 0f;
        lost = false;
        camera.SnapCamera();
        camera.Big();
    }

    private void SetStartPosition()
    {
        currentDayOfWeek = DateTime.Now.DayOfWeek;
        dayIndex = (int)currentDayOfWeek;

        dayIndex = 6;

        player.transform.position = new Vector3(-2, -200 * dayIndex, 0);
        startPosition = player.transform.position;
    }

    // private void Move() 
    // {
    //     // input = Input.GetAxisRaw("Horizontal");
    //     // rigidBody.AddForce(new Vector2(1, 0) * input * speed);
    //     if (player.transform.position.x < 0) {
    //         rigidBody.AddForce(new Vector2(1, 0) * 1.0f * speed);
    //     }
    // }

    private void TestMovement() {
        if (rigidBody.velocity.x <= 0 && player.transform.position.x > 0) {
            Lose();
        }
    }

    public void Lose() {
        if (!lost) {
                gameMaster.Lose();
                lost = true;
        }
    }

    private void DetectInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeSize();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeSize();
            startSwipePosition = Input.mousePosition;
        } else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endSwipePosition = Input.mousePosition;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        Vector2 swipeVector = endSwipePosition - startSwipePosition;
        if (swipeVector.magnitude > swipeThreshold)
        {
            gameMaster.Restart();
        }
    }

    private void ChangeSize() {
        if (small) {
            Big();
        } else {
            Small();
        }
    }

    public void Small() {
        if (small || finished) {
            return;
        } else {
            player.transform.localScale -= scaleChange;
            player.transform.position -= new Vector3(0f, 0.25f, 0f);
            rigidBody.mass = smallMass;
            rigidBody.gravityScale = smallGravity;
            camera.Small();
            small = true;
            big = false;
            speed = smallSpeed;
        }
    }

    public void Big() {
        if (big || finished) {
            return;
        } else {
            player.transform.position += new Vector3(0f, 0.25f, 0f);
            player.transform.localScale += scaleChange;
            rigidBody.mass = bigMass;
            rigidBody.gravityScale = bigGravity;
            camera.Big();
            small = false;
            big = true;
            speed = bigSpeed;
        }
    }

    public void FinishLine()
    {
        Big();
        IncreaseDrag();
        finished = true;
        gameMaster.FinishLine();
    }

    public void IncreaseDrag()
    {
        // rigidBody.drag += 0.047f;
        // rigidBody.angularDrag += 0.025f;
    }

    // public void Small() {
    //     if (extraSmall) {
    //         return;
    //     } else if (small) {
    //         player.transform.localScale -= scaleChange;
    //         rigidBody.mass = extraSmallMass;
    //         rigidBody.gravityScale = extraSmallGravity;
    //         camera.ExtraSmall();
    //         extraSmall = true;
    //         small = false;
    //         speed = extraSmallSpeed;
    //     } else if (normal) {
    //         player.transform.localScale -= scaleChange;
    //         rigidBody.mass = smallMass;
    //         rigidBody.gravityScale = smallGravity;
    //         camera.Small();
    //         small = true;
    //         normal = false;
    //         speed = smallSpeed;
    //     } else if (big) {
    //         player.transform.localScale -= scaleChange;
    //         rigidBody.mass = normalMass;
    //         rigidBody.gravityScale = normalGravity;
    //         camera.Normal();
    //         normal = true;
    //         big = false;
    //         speed = normalSpeed;
    //     } else {
    //         player.transform.localScale -= scaleChange;
    //         rigidBody.mass = bigMass;
    //         rigidBody.gravityScale = bigGravity;
    //         camera.Big();
    //         big = true;
    //         extraBig = false;
    //         speed = bigSpeed;
    //     }
    // }

    // public void Big() {
    //     if (extraBig) {
    //         return;
    //     } else if (big) {
    //         player.transform.localScale += scaleChange;
    //         rigidBody.mass = extraBigMass;
    //         rigidBody.gravityScale = extraBigGravity;
    //         camera.ExtraBig();
    //         extraBig = true;
    //         big = false;
    //         speed = extraBigSpeed;
    //     } else if (normal) {
    //         player.transform.localScale += scaleChange;
    //         rigidBody.mass = bigMass;
    //         rigidBody.gravityScale = bigGravity;
    //         camera.Big();
    //         big = true;
    //         normal = false;
    //         speed = bigSpeed;
    //     } else if (small) {
    //         player.transform.localScale += scaleChange;
    //         rigidBody.mass = normalMass;
    //         rigidBody.gravityScale = normalGravity;
    //         camera.Normal();
    //         normal = true;
    //         small = false;
    //         speed = normalSpeed;
    //     } else {
    //         player.transform.localScale += scaleChange;
    //         rigidBody.mass = smallMass;
    //         rigidBody.gravityScale = smallGravity;
    //         camera.Small();
    //         small = true;
    //         extraSmall = false;
    //         speed = smallSpeed;
    //     }
    // }
}
