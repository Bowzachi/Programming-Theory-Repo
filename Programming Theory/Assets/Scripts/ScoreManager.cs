using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event EventHandler OnScoreUpdated;

    private int score;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        Debug.Log(score);
        OnScoreUpdated?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore()
    {
        return score;
    }
}
