using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakerBehavior : EnemyBehavior
{

    private float speed = 10f;
    public float shootTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        approachPlayer(speed);
        if (shootTimer <= 0)
        {
            Shoot(bulletPrefab, firePoint, -15);
            Shoot(bulletPrefab, firePoint, 0);
            Shoot(bulletPrefab, firePoint, 15);
            shootTimer = 1f;
        }
        shootTimer -= Time.deltaTime;
    }
}
