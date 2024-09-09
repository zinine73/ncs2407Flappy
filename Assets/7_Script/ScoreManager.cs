using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // static ��������
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    
    // Awake���� instance ����
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
