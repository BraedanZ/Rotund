using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public Camera cam;

    public Color small;
    public Color big;
    public Color normal;

    void Start () {
        cam = GetComponent<Camera>();
        SnapCamera();
    }

    void FixedUpdate () {
        SmoothCameraFollow();
    }

    public void SnapCamera () {
        transform.position = target.position + offset;
    }

    private void SmoothCameraFollow() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void Small() {
        cam.backgroundColor = small;
    }

    public void Big() {
        cam.backgroundColor = big;
    }

    public void Normal() {
        cam.backgroundColor = normal;
    }
}
