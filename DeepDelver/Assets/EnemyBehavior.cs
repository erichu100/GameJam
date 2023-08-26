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
    protected void clearEnemies()
    {
        Destroy(this);
    } 
}
