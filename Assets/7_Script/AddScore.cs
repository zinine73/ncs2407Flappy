using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scoreValue; //������ �������� ��� �Ǵ� ������ ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "Player"��� �±׷� ���� Ʈ���Ÿ� �ν�
        if (collision.gameObject.CompareTag("Player"))
        {
            // scoreValue ���� ���� score�� ������Ʈ
            ScoreManager.instance.UpdateScore(scoreValue);
        }
    }
}
