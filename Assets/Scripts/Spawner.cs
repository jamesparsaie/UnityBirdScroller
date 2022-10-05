using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;
    public GameObject coin;
    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoinSpawn();
    }

    // This handles the spawning of obstacles
    void Update()
    {
        if(timeBetweenSpawn <= 0){
            int index = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[index], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if(startTimeBetweenSpawn > minTime){
                startTimeBetweenSpawn -= decreaseTime;
            }
        } else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    public void StartCoinSpawn(){
        StartCoroutine("SpawnCoins");
    }
    //Helper method to help spawning of coins for player to collect
    IEnumerator SpawnCoins(){
        int SpawnPoint = Random.Range(0, 1);
        if(SpawnPoint == 0){
            Instantiate(coin, new Vector3(12, 2, 0), Quaternion.identity);
        } else {
            Instantiate(coin, new Vector3(12, 4, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
        StartCoroutine("SpawnCoins");
    }
}
