using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class RankUI : MonoBehaviour
{
    [SerializeField] private Image medal;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Sprite[] medalSprite;

    public void SetRank(int rank, int score, string dt)
    {
        // 3이상이면 3을, 아니면 그 값을 인덱스로 한다
        int medalIndex = (rank > 2) ? 3 : rank;
        // 메달스프라이트에 있는 메달 선택
        medal.sprite = medalSprite[medalIndex];
        // 랭크 값은 0부터이므로 +1
        rankText.text = (rank + 1).ToString();
        // 랭크가 3이상일때만 표시
        rankText.gameObject.SetActive(rank > 2);

        // string 연산을 많이 하게 되므로 StringBuilder를 사용
        // "2024/01/01(줄바꿈)09:10:12" 형식으로 보이게 만든다
        StringBuilder sb = new StringBuilder();
        sb.Append("20");
        sb.Append(dt.Substring(0, 2));
        sb.Append("/");
        sb.Append(dt.Substring(2, 2));
        sb.Append("/");
        sb.Append(dt.Substring(4, 2));
        sb.Append("\n");
        sb.Append(dt.Substring(6, 2));
        sb.Append(":");
        sb.Append(dt.Substring(8, 2));
        sb.Append(":");
        sb.Append(dt.Substring(10, 2));
        // StringBuilder 값을 넘길때는 ToString() 잊지말자
        dateText.text = sb.ToString();
        // 점수 표시
        scoreText.text = score.ToString();
    }
}
