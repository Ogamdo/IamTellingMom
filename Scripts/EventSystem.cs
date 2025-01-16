using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 게임 내 이벤트와 컷신을 관리하는 시스템 클래스
/// </summary>
public class EventSystem : MonoBehaviour
{
    [System.Serializable]
    public class GameEvent
    {
        public string eventName;           // 이벤트 이름
        public UnityEvent onEventTriggered;// 이벤트 발생 시 실행될 액션
    }

    [Header("이벤트 설정")]
    [SerializeField] private GameEvent[] gameEvents;       // 게임 이벤트 목록
    [SerializeField] private GameObject bossPrefab;        // 보스 프리팹
    [SerializeField] private Transform bossSpawnPoint;     // 보스 생성 위치
} 