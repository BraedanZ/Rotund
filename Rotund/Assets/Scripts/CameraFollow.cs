using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Rigidbody2D targetRB;

    public float smoothSpeed = 0.125f;

    public float minSpeed;

    public float maxSpeed;

    public float minZoom;

    public float maxZoom;

    private float zoomVelocity;

    public float zoomSmoothTime = 0.5f;

    public Vector3 offset;

    public Camera cam;

    // public Color extraSmall;
    public Color small;
    // public Color normal;
    public Color big;
    // public Color extraBig;
    // public Color[] endColors;
    public Color doe;
    public Color re;
    public Color mi;
    public Color fa;
    public Color so;
    public Color la;
    public Color ti;    


    void Start () {
        cam = GetComponent<Camera>();
        // endColors = new Color[] { doe, re, mi, fa, so, la, ti };
        SnapCamera();
        Big();
    }

    void FixedUpdate () {
        SmoothCameraFollow();
        SmoothCameraZoom();
    }

    public void SnapCamera () {
        transform.position = target.position + offset;
    }

    private void SmoothCameraFollow() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void SmoothCameraZoom() {
        float targetSpeed = targetRB.velocity.magnitude;
        float zoomFactor = Mathf.InverseLerp(minSpeed, maxSpeed, targetSpeed);
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, zoomFactor);

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomVelocity, zoomSmoothTime);
    }

    // public void ExtraSmall() {
    //     cam.backgroundColor = extraSmall;
    // }
    public void Small() {
        cam.backgroundColor = small;
    }

    // public void Normal() {
    //     cam.backgroundColor = normal;
    // }

    public void Big() {
        cam.backgroundColor = big;
    }

    // public void ExtraBig() {
    //     cam.backgroundColor = extraBig;
    // }
    public void EndColors()
    {
        if (cam.backgroundColor == big)
        {
            cam.backgroundColor = doe;
        } else if (cam.backgroundColor == doe)
        {
            cam.backgroundColor = re;
        } else if (cam.backgroundColor == re)
        {
            cam.backgroundColor = mi;
        } else if (cam.backgroundColor == mi)
        {
            cam.backgroundColor = fa;
        } else if (cam.backgroundColor == fa)
        {
            cam.backgroundColor = so;
        } else if (cam.backgroundColor == so)
        {
            cam.backgroundColor = la;
        } else if (cam.backgroundColor == la)
        {
            cam.backgroundColor = ti;
        } else if (cam.backgroundColor == ti)
        {
            cam.backgroundColor = doe;
        }
    }
}
