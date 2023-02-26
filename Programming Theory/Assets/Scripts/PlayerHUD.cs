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
        timeLimit = timeLimitMax;
        scoreText.text = "SCIENCE: 0";
        timerText.text = "TIMER: " + timeLimit;
        ScoreManager.Instance.OnScoreUpdated += Instance_OnScoreUpdated;
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

    private void Instance_OnScoreUpdated(object sender, System.EventArgs e)
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
