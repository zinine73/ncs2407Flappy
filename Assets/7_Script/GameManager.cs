using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverUI;
    private void Awake()
    {
        if (instance == null) instance = this;
        // 정상적인 게임의 시간이 흐르게
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        // 게임의 시간을 멈춘다
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        // 현재 열려 있는 씬을 다시 처음부터 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
