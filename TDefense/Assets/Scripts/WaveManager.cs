using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public UIGame uiGame;

    public List<Transform> spawners;
    public List<GameObject> enemiesWave;
    public List<GameObject> enemies;
    public List<EnemyInfo> enemyInfos;

    [SerializeField]
    int wave = 1;
    public int Wave { get => wave; set => wave = value; }

    [SerializeField]
    int enemiesRemaining;


    // Start is called before the first frame update
    void Start()
    {
        SetUpEnemyInfo();
        StartWave();
    }


    public void StartWave()
    {
        //PlayerPrefs.DeleteKey("wave");
        Wave = PlayerPrefs.GetInt("wave", 1);
        uiGame.waveText.text = "WAVE " + Wave;
        AddEnemiesToWave();
        enemiesRemaining = enemiesWave.Count;
        StartCoroutine(WaitForWaveToStart());
    }

    IEnumerator WaitForWaveToStart()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (enemiesWave.Count > 0)
        {
            int randomSpawner = Random.Range(0, spawners.Count);
            GameObject enemy = Instantiate(enemiesWave[0], spawners[randomSpawner].position, enemiesWave[0].transform.rotation);
            enemy.GetComponent<Enemy>().waveManager = this;
            enemiesWave.RemoveAt(0);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    public void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        CheckIfPlayerIsDead();
        if (enemiesRemaining == 0)
        {
            CheckIfWaveEnded();
        }
    }

    void CheckIfWaveEnded()
    {
        if (!Player.PlayerIsAlive)
        {
            uiGame.WaveLost();
           
        } else
        {
            EndWave();
        }
    }

    public void CheckIfPlayerIsDead()
    {
        if (!Player.PlayerIsAlive)
        {
            uiGame.WaveLost();
        }
    }

    public void EndWave()
    {
        enemiesWave.Clear();
        enemiesWave.TrimExcess();
        Wave++;
        PlayerPrefs.SetInt("wave",Wave);
        uiGame.WaveWon();
    }

    void SetUpEnemyInfo()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemyInfos.Add(enemies[i].GetComponent<Enemy>().EnemyInfo);
        }
    }

    void AddEnemiesToWave()
    {
        for (int i = 0; i < enemyInfos.Count-1; i++)
        {
            EnemyInfo info = enemyInfos[i];
            int numberOfEnemy;
            int enemyWave = Wave - info.waveRequirement;

            if (Wave < info.waveRequirement)
                continue;

            numberOfEnemy = (Mathf.FloorToInt(enemyWave / info.wavesToGrow) + 1) * info.waveGrow;
            if (wave % 20 == 0)
            {
                numberOfEnemy = Mathf.FloorToInt(numberOfEnemy / 2);
            }
            if (i == 0)
            {
                numberOfEnemy += 3;
            }

            for (int j = 0; j < numberOfEnemy; j++)
            {
                enemiesWave.Add(enemies[i]);
            }
        }

        Shuffle(enemiesWave);

        if (wave % 20 == 0)
        {
            enemiesWave.Insert(0, enemies[enemyInfos.Count - 1]);
        }
    }

    public void Shuffle(List<GameObject> ts)
    {
        int count = ts.Count;
        int last = count - 1;
        for (int i = 0; i < last; ++i)
        {
            int r = Random.Range(i, count);
            GameObject tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

}
