using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSalta : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed, forceJump;
    float jump, timer = 0.3f;
    bool highJump, ground;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        Vector2 position = rigidbody2d.position;
        position.x += horizontal * speed * Time.timeScale;
        rigidbody2d.position = position;

        if (!Mathf.Approximately(jump, 0.0f) && ground)
        {

            rigidbody2d.AddForce(Vector2.up * forceJump * Time.timeScale);
        }

        if (!ground)
        {
            timer -= Time.timeScale;
        }

        if (!ground && timer <= 0.0f && highJump)
        {
            if (!Mathf.Approximately(jump, 0.0f))
            {

                rigidbody2d.AddForce(Vector2.up * (forceJump + 50) * Time.timeScale);
                highJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        highJump = true;
        ground = true;
        timer = 0.3f;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        ground = false;
    }
}
