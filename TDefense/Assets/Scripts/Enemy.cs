using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    HealthComponent enemyHealth;

    public void InitEnemy()
    {
        enemyHealth = GetComponent<HealthComponent>();
        enemyHealth.MaxHealthPoints = 3;
        enemyHealth.InitHealthComponent();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitEnemy();
        enemyHealth.LogHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameObject bullet = collision.gameObject;
            bullet.TryGetComponent(out DamageComponent damageComponent);
            Destroy(bullet);
            if (enemyHealth.TakeDamage(damageComponent.DamagePoints))
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
