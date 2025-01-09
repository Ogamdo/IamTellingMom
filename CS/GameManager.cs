using UnityEngine;
using System.Collections;

/// <summary>
/// 전체 게임 진행과 상태를 관리하는 싱글톤 매니저 클래스
/// </summary>
public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    private static GameManager instance = null;
    
    // 전역 접근을 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없다면 찾아보기
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                
                // 씬에도 없다면 새로 생성
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    [Header("게임 오브젝트")]
    [SerializeField] private GameObject playerPrefab;    // 플레이어 프리팹

    [Header("게임 상태")]
    private bool isGameOver = false;       // 게임 종료 상태
    private float gameTime = 0f;           // 게임 진행 시간
    private int score = 0;                 // 현재 점수
    private int highScore = 0;             // 최고 점수

    // 게임 상태 프로퍼티들
    public bool IsGameOver => isGameOver;
    public float GameTime => gameTime;
    public int Score => score;
    public int HighScore => highScore;

    [Header("씬 관리")]
    private const string GAME_SCENE_NAME = "GameScene";  // 게임 씬 이름

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        else
        {
            // 이미 인스턴스가 존재하면 이 오브젝트 제거
            if (this != instance)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 매니저 초기화
    /// </summary>
    private void InitializeManager()
    {
        LoadGameData();
        ResetGameState();
    }

    /// <summary>
    /// 게임 상태 초기화
    /// </summary>
    private void ResetGameState()
    {
        isGameOver = false;
        gameTime = 0f;
        score = 0;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;
            UpdateGameState();
        }
    }

    /// <summary>
    /// 게임 상태 업데이트
    /// </summary>
    private void UpdateGameState()
    {
        // 게임 진행 상태 체크 및 업데이트
        CheckGameOver();
    }

    /// <summary>
    /// 게임 시작
    /// </summary>
    public void StartGame()
    {
        ResetGameState();
        SpawnPlayer();
        // 게임 시작 이벤트 발생
        EventSystem.Instance?.TriggerEvent("GameStart");
    }

    /// <summary>
    /// 게임 오버 처리
    /// </summary>
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            UpdateHighScore();
            SaveGameData();
            // 게임 오버 이벤트 발생
            EventSystem.Instance?.TriggerEvent("GameOver");
        }
    }

    /// <summary>
    /// 플레이어 생성
    /// </summary>
    private void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("플레이어 프리팹이 설정되지 않았습니다!");
        }
    }

    /// <summary>
    /// 점수 추가
    /// </summary>
    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            // 점수 변경 이벤트 발생 가능
        }
    }

    /// <summary>
    /// 최고 점수 업데이트
    /// </summary>
    private void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    /// <summary>
    /// 게임 데이터 저장
    /// </summary>
    private void SaveGameData()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 게임 데이터 로드
    /// </summary>
    private void LoadGameData()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    /// <summary>
    /// 게임 오버 조건 체크
    /// </summary>
    private void CheckGameOver()
    {
        // 게임 오버 조건 체크
        // 예: 플레이어 사망, 시간 초과 등
    }

    /// <summary>
    /// 게임 일시정지
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
        // 일시정지 이벤트 발생
        EventSystem.Instance?.TriggerEvent("GamePaused");
    }

    /// <summary>
    /// 게임 재개
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        // 게임 재개 이벤트 발생
        EventSystem.Instance?.TriggerEvent("GameResumed");
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    /// <summary>
    /// 다음 씬(게임 씬)으로 전환
    /// </summary>
    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        // 현재 씬 페이드 아웃 등의 효과를 줄 수 있음
        ResetGameState();
        yield return new WaitForSeconds(0.5f); // 전환 효과를 위한 대기 시간
        
        // 씬 로드
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME_SCENE_NAME);
        
        // 게임 시작 처리
        StartGame();
    }
} 