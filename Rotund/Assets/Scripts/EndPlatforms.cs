using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatforms : MonoBehaviour
{
    private new CameraFollow camera;
    private bool hasTriggered = false;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasTriggered ||! other.gameObject.CompareTag("Player")) return;

        hasTriggered = true;
        camera.EndColors();
    }
}
