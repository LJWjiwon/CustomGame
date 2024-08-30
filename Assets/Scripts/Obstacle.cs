using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            GameManager.gamemanager.AddScore(1);
            GameObject.Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.gamemanager.PlayerDead();
        }
    }

   
}
