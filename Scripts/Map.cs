using UnityEngine;
using Cinemachine;

/// <summary>
/// 게임 맵과 카메라 동작을 관리하는 클래스
/// </summary>
public class Map : MonoBehaviour
{
    [Header("카메라 설정")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;    // 가상 카메라
    [SerializeField] private float cameraFollowSpeed = 5f;            // 카메라 추적 속도
    [SerializeField] private Vector2 cameraDeadzone = new Vector2(0.1f, 0.1f);  // 카메라 데드존

    [Header("맵 경계 설정")]
    [SerializeField] private Vector2 mapSize = new Vector2(100f, 100f);  // 맵 크기
    [SerializeField] private bool showMapBoundaries = true;              // 경계선 표시 여부
} 