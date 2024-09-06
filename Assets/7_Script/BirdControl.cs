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
        // Rigidbody2D ����
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        // ���콺Ŭ��(ȭ����ġ)�� �ϸ� ���� �����̰�
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    private void FixedUpdate()
    {
        // update���� ����� velocity.y ����ŭ ȸ��
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
