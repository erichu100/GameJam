using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float fireDelay = 0.5f;
    private float timer = 0.5f;
    private float secondTimer = 1f;
    private float secondFireDelay = 1f;
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
        secondTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= fireDelay)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletAttributes attributes = bullet.GetComponent<BulletAttributes>();
            attributes.SetAfil(1);
            Destroy(bullet, 3);
            timer = 0f;
        }
        if (Input.GetMouseButton(1) && timer >= secondFireDelay)
        {
            for(int i = -1; i < 2; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                BulletAttributes attributes = bullet.GetComponent<BulletAttributes>();
                attributes.ChangeAngle(-5f * i);
                attributes.SetAfil(1);
                Destroy(bullet, 3);
            }
            timer = 0f;
        }
    }

}
