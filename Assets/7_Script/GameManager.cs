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
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        // 현재 열려 있는 씬을 다시 처음부터 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
