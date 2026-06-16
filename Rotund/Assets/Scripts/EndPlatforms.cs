using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatforms : MonoBehaviour
{
    public Player player;
    private new CameraFollow camera;
    private bool hasTriggered = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasTriggered ||! other.gameObject.CompareTag("Player")) return;

        hasTriggered = true;
        player.IncreaseDrag();
        camera.EndColors();
    }
}
