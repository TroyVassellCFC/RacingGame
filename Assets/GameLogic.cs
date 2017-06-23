using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    public CarController car;
    public Text timerText;
    public float timeLimit = 120f;
    private float startTime;
    public int score;
    public Text scoreText;
    public Text gameOverText;
    public bool gameOver;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
        gameOverText.enabled = false;
        DynamicGI.UpdateEnvironment();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = string.Format("Score: {0}", score);
        var timePassed = Time.time - startTime;
        var timeLeft = timeLimit - timePassed;

        var timeSpan = TimeSpan.FromSeconds(timeLeft);

        timerText.text = string.Format("Time left - {0:00}:{1:00}:{2:000}",
            timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        if (timeLeft < 0f)
        {
            timeLeft = 0f;
            if (!gameOver)
            {
                EndGame();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }
    void EndGame()
    {
        gameOver = true;
        gameOverText.enabled = true;
        gameOverText.text = string.Format("Game Over!\nFinal Score: {0}\nPress SPACE to Replay", score);
    }
            void Restart()
    {     
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }


