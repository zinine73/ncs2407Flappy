using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // static 잊지말자
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    
    // Awake에서 instance 연결
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
