using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool is3Dcamera = false;

    public string targetTag = "switch";
    public GameObject score;
    public GameObject gameOverPanel;
    public float timeScaleIncreaseRate = 0.1f;
    private float timeSinceLastUpdate = 0f;
    private bool isGameOver = false;

    // Score 관리
    private static float globalScore = 0; // 전역 스코어 변수

    public float scoreIncreaseInterval = 0.1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ToggleChildObjectsByTag();
        ToggleCameraProjection();
    }

    void Start()
    {
        globalScore = 0;
        Time.timeScale = 1f;
        // 게임 시작 시 GameOverPanel 비활성화
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        isGameOver = false;
        StartCoroutine(IncreaseScoreOverTime());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            is3Dcamera = !is3Dcamera;
            ToggleCameraProjection();
            ToggleChildObjectsByTag();
        }
        timeSinceLastUpdate += Time.deltaTime; // 프레임마다 지난 시간 업데이트

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (isGameOver && Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Start");
        }
        if (IsPlayerExists() && !isGameOver)
        {
            if (timeSinceLastUpdate >= 10f) // 1초마다 Time.timeScale을 증가시킴
            {
                Time.timeScale += timeScaleIncreaseRate; // Time.timeScale을 증가
                timeSinceLastUpdate = 0f; // 지난 시간 초기화
                Debug.Log($"TimeScale: {Time.timeScale}"); // 현재 TimeScale 출력
            }
        }

        // 플레이어가 없는 경우, 0.7초 후에 게임 오버 실행
        if (!IsPlayerExists() && !isGameOver)
        {
            Time.timeScale = 1.0f;
            StartCoroutine(DelayedGameOver());
            Debug.Log($"TimeScale: {Time.timeScale}");
        }
    }

    private void ToggleCameraProjection()
    {
        Camera.main.orthographic = !is3Dcamera;
    }

    private void ToggleChildObjectsByTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objectsWithTag)
        {
            Transform child0 = obj.transform.GetChild(0);
            Transform child1 = obj.transform.GetChild(1);

            if (is3Dcamera)
            {
                child0.gameObject.SetActive(false);
                child1.gameObject.SetActive(true);
            }
            else
            {
                child0.gameObject.SetActive(true);
                child1.gameObject.SetActive(false);
            }
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            score.SetActive(false);
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverPanel is not set!");
        }

        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void RestartGame()
    {
        globalScore = 0;
        if (gameOverPanel != null)
        {
            score.SetActive(true);
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
        isGameOver = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    private IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreIncreaseInterval);

            // 플레이어가 존재하는지 확인
            if (IsPlayerExists())
            {
                IncreaseScore(0.1f);
            }
        }
    }

    public void IncreaseScore(float amount)
    {
        globalScore += amount; // 전역 스코어 업데이트
    }

    public static float GetScore()
    {
        return globalScore; // 전역 스코어 반환
    }

    // ⭐ 플레이어의 존재 여부 확인 메서드
    private bool IsPlayerExists()
    {
        GameObject player = GameObject.FindWithTag("Player");
        return player != null;
    }

    // ⭐ 플레이어가 사라졌을 때 0.7초 후에 GameOver 실행
    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(0.7f);
        GameOver();
    }
}