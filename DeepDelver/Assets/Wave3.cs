using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : Spawner
{
    public GameObject turret;
    public GameObject tracker;
    public GameObject dragon;
    //public GameObject nextWave;
    float clock = 0f;
    float totalDuration = 40f;
    float baseSpawnInterval1, spawnInterval1 = 4.8f;
    float baseSpawnInterval2, spawnInterval2 = 2.4f;
    float baseSpawnInterval3, spawnInterval3 = 3.8f;

    // Update is called once per frame
    void Update()
    {
        PreWaveLoop();
        CheckNextWave();
        if (waveStarted)
        {
            clock += Time.deltaTime;
            //Debug.Log(clock);
            if (!waveFinished)
            {
                //Modulo results in running multiple times per frame.
                if (clock >= spawnInterval1)
                {
                    SpawnObject(turret);
                    spawnInterval1 += baseSpawnInterval1;
                }
                if (clock >= spawnInterval2)
                {
                    SpawnObject(tracker);
                    spawnInterval2 += baseSpawnInterval2;
                }
                if (clock >= spawnInterval3)
                {
                    SpawnObject(tracker);
                    spawnInterval3 += baseSpawnInterval3;
                }
            }
            HealthManager health = target.GetComponent<HealthManager>();
            if (IsPlayerDead())
            {
                clock = 0f;
                spawnInterval1 = 2.8f;
                spawnInterval2 = 4.8f;
            }
            if (clock >= totalDuration)
            {
                waveStarted = false;
                if (transform.childCount == 0)
                {
                    waveFinished = true;
                }
            }
        }
    }
}
