using UnityEngine;
using System.Collections;
/// <summary>
/// 적 웨이브 생성과 진행을 관리하는 클래스
/// </summary>
public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;     // 생성할 적 프리팹
        public int count;                  // 적 생성 수
        public float spawnDelay;           // 생성 간격
    }

    [Header("웨이브 설정")]
    [SerializeField] private Wave[] waves;                     // 웨이브 정보 배열
    [SerializeField] private float timeBetweenWaves = 5f;     // 웨이브 간 대기 시간
    [SerializeField] private Transform[] spawnPoints;          // 적 생성 위치들
} 