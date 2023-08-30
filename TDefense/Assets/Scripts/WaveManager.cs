using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public List<Transform> spawners;
    public GameObject enemy;

    public int Wave { get; set; } = 1;

    int waveEnemies;
    int enemiesToSpawn;
    static int enemiesRemaining;


    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }


    void StartWave()
    {
        waveEnemies = 3 + Wave * 2;
        enemiesToSpawn = waveEnemies;
        enemiesRemaining = waveEnemies;
        StartCoroutine(WaitForWaveToStart());
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator WaitForWaveToStart()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator SpawnEnemy()
    {
        while (enemiesToSpawn > 0)
        {
            int randomSpawner = Random.Range(0, spawners.Count);
            Instantiate(enemy, spawners[randomSpawner].position, enemy.transform.rotation);
            enemiesToSpawn--;
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    static public void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        if (enemiesRemaining == 0)
            Debug.Log("Wave destroyed");
    }
}
