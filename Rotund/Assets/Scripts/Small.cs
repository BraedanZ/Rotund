using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small : MonoBehaviour
{
    private Player player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            player.Small();
        }
    }
}
