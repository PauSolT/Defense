using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    HealthComponent enemyHealth;
    public WaveManager waveManager;
    [SerializeField]
    EnemyInfo info;
    public EnemyInfo EnemyInfo { get => info; }

    public void InitEnemy()
    {
        enemyHealth = GetComponent<HealthComponent>();
        enemyHealth.MaxHealthPoints = info.healthBase + info.healthGrow * waveManager.Wave;
        enemyHealth.InitHealthComponent();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameObject bullet = collision.gameObject;
            bullet.TryGetComponent(out DamageComponent damageComponent);
            Destroy(bullet);
            if (enemyHealth.TakeDamage(damageComponent.DamagePoints))
            {
                Die();
            }
        }
    }

    void Die()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveManager.DecreaseEnemiesRemaining();
        Destroy(gameObject);
    }
}
