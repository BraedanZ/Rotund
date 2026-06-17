using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownZone : MonoBehaviour
{
    public Player player;
    private new CameraFollow camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            player.IncreaseDrag();
            camera.EndColors();
        }
    }
}
