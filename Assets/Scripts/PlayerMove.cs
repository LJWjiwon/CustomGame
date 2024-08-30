using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 100f;
    private Rigidbody2D PlayerRigidbody;
    public bool isGround;

    public void Update()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        if (!GameManager.gamemanager.isGameover)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isGround == true)
                {
                    PlayerRigidbody.velocity = Vector2.zero;
                    PlayerRigidbody.AddForce(new Vector2(0, jumpForce));

                    isGround = false;

                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        PlayerRigidbody.velocity = PlayerRigidbody.velocity * 0.7f;
                    }
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Die"))
        {
            GameManager.gamemanager.isGameover = true;
            Die();
        }
    }

    public void Die()
    {
        PlayerRigidbody.velocity = Vector2.zero;

        GameManager.gamemanager.PlayerDead();
    }
}
