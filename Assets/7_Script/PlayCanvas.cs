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

    public void UpdateResult()
    {
        // 3등 안이면
        if (smi.Rank < 3)
        {
            // 메달 표시
            medal.sprite = medalSprite[smi.Rank];
        }
        else
        {
            // 메달 이미지 자체를 표시하지 않는다
            medal.gameObject.SetActive(false);
        }
        scoreResult.text = smi.Score.ToString();
        // 베스트스코어는 최고스코어값을 보여준다
        bestText.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();
    }
}
