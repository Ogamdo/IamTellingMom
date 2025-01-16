using UnityEngine;

/// <summary>
/// 적 캐릭터의 기본 동작을 관리하는 클래스
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("적 기본 스탯")]
    [SerializeField] private float health = 50f;        // 체력
    [SerializeField] private float moveSpeed = 3f;      // 이동 속도
    [SerializeField] private float attackDamage = 10f;  // 공격력
} 