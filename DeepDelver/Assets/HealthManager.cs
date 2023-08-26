using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //3 hearts
    //Public for easy changing
    public int health = 3;
    public int afil = 1;
    // Start is called before the first frame update
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int input)
    {
        health = input;
    }
    public int GetAfil() { return afil; }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
