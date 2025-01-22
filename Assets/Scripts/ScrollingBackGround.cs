using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public float speed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        transform.Translate(Vector3.down * speed * Time.deltaTime);        
    }
}
