using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public List<Transform> spawners;
    public GameObject normal;
    public GameObject tank;
    public GameObject fast;
    public GameObject buffer;
    public GameObject zigzag;
    public GameObject spawner;
    public GameObject boss;

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
            Instantiate(normal, spawners[randomSpawner].position, normal.transform.rotation);
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
