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
        info.money = waveManager.Wave;
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
                bulletDamage = Mathf.RoundToInt(bulletDamage * (1 + fireBullets.CritDamage / 100));
            }

            if (enemyHealth.TakeDamage(bulletDamage))
            {
                Die();
            }
        }
    }

    void Die()
    {
        PlayerUpgrades.MoneyGeneratedThisRound += info.money;
        waveManager = FindObjectOfType<WaveManager>();
        waveManager.DecreaseEnemiesRemaining();
        if (Player.PlayerIsAlive)
        {
            waveManager.CheckIfWaveEnded();
        }
        Destroy(gameObject);
    }

    public void PlayerDamaged()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveManager.DecreaseEnemiesRemaining();
        if (Player.PlayerIsAlive)
        {
            waveManager.CheckIfWaveEnded();
        }   
        Destroy(gameObject);
    }
}
