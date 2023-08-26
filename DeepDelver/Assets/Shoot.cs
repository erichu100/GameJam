using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private static float fireDelay = 0.5f;
    private static float timer = fireDelay;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= fireDelay)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletAttributes attributes = bullet.GetComponent<BulletAttributes>();
            attributes.SetAfil(1);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Destroy(bullet, 5);
            timer = 0f;
        }
    }
}
