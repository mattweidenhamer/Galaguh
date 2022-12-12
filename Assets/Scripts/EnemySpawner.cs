using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemies;
    //[SerializeField] GameObject[] waypointList;
    private float timeSinceLastSpawn = 0f;
    
    private void Start() {
        spawnEnemy();
    }
    private void spawnEnemy() {
        if(transform.childCount < maxEnemies){
            GameObject newObject = Instantiate(enemy, transform.position, Quaternion.identity);
            //newObject.GetComponent<Enemy>().waypoints = waypointList;
        }

    }


    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns){
            timeSinceLastSpawn = 0f;
            spawnEnemy();
        }
    }
}
