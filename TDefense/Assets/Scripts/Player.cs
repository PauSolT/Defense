using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIGame uiGame;
    HealthComponent playerHealth;

    public void InitPlayer()
    {
        playerHealth = GetComponent<HealthComponent>();
        playerHealth.InitHealthComponent();
    }


    // Start is called before the first frame update
    void Start()
    {
        InitPlayer();   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.TryGetComponent(out DamageComponent damageComponent);
            Destroy(enemy);
            if (playerHealth.TakeDamage(damageComponent.DamagePoints))
            {
                Die();
            }
        }
    }

    void Die()
    {
        uiGame.WaveLost();
    }
}
