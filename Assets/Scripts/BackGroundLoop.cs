using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    float height;   // ����� ���� ���� ����
    
    // Start is called before the first frame update
    void Awake()
    {
        // ���� ���̸� �����ϴ� ����
        var backgoundCollider = GetComponent<BoxCollider2D>();
        height = backgoundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -height)
        {
            if (GameManager.instance.isGameOver) return;

            Vector2 offset = new Vector2(0, height * 2f);
            transform.position = (Vector2)transform.position + offset;
        }

    }
}
