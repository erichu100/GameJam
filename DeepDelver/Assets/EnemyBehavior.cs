using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject target;
    protected void facePlayer()
    {
        target = GameObject.Find("Player");
        if(target != null)
        {
            Transform targetPosition = target.GetComponent<Transform>();
            Vector3 relativePosition = targetPosition.position - transform.position;
            transform.up = relativePosition;
        }

    }
    protected void Shoot(GameObject bulletPrefab, Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletAttributes attributes = bullet.GetComponent<BulletAttributes>();
        attributes.SetAfil(0);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Destroy(bullet, 5);
    }
}
