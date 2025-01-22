using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject[] bombIcon;

    Vector2 moveInput;
    Rigidbody2D rb;
    int bombCount = 3;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Fire();
        }
    }

    public void OnBoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Boom();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    void Boom()
    {
        if (bombCount <= 0) return;
        bombCount--;
        bombIcon[bombCount].gameObject.SetActive(false);
        var enemys = FindObjectsOfType<Enemy>();
        int scoreCount = enemys.Length + 1;
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i].gameObject);         
        }
        GameManager.instance.AddScore(scoreCount * 100);
    }

    void FixedUpdate()
    {
        Vector2 input = joystick.InputVector;
        Vector2 movement = input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
