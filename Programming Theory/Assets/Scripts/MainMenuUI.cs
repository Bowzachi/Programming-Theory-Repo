using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    public void StartGame()
    {
        MainManager.Instance.StartGame();
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
