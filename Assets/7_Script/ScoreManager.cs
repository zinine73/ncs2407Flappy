using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // static 잊지말자
    public static ScoreManager instance;

    [SerializeField] private PlayCanvas canvas;

    private int score = 0;
    
    public int Score { get { return score; } }

    // Awake에서 instance 연결
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)
    {
        score += value;
        canvas.UpdateScore();
    }
}
