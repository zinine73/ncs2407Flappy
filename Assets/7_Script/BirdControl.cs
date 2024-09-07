using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotateSpeed = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        // Rigidbody2D 연결
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        // 마우스클릭(화면터치)을 하면 
        if (Input.GetMouseButtonDown(0))
        {
            // 위로 이동
            rb.velocity = Vector2.up * velocity;
        }
    }
    private void FixedUpdate()
    {
        // update끝나고 velocity.y 값만큼 회전
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
