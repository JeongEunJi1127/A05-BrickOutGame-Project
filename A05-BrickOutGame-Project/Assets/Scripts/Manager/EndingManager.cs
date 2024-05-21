using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int life = 3;
    private Vector2 ballMovement;
    private float speed;

    [SerializeField] private GameObject GameClearCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject[] LifeUI;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            speed = rb2d.velocity.magnitude;
            life -= 1;
            Invoke("ResetBall", 2f);
            rb2d.velocity = Vector2.down * speed;

            if(life == 0)
            {
                GameOverCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void ResetBall()
    {
        this.transform.position = Vector2.zero;
        LifeUI[life].SetActive(false);
    }    
}