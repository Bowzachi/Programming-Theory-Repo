using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;

    private void Start()
    {
        MainManager.Instance.OnGameOver += Instance_OnGameOver;
        gameObject.SetActive(false);
    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        OnDisplay();
    }

    void OnDisplay()
    {
        int finalScore = ScoreManager.Instance.GetScore();
        finalScoreText.text = "FINAL SCIENCE: " + finalScore;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
