using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour
{
    int score = 0;

    void Awake()
    {
        SetUpSingletonScore();
    }

    private void SetUpSingletonScore()
    {
        int scoreCount = FindObjectsOfType(GetType()).Length;
        if (scoreCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
