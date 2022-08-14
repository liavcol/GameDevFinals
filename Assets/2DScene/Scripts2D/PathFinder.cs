using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
   
    EnemySpawner enemySpwaner;
    WaveConfig waveConfig; // Associates the waypoint list to our script
    List<Transform> waypoints; // Get from our scriptable object
    int waypointIndex = 0;

    // To find the object which will exist in our scene
    void Awake()
    {
        enemySpwaner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpwaner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints(); //Get the waypoint list
        transform.position = waypoints[waypointIndex].position;
    }
    
    void Update()
    {
        FollowPath(); 
    }
    // Move from waypoint to next waypoint on the list
    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position; // The next waypoint
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // The distance in each frame
            //curr position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(Vector2.Distance(transform.position,targetPosition)< 0.1f)
            {
                waypointIndex++;
            }
        }
        // We get to the end of waypoints
        else
        {
            Destroy(gameObject);
        }
    }
}
