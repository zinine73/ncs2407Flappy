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

    // ���� ���� ScoreManager�� instance
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
        // 3�� ���̸�
        if (smi.Rank < 3)
        {
            // �޴� ǥ��
            medal.sprite = medalSprite[smi.Rank];
        }
        else
        {
            // �޴� �̹��� ��ü�� ǥ������ �ʴ´�
            medal.gameObject.SetActive(false);
        }
        scoreResult.text = smi.Score.ToString();
        // ����Ʈ���ھ�� �ְ��ھ�� �����ش�
        bestText.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();
    }
}
