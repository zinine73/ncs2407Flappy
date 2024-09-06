using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    void Update()
    {
        // �������� ��ġ�� speed��ŭ �·� �̵�
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
