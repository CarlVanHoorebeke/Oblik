using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public static BallMovement instance;
    Rigidbody2D rb;
    public bool isStarted;
    public float currentSpeed;
    public bool isGoingRight;
    bool isAlive = true;

    private void OnEnable()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if(isStarted && isAlive)
        {
            Move();
        }
    }

    void Move()
    {
        if (isGoingRight)
        {
            rb.velocity = Vector3.right * currentSpeed  * Time.deltaTime + Vector3.up * currentSpeed * 0.5f  * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.left * currentSpeed  * Time.deltaTime + Vector3.up * currentSpeed * 0.5f  * Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("on collision stay " + collision.tag);
        if (collision.tag == "Death")
        {
            Debug.Log("on collision stay phat");
            isAlive = false;
            rb.velocity = Vector3.zero;
            MenuController.instance.GameOver();
        }
    }
}
