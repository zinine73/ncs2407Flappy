using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;
    public bool Moving {get; set;}
    void Update()
    {
        // 게임상태가 PLAY일때만 움직이도록
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            if (Moving) // 오브젝트풀링에서 움직임 시작 조정
            {
                // 파이프의 위치를 speed만큼 좌로 이동
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else if (GameManager.instance.GameState == GameManager.State.GAMEOVER)
        {
            upPipe.enabled = downPipe.enabled = false;
        }
    }
}
