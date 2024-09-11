using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using을 이용해서 자주 쓰는 단어를 줄여 쓸 수 있다
using GMState = GameManager.State;

public class BirdControl : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private AudioClip acWing;
    [SerializeField] private AudioClip acDie;

    private Rigidbody2D rb;
    // 자주 쓸거같은 instance는 줄여 쓸 수 있다
    private GameManager gmi;

    private void Start()
    {
        // Rigidbody2D 연결
        rb = GetComponent<Rigidbody2D>();
        // Bird가 안 떨어지게 gravity 값 조정
        rb.gravityScale = 0f;
        // 자주 쓰려고 만든 instance연결
        gmi = GameManager.instance;
    }

    private void Update()
    {
        // 마우스클릭(화면터치)을 하면 
        if (Input.GetMouseButtonDown(0))
        {
            // 게임상태가 READY면
            if (gmi.GameState == GMState.READY)
            {
                // 게임상태를 PLAY로 바꾸고
                gmi.GamePlay();
                // gravity 값을 게임이 되도록 조정
                rb.gravityScale = 0.5f;
            }
            // 게임상태가 PLAY면
            else if (gmi.GameState == GMState.PLAY)
            {
                gmi.PlayAudio(acWing);
                // 위로 이동
                rb.velocity = Vector2.up * velocity;
            }
        }
    }
    private void FixedUpdate()
    {
        // update끝나고 velocity.y 값만큼 회전
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gmi.GameState == GMState.PLAY)
        {
            gmi.GameOver();
            // Bird의 Flap 애니메이션을 멈춘다
            GetComponent<Animator>().enabled = false;
            // Bird의 Y좌표에 따라 audio 재생
            if (transform.position.y > 0)
            {
                gmi.PlayAudio(acDie);
            }
        }
    }
}
