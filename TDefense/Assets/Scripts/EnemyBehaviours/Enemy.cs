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
    FireBullets fireBullets;

    public void InitEnemy()
    {
        enemyHealth = GetComponent<HealthComponent>();
        fireBullets = FindObjectOfType<FireBullets>();
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
            Destroy(collision.gameObject);
            int bulletDamage = fireBullets.CurrentBulletDamage;
            float isCrit = Random.Range(0f, 100f);

            if (isCrit < fireBullets.CritRate)
            {
                Debug.Log(bulletDamage);
                bulletDamage = Mathf.RoundToInt(bulletDamage * (1 + fireBullets.CritDamage / 100));
                Debug.Log(bulletDamage);
            }

            if (enemyHealth.TakeDamage(bulletDamage))
            {
                Die();
            }
        }
    }

    void Die()
    {
        PlayerUpgrades.moneyGeneratedThisRound++;
        waveManager = FindObjectOfType<WaveManager>();
        waveManager.DecreaseEnemiesRemaining();
        Destroy(gameObject);
    }

    public void PlayerDamaged()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveManager.DecreaseEnemiesRemaining();
        Destroy(gameObject);
    }
}
