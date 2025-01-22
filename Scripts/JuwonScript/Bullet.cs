using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int time = 3;

    public void Init(float damage, int per)
    {
        this.damage = damage;
    }

    private void Start()
    {
        Destroy(gameObject, time);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
