using UnityEngine;
using System.Collections;
/// <summary>
/// 플레이어 캐릭터의 동작과 상태를 관리하는 클래스
/// </summary>
public class Player : MonoBehaviour
{
    [Header("플레이어 스탯")]
    [SerializeField] private float moveSpeed = 5f;      // 이동 속도
    [SerializeField] private float health = 100f;       // 체력
    [SerializeField] private float attackDamage = 10f;  // 공격력
} 