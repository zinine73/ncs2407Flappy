using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f; // 몇초마다 생성할건지
    [SerializeField] private float heightRange = 0.5f; // 생성 위치 y 의 랜덤 범위
    [SerializeField] private GameObject[] pipePrefab; // 만들어 놓은 파이프 연결
    [SerializeField] private GameObject[] pipePrefabRed; // 빨간 파이프 연결
    private const int MAX_PIPE = 3; // 오브젝트풀링을 위해 미리 만들어 놓을 최대 파이프 갯수
    private int pipeIndex = 0; // 오브젝트풀링을 위한 인덱스 저장용 변수
    private float timer; 

    void Update()
    {
        // 게임상태가 PLAY일때만 파이프를 생성하게 한다
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            // timer가 maxTime을 넘으면
            if (timer > maxTime)
            {
                // pipe를 만드는 함수 호출
                SpawnPipe();
                // timer는 0으로
                timer = 0;
            }
            // timer에 deltaTime 더해주기
            timer += Time.deltaTime;
        }
    }

    private void SpawnPipe()
    {
        // 랜덤으로 y 값 정해서, 생성될 파이프의 위치 정하기
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        // 랜덤으로 녹색, 빨간색 파이프 선택
        //GameObject pipePf = (Random.Range(0, 100) < 10) ? pipePrefabRed : pipePrefab;
        // Instantiate로 생성, 생성된 객체는 pipe라는 GameObject에 할당
        //GameObject pipe = Instantiate(pipePf, spawnPos, Quaternion.identity);
        // 5초뒤에 pipe 객체 파괴
        //Destroy(pipe, 5f);

        // 오브젝트 풀링
        if (Random.Range(0, 100) < 10)
        {
            pipePrefabRed[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefabRed[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        if (++pipeIndex == MAX_PIPE) // 최대파이프 갯수에 도달하면
        {
            pipeIndex = 0; // 인덱스를 다시 0으로 시작
        }
    }
}
