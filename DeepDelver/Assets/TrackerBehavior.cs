using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerBehavior : EnemyBehavior
{
    private float speed = 8f;
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
            Shoot(bulletPrefab, firePoint);
            shootTimer = 1f;
        }
        shootTimer -= Time.deltaTime;
    }
}
