using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovment : MonoBehaviour
{
    Vector2 playerDir;
    Vector3 playerPos;
    [SerializeField] float speed;
    Rigidbody2D rb;
    Animator playerAnim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        playerPos = playerDir;
        if (playerPos != Vector3.zero)
            playerAnim.SetBool("isRuning", true);
        else
            playerAnim.SetBool("isRuning", false);
        initBoundes();
    }

    private void initBoundes()
    {
        if (transform.position.x < -17.5)
        {
            if (playerPos.x < 0)
                playerPos.x = 0;
        }
        if (transform.position.x + 0.3 > 17.5)
        {
            if (playerPos.x > 0)
                playerPos.x = 0;
        }
        if (transform.position.y < -10)
        {
            if (playerPos.y < 0)
                playerPos.y = 0;
        }
        if (transform.position.y > 10)
        {
            if (playerPos.y > 0)
                playerPos.y = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerPos * speed * Time.deltaTime;
    }
    void OnMovment(InputValue value)
    {
        playerDir = value.Get<Vector2>();
    }
}
