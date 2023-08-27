using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerBehavior : EnemyBehavior
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        rb.velocity = transform.up * speed;

    }
}
