using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Sensor sensor; // Sensor 스크립트 참조
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private void Start()
    {
        // 일정 시간 간격으로 자동 발사 시작
        InvokeRepeating(nameof(AutoFire), 0f, fireRate);
    }

    void AutoFire()
    {
        if (sensor != null && sensor.nearestTarget != null)
        {
            Shoot(sensor.nearestTarget.position);
        }
    }

    void Shoot(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (targetPosition - firePoint.position).normalized;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed;

        //Debug.Log($"자동 발사! 타겟 위치: {targetPosition}");
    }
}
