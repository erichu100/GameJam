using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakerBehavior : EnemyBehavior
{
    private float speed = 5f;
    public Rigidbody2D rb;

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
