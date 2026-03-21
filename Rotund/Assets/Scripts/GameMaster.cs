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

    public GameObject runEndPanel;

    public GameObject gameOverlay;

    public bool gamePlaying { get; private set; }

    private string runEndDistanceStr;
    public Text runEndDistanceText;

    private string runEndTimeStr;
    public Text runEndTimeText;

    private float bestDistance;
    private string bestDistanceStr;

    private TimeSpan bestTime;
    private string bestTimeStr;

    public Text bestDistanceText;
    public Text bestTimeCounter;

    void Start()
    {
        SetStartVariables();
    }

    private void SetStartVariables() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gamePlaying = true;
        startTime = Time.time;
        bestDistance = 0f;
    }

    void Update()
    {
        UpdateTimer();
        UpdateDistance();
        DetectInput();
    }

    private void DetectInput() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Restart();
        }
    }

    public void Restart() {
        player.Restart();
        ResetVariables();
    }


    private void ResetVariables() {
        startTime = Time.time;
        distance = 0f;
        distanceStr = distance.ToString() + "m";
        distanceText.text = distanceStr;
        gameOverlay.SetActive(true);
        runEndPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Lose() {
        gameOverlay.SetActive(false);
        runEndPanel.SetActive(true);
        Time.timeScale = 0f;
        StoreBestRun();
        UpdateCurrentRun();
    }

    private void StoreBestRun() {
        if (distance > bestDistance) {
            bestDistance = distance;
            bestDistanceStr = "Best Run Distance: " + bestDistance.ToString() + "m";
            bestDistanceText.text = bestDistanceStr;

            bestTime = timePlaying;
            bestTimeStr = "Best Run Time: " + timePlaying.ToString("mm':'ss'.'ff");
            bestTimeCounter.text = bestTimeStr;
        }
        if (distance == bestDistance && timePlaying < bestTime) {
            bestTime = timePlaying;
            bestTimeStr = "Best Run Time: " + timePlaying.ToString("mm':'ss'.'ff");
            bestTimeCounter.text = bestTimeStr;
        }
    }

    private void UpdateCurrentRun() {
        runEndDistanceStr = "Run Distance : " + distance + "m";
        runEndDistanceText.text = runEndDistanceStr;

        runEndTimeStr = "Run Time: " + timePlaying.ToString("mm':'ss'.'ff");
        runEndTimeText.text = runEndTimeStr;
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
