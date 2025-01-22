using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed = 3;
    public Vector2 vector;
    Rigidbody2D body;
    SpriteRenderer spriter;
    //Animator animator;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 nextVector = vector.normalized * speed * Time.fixedDeltaTime;
        body.MovePosition(body.position + nextVector);
    }
    private void LateUpdate()
    {
        //animator.SetFloat("Speed", vector.magnitude);
        if (vector.x != 0)
        {
            spriter.flipX = vector.x < 0;
        }
    }
}
