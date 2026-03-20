using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Player player;

    public Text distanceText;

    private float distance;
    private string distanceStr;

    public Text timeCounter;

    private float startTime;
    public float elapsedTime;
    public float loadedTime;
    TimeSpan timePlaying;
    private string timePlayingStr;

    public GameObject winPanel;

    public GameObject gameOverlay;

    public bool gamePlaying { get; private set; }

    void Start()
    {
        SetStartVariables();
    }

    private void SetStartVariables() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gamePlaying = true;
        startTime = Time.time;
    }

    void Update()
    {
        UpdateTimer();
        UpdateDistance();
    }

    private void UpdateTimer() {
        if (gamePlaying) {
            elapsedTime = Time.time - startTime + loadedTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }

    private void UpdateDistance() {
        if (player.transform.position.x > distance) {
            distance = (float)Math.Round(player.transform.position.x);
            distanceStr = distance.ToString() + "m";
            distanceText.text = distanceStr;
        }
    }
}
