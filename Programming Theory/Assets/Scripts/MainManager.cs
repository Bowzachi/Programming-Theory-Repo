using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public event EventHandler OnGameOver;
    public event EventHandler OnGameStart;

    [SerializeField] private bool isGamePlaying;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isGamePlaying = false;
    }

    public void StartGame()
    {
        OnGameStart?.Invoke(this, EventArgs.Empty);
        isGamePlaying = true;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
        isGamePlaying = false;
    }

    public bool GetIsGamePlaying()
    {
        //Creating a method for reading private var ENCAPSULATION
        return isGamePlaying;
    }

}
