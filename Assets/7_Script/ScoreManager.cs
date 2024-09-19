using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    // static 잊지말자
    public static ScoreManager instance;

    [SerializeField] private PlayCanvas canvas;
    [SerializeField] private Ranking ranking;

    private int score = 0;
    private int rank = 0;

    // Property가 get만 있는 경우 람다식으로 줄여쓰자
    public int Score => score;
    public int Rank => rank;

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

    public void CheckHiScore()
    {
        rank = ranking.CalcurateRank(score);
        canvas.UpdateResult();
    }

#if UNITY_EDITOR
    [MenuItem("FlappyBird/Reset Hi-Score", false, 1)]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}
