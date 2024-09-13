using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 상태를 저장할 enum
    public enum State
    {
        TITLE,      // 0 : 0
        READY,      // 1 : 1
        PLAY,       // 2 : 0
        GAMEOVER,   // 3 : 1
        HISCORE     // 4 : 0
    }

    public static GameManager instance;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Animator floorAnim;
    [SerializeField] private AudioClip acReady;
    [SerializeField] private AudioClip acHit;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject[] stateUI;
    [SerializeField] private Sprite[] bgSprite;

    private new AudioSource audio;
    private State gameState; // 게임상태를 저장할 변수
    public State GameState { get { return gameState; } } // gameState를 외부에 전달

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        // AudioSource 연결
        audio = GetComponent<AudioSource>();
        // 정상적인 게임의 시간이 흐르게
        Time.timeScale = 1.0f;
        GameTitle();
    }

    public void PlayAudio(AudioClip clip)
    {
        // 파라메터로 넘어온 clip을 한번 플레이시킨다
        audio.PlayOneShot(clip);
    }

    private void ChangeState(State value)
    {
        gameState = value;
        // stateUI에 있는 모든 UI를 끈다
        foreach (var item in stateUI)
        {
            item.SetActive(false);
        }
        // State값을 공통으로 사용하므로, 미리 int 값으로 변환
        int temp = (int)value;
        // 해당하는 Background sprite 연결
        background.sprite = bgSprite[temp % 2];
        // 해당하는 stateUI를 켠다
        stateUI[temp].SetActive(true);
    }

    public void GameTitle()
    {
        ChangeState(State.TITLE);
    }

    public void GameReady()
    {
        ChangeState(State.READY);
        PlayAudio(acReady);
    }

    public void GamePlay()
    {
        ChangeState(State.PLAY);
    }

    public void GameOver()
    {
        ChangeState(State.GAMEOVER);
        PlayAudio(acHit);
        // 바닥 애니메이션을 멈춘다
        floorAnim.enabled = false;
        // 코루틴을 이용해서 잠시 시간을 지연시킨다
        StartCoroutine(StopTimer());
    }

    IEnumerator StopTimer()
    {
        // 2초 기다렸다 다음 로직 실행
        yield return new WaitForSeconds(2f);
        // 게임의 시간을 멈춘다
        Time.timeScale = 0f;
    }

    public void GameHighScore()
    {
        ChangeState(State.HISCORE);
    }

    public void RestartGame()
    {
        // 현재 열려 있는 씬을 다시 처음부터 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
