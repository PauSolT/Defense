using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaveManager : MonoBehaviour
{
    public UIGame uiGame;
    public Player player;

    public GameObject tutorial;

    public List<Transform> spawners;
    public List<GameObject> enemiesWave;
    public List<GameObject> enemies;
    public List<EnemyInfo> enemyInfos;

    [SerializeField]
    int wave = 1;
    public int Wave { get => wave; set => wave = value; }

    [SerializeField]
    int enemiesRemaining;

    int beforeSpawner;

    float cooldownToSpawnEnemy;

    bool lastEnemyKilled;



    // Start is called before the first frame update
    void Start()
    {
        beforeSpawner = -1;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            SetUpEnemyInfo();
            StartWave();
            cooldownToSpawnEnemy = 1f - (wave*0.01f);
            if (cooldownToSpawnEnemy < 0.1f)
            {
                cooldownToSpawnEnemy = 0.1f;
            }
        
        } else
        {
            Wave = PlayerPrefs.GetInt("wave", 1);
            uiGame.waveText.text = "WAVE " + Wave;
        }

    }


    public void StartWave()
    {
        Wave = PlayerPrefs.GetInt("wave", 1);
        uiGame.waveText.text = "WAVE " + Wave;
        AddEnemiesToWave();
        enemiesRemaining = enemiesWave.Count;
        StartCoroutine(WaitForWaveToStart());
    }

    IEnumerator WaitForWaveToStart()
    {
        yield return new WaitForSeconds(2f);
        tutorial.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (enemiesWave.Count > 0)
        {
            int randomSpawner = Random.Range(0, spawners.Count);
            if (randomSpawner == beforeSpawner)
            {
                randomSpawner += 1;
                if (randomSpawner >= spawners.Count)
                {
                    randomSpawner = 0;
                }
            }
            GameObject enemy = Instantiate(enemiesWave[0], spawners[randomSpawner].position, enemiesWave[0].transform.rotation);
            enemy.GetComponent<Enemy>().waveManager = this;
            enemiesWave.RemoveAt(0);
            beforeSpawner = randomSpawner;
            yield return new WaitForSeconds(cooldownToSpawnEnemy);
        }
        yield return null;
    }

    public void DecreaseEnemiesRemaining()
    {
        enemiesRemaining--;
        if(enemiesRemaining != 0)
        {
            CheckIfPlayerIsDead();
        }

        if (enemiesRemaining == 0)
        {
            print(lastEnemyKilled);
            CheckIfWaveEnded();
        }
    }

    void CheckIfWaveEnded()
    {
        if (player.playerHealth.CurrentHealthPoints - 1<= 0 && !lastEnemyKilled)
        {
            uiGame.WaveLost();
           
        } else
        {
            EndWave();
        }
    }

    public void CheckIfPlayerIsDead()
    {

        if (player.playerHealth.CurrentHealthPoints -1<= 0)
        {
            uiGame.WaveLost();
        }
    }

    public void LastEnemyIsKilled(bool isKilled)
    {
        lastEnemyKilled = isKilled;
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
