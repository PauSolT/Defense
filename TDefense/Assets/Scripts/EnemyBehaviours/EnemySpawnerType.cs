using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerType : MonoBehaviour
{
    public GameObject enemyToSpawn;

    private void OnDestroy()
    {
        Vector3 ySpawnPosition;
        if (transform.position.y < 0)
            ySpawnPosition = Vector3.up;
        else
            ySpawnPosition = -Vector3.up;

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            Instantiate(enemyToSpawn, transform.position, transform.rotation);
            Instantiate(enemyToSpawn, transform.position + Vector3.right, transform.rotation);
            Instantiate(enemyToSpawn, transform.position + ySpawnPosition, transform.rotation); 
            Instantiate(enemyToSpawn, transform.position + ySpawnPosition + Vector3.right, transform.rotation);
        }
    }
}
