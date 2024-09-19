using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Ranking : MonoBehaviour
{
    public const int MAX_RANK = 5; // �ִ� ��ũ ������ ����
    public static string DTPattern = @"yyMMddhhmmss"; // DateTime�� string���� �ٲ� �� �� ����

    [SerializeField] private RankUI[] ranking;

    private void Start()
    {
        for (int i = 0; i < MAX_RANK; i++)
        {
            // Ű���� ������ "240101120000" �� ������ ���� �ٲ� ���� ����Ʈ�� �����
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            // Hi-Score �� �� ��ũ ���� ����
            ranking[i].SetRank(i, value, key);
        }
    }

    public int CalcurateRank(int score)
    {
        // ���� ����� 1~5 ���� ���� ��ųʸ��� ����� ����
        Dictionary<string, int> rankDic = new Dictionary<string, int>();
        for (int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            rankDic.Add(key, value);
        }
        // ���� �Ͻø� ������ �̿��� Ű������ �����
        string nowKey = DateTime.Now.ToString(DTPattern);
        // ��ųʸ��� ���� => �� ������ MAX_RANK + 1
        rankDic.Add(nowKey, score);
        // ������������ ���� �� ���� ���ο� ��ųʸ��� ����
        var newDic = rankDic.OrderByDescending(x => x.Value);
        // ��ȯ������ �ִ밪�� �����ϰ�
        int nowRanking = MAX_RANK;
        // �ε����� 0���� ����
        int index = 0;
        foreach (var item in newDic)
        {
            PlayerPrefs.SetString($"RANKDATE{index}", item.Key);
            PlayerPrefs.SetInt($"RANKSCORE{index}", item.Value);
            // ���� item�� nowKey���� ������ �׶� �ε����� ��ũ��
            if (item.Key.CompareTo(nowKey) == 0)
            {
                nowRanking = index;
            }
            // �ִ뷩ũ ����ŭ �������� ������
            if (++index == MAX_RANK) break;
        }
        // ��ũ�� ��ȯ
        return nowRanking;
    }
}
