using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : Spawner
{
    public GameObject object1;
    //public GameObject nextWave;
    float clock = 0f;
    float totalDuration = 30f;
    float baseSpawnInterval1 = 2.8f;
    float spawnInterval1 = 2.8f;
    
    // Update is called once per frame
    void Update()
    {
        PreWaveLoop();
        CheckNextWave();
        if (waveStarted)
        {
            clock += Time.deltaTime;
            //Debug.Log(clock);
            if (clock >= spawnInterval1 && !waveFinished)
            {
                SpawnObject(object1);
                spawnInterval1 += baseSpawnInterval1;
            }

            HealthManager health = target.GetComponent<HealthManager>();
            if (IsPlayerDead())
            {
                clock = 0f;
                spawnInterval1 = baseSpawnInterval1;
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
