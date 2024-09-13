using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scorePlay;
    [SerializeField] private Image medal;
    [SerializeField] private TextMeshProUGUI scoreResult;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private Sprite[] medalSprite;

    // 자주 쓰는 ScoreManager의 instance
    private ScoreManager smi;

    private void Start()
    {
        smi = ScoreManager.instance;
    }

    public void UpdateScore()
    {
        scorePlay.text = smi.Score.ToString();
    }
}
