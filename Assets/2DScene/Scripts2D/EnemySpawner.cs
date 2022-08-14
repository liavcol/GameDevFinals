using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfig currentWave; // Referance to wave config file to store the enemy list
    [SerializeField] bool isLooping;
    
    void Start()
    {
        //SpawnEnemies();
        StartCoroutine(SpawnEnemyWaves());
    }


    // Loop throught enemyies in Our wave config file and create them
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    // To create an object in run-time I nees to use this function (generate enemies in run time)
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoints().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpwanTime());
                }
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        }
        while (isLooping);
       

    }

    //void SpawnEnemies()
    //{
    //    for (int i = 0; i < currentWave.GetEnemyCount(); i++)
    //    {
    //        // To create an object in run-time I nees to use this function (generate enemies in run time)
    //        Instantiate(currentWave.GetEnemyPrefab(i),
    //                    currentWave.GetStartingWaypoints().position,
    //                    Quaternion.identity,// No rotation
    //                    transform);
    //    }

    //}
    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }



}
