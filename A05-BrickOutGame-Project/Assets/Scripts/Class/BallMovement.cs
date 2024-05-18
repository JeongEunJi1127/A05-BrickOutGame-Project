using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BallMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 BallMovementDirection = Vector2.zero;
    [SerializeField]private float speed = 10f;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // ���� �� �� �������� �ϱ�
        rb2d.velocity = Vector2.down * speed;
        controller.OnAimEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        BallMovementDirection = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // gameObject�� Layer�� Paddle���� Ȯ��
        if (collision.gameObject.layer == 6)
        {
            rb2d.velocity = BallMovementDirection;
        }
    }

    public float SetBallSpeed()
    {
        return speed;
    }

    public void GetBallSpeed(float applySpeed)
    {
        speed = applySpeed;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 6)
    //    {
    //        rb2d.velocity = BallMovementDirection;
    //    }
    //}
}
