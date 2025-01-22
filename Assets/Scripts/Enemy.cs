using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.isGameOver) return;

        transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.OnPlayerDead();
        }
    }
}
