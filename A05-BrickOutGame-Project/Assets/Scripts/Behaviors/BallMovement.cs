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
        BallMovementDirection = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // gameObject�� Layer�� Paddle���� Ȯ��
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 6)
        {
            rb2d.velocity = BallMovementDirection * speed;
        }
    }

    public float SetBallSpeed()
    {
        return speed;
    }

    // applySpeed = ���� speed * itemspeed
    public void GetBallSpeed(float applySpeed)
    {
        // ������ velocity �� ����ȭ�� ������ �� apply speed�� ������
        Vector2 nwVelocity = rb2d.velocity.normalized;
        speed = applySpeed;
        rb2d.velocity = nwVelocity * speed;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 6)
    //    {
    //        rb2d.velocity = BallMovementDirection;
    //    }
    //}
}
