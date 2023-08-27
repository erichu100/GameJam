using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject target;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;

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

    protected void approachPlayer(float speed)
    {
        Vector3 nextLocation = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = nextLocation;
    }

    protected void Shoot(GameObject bulletPrefab, Transform firePoint, int offset = 0)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletAttributes attributes = bullet.GetComponent<BulletAttributes>();
        attributes.SetAfil(0);
        attributes.ChangeAngle(offset);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Destroy(bullet, 3);
    }
}
