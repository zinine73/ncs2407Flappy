using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scoreValue; //파이프 종류별로 얻게 되는 점수를 지정
    [SerializeField] private AudioClip acPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "Player"라는 태그로 들어온 트리거만 인식
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayAudio(acPoint);
            // scoreValue 값을 실제 score에 업데이트
            ScoreManager.instance.UpdateScore(scoreValue);
        }
    }
}
