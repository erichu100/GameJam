using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : EnemyBehavior
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float moveTimer = 0.2f;
    public float shootTimer = 0f;
    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        facePlayer();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
            if(shootTimer <= 0)
            {
                Shoot(bulletPrefab, firePoint);
                shootTimer = 1f;
            }
            shootTimer -= Time.deltaTime;
        }
    }


}
