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
        // 3�̻��̸� 3��, �ƴϸ� �� ���� �ε����� �Ѵ�
        int medalIndex = (rank > 2) ? 3 : rank;
        // �޴޽�������Ʈ�� �ִ� �޴� ����
        medal.sprite = medalSprite[medalIndex];
        // ��ũ ���� 0�����̹Ƿ� +1
        rankText.text = (rank + 1).ToString();
        // ��ũ�� 3�̻��϶��� ǥ��
        rankText.gameObject.SetActive(rank > 2);

        // string ������ ���� �ϰ� �ǹǷ� StringBuilder�� ���
        // "2024/01/01(�ٹٲ�)09:10:12" �������� ���̰� �����
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
        // StringBuilder ���� �ѱ涧�� ToString() ��������
        dateText.text = sb.ToString();
        // ���� ǥ��
        scoreText.text = score.ToString();
    }
}
