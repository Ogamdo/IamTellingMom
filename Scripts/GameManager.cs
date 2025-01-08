/// <summary>
/// 전체 게임 진행과 상태를 관리하는 매니저 클래스
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("게임 오브젝트")]
    [SerializeField] private GameObject playerPrefab;    // 플레이어 프리팹
    
    public bool isGameOver { get; private set; }        // 게임 종료 상태
    public float gameTime { get; private set; }         // 게임 진행 시간
} 