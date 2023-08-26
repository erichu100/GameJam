using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttributes : MonoBehaviour
{
    private float timer = 0;
    public float speed = 20f;
    public Rigidbody2D rb;
    //1 for player, 0 for enemy, 2 for neutral
    private int afil = 0;
    private int damage = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    public void SetAfil(int input)
    {
        afil = input;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        HealthManager health = other.GetComponent<HealthManager>();
        if(health == null)
        {
            //Destroy(gameObject);
        }
        else if(afil != health.GetAfil())
        {
            Debug.Log("Hit");
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        Destroy(gameObject);
        if(afil == 0)
        {
            //col.gameObject.name.equals
        }
    }
    */
}
