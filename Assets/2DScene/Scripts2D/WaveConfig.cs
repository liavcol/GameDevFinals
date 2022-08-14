using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName ="New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs; // List of enemeis (I'm gonna loop over this list for enemy spawner)
    [SerializeField] Transform pathPrefab; // The enemy path (contains the all way points)
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float spwanTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;


    // Returns the number of enemies in the prefab list
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    // Get index and returns the enemy prefab in this index
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    // Becuase "pathPrefab" is private
    public Transform GetStartingWaypoints()
    {
        return pathPrefab.GetChild(0);
    }
    // Returns list of all the waypoints
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() 
    {
        return moveSpeed;
    }

    public float GetRandomSpwanTime()
    {
        float spwanTime = Random.Range(timeBetweenEnemySpawn - spwanTimeVariance,
                                      timeBetweenEnemySpawn + spwanTimeVariance);
        return Mathf.Clamp(spwanTime, minSpawnTime, float.MaxValue);
    }
}
