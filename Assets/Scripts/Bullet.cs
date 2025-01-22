using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public float lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    
        if (transform.position.y >= 12f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.instance.AddScore(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
