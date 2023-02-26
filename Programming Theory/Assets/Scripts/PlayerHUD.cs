using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    [SerializeField] private float timeLimitMax = 10f;
    [SerializeField] private float timeLimit;

    void Start()
    {
        ScoreManager.Instance.OnScoreUpdated += ScoreManager_OnScoreUpdated;
        MainManager.Instance.OnGameStart += MainManager_OnGameStart;
        MainManager.Instance.OnGameOver += MainManager_OnGameOver;
    }

    private void MainManager_OnGameOver(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void MainManager_OnGameStart(object sender, System.EventArgs e)
    {
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        timeLimit = timeLimitMax;
        scoreText.text = "SCIENCE: 0";
        timerText.text = "TIMER: " + timeLimit;
    }

    private void Update()
    {
        if (MainManager.Instance.GetIsGamePlaying())
        {

            timeLimit -= Time.deltaTime;
            if (timeLimit <= 0)
            {
                MainManager.Instance.GameOver();
            }
            else
            {
                UpdateTimerText();
            }
        }
    }

    private void ScoreManager_OnScoreUpdated(object sender, System.EventArgs e)
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCIENCE: " + ScoreManager.Instance.GetScore();
    }

    private void UpdateTimerText()
    {
        timerText.text = "TIMER: " + Mathf.CeilToInt(timeLimit);
    }
}
