using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : Spawner
{
    public GameObject object1;
    public GameObject nextWave;
    float clock = 0f;
    float totalDuration = 0f;
    float spawnInterval1 = 5f;
    
    // Update is called once per frame
    void Update()
    {
        if (waveFinished)
        {
            rb.velocity = transform.up * 5f;
            if (offScreen)
            {
                Instantiate(nextWave, spawnPoint, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (playerNear && !preWave)
        {
            if (Input.GetKey(KeyCode.K)) {
                waveStarted = true;
            }
        }
        else if (preWave)
        {
            CheckTowardsCenter();
        }
        if (waveStarted)
        {
            clock += Time.deltaTime;
            //Debug.Log(clock);
            if (clock >= spawnInterval1 && !waveFinished)
            {
                Vector3 loc = randomBorder();
                Instantiate(object1, loc, Quaternion.identity, transform);
                spawnInterval1 += spawnInterval1;
            }

            HealthManager health = target.GetComponent<HealthManager>();
            if (IsPlayerDead())
            {
                totalDuration = 60f;
                spawnInterval1 = 5f;
            }
            if (clock >= totalDuration)
            {
                waveStarted = false;
                if (transform.childCount == 0)
                {
                    Debug.Log("Wave done");
                    waveFinished = true;
                }
            }
        }
    }


}
