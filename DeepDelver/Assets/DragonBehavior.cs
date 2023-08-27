using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehavior : EnemyBehavior
{
     
    private int burstCounter = 0;
    private float shootTimer = 1f;
    private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        approachPlayer(speed);
        if (shootTimer <= 0)
        {
            Shoot(bulletPrefab, firePoint, 0);
            if(burstCounter < 3)
            {
                shootTimer = .1f;
                burstCounter++;
            }
            else
            {
                shootTimer = 1;
                burstCounter = 0;
            }
        }
        shootTimer -= Time.deltaTime;
    }
}
