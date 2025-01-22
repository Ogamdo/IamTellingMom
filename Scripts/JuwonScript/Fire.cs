using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Sensor sensor; // Sensor ��ũ��Ʈ ����
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private void Start()
    {
        // ���� �ð� �������� �ڵ� �߻� ����
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

        //Debug.Log($"�ڵ� �߻�! Ÿ�� ��ġ: {targetPosition}");
    }
}
