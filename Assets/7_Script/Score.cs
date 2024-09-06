using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
