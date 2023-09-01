using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public List<Transform> spawners;
    public GameObject enemy;

    public int Wave { get; set; }

    int waveEnemies;
    int enemiesToSpawn;
    static int enemiesRemaining;


    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }


    public void StartWave()
    {
        PlayerPrefs.DeleteKey("wave");
        Wave = PlayerPrefs.GetInt("wave", 1);
        waveEnemies = -1 + Wave * 2;
        enemiesToSpawn = waveEnemies;
        enemiesRemaining = waveEnemies;
        StartCoroutine(WaitForWaveToStart());
    }

    IEnumerator WaitForWaveToStart()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnEnemy());

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

    public void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        if (enemiesRemaining == 0)
        {
            EndWave();
        }
    }

    void EndWave()
    {
        Wave++;
        PlayerPrefs.SetInt("wave",Wave);

    }
}
