using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 rawLoc;
    protected GameObject target;
    private Camera screen;
    private int width;
    private int height;
    protected Vector3 center = new Vector3(0, 0, 0);
    protected Vector3 spawnPoint;
    protected Rigidbody2D rb;
    protected bool preWave = true;
    protected bool waveStarted = false;
    protected bool waveFinished = false;
    protected bool playerNear = false;
    protected bool offScreen = false;

    // Start is called before the first frame update
    protected void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        screen = Camera.main;

        int width = screen.pixelWidth;
        int height = screen.pixelHeight;
        rawLoc = new Vector3(width / 2, 0, 0);
        spawnPoint = screen.ScreenToWorldPoint(rawLoc) + new Vector3(0, 0, 10);

    }

    protected Vector3 randomBorder()
    {

        //0: left, 1: up, 2: right, 3: down
        int side = Mathf.RoundToInt(Random.Range(0f, 3f));
        if (side == 0)
        {
            rawLoc = new Vector3(0, Random.Range(0, 1f), screen.nearClipPlane);
        }
        if (side == 1)
        {
            rawLoc = new Vector3(Random.Range(0, 1f), 1, screen.nearClipPlane);
        }
        if (side == 2)
        {
            rawLoc = new Vector3(1, Random.Range(0, 1f), screen.nearClipPlane);
        }
        else
        {
            rawLoc = new Vector3(Random.Range(0, 1f), 0, screen.nearClipPlane);
        }
        
        return screen.ViewportToWorldPoint(rawLoc) + new Vector3(0, 0, 10f);
    }

    protected void Descend()
    {
        
    }

    protected void RestartWave()
    {
        Debug.Log(transform.childCount);
        for(int i = transform.childCount - 1; i >= 0; i--){
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == target.name)
        {
            playerNear = true;
            Debug.Log("among us");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == target.name)
        {
            playerNear = false;
            Debug.Log("amogus");
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("Off Screen");
        offScreen = true;
    }

    protected bool IsPlayerDead()
    {
        HealthManager health = target.GetComponent<HealthManager>();
        if (health != null)
        {
            int h = health.GetHealth();
            //Doesn't work when not nested for some reason.
            if (h <= 0)
            {
                Debug.Log("ded");
                RestartWave();
                health.SetHealth(3);
                return true;
            }
        }
        return false;
    }

    protected void CheckTowardsCenter()
    {
        if (preWave)
        {
            Vector3 nextLocation = Vector3.MoveTowards(transform.position, center, 5f*Time.deltaTime);
            transform.position = nextLocation;
            if(transform.position == center)
            {
                preWave = false;
            }
        }
    }
}
