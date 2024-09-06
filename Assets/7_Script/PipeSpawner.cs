using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f; // ���ʸ��� �����Ұ���
    [SerializeField] private float heightRange = 0.5f; // ���� ��ġ y �� ���� ����
    [SerializeField] private GameObject pipePrefab; // �������� ������ ����
    private float timer; 

    void Update()
    {
        // timer�� maxTime�� ������
        if (timer > maxTime)
        {
            // pipe�� ����� �Լ� ȣ��
            SpawnPipe();
            // timer�� 0����
            timer = 0;
        }
        // timer�� deltaTime �����ֱ�
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        // �������� y �� ���ؼ�, ������ �������� ��ġ ���ϱ�
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        // Instantiate�� ����, ������ ��ü�� pipe��� GameObject�� �Ҵ�
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        // 5�ʵڿ� pipe ��ü �ı�
        Destroy(pipe, 5f);
    }
}
