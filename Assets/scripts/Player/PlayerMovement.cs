using System;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float dashMultiply = 3;
    public float dashCooldown = 1.5f;
    public float dashTime = 0.5f;
    float remainingDashTime = 1f;
    bool isDashing = false;
    bool dashReady = true;
    Vector3 moveVector;
    Vector3 lastMoveVector;
    SimpleTimer timer;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = GetComponent<SimpleTimer>();
        timer.timerFinished.AddListener(TimerFinished);
        lastMoveVector = Vector3.up;
        remainingDashTime = dashTime;
    }

    private void Update()
    {
        PlayerDashControl();
        if (!isDashing)
        {
            PlayerMoveControl();
        }
    }

    void PlayerMoveControl()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;


        moveVector = new Vector3(horizontal, vertical, 0);

        Vector3 moveVectorNormalized = Vector3.Normalize(moveVector);
        

        if (Vector3.Magnitude(moveVectorNormalized) > 0.001f)
        {
            lastMoveVector = moveVector;
        }

        rb.velocity = moveVector;
    }

    void PlayerDashControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space pressed");
            if (dashReady)
            {
                isDashing = true;
                PlayerDash();
                dashReady = false;
                timer.StartTimer(dashCooldown);
            }
        }
        if (isDashing)
        {
            remainingDashTime -= Time.deltaTime;
            if (remainingDashTime <= 0)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;
                remainingDashTime = dashTime;
            }
        }
    }

    void PlayerDash()
    {
        Debug.Log("dash started");
        Vector3 dir = Vector3.Normalize(lastMoveVector);
        rb.velocity = dir * dashMultiply;
    }


    private void TimerFinished()
    {
        dashReady = true;
    }

}
