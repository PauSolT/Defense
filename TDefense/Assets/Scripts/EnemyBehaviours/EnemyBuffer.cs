using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffer : MonoBehaviour
{
    public DamageComponent bullet;
    int bulletDamage;
    HealthComponent healthComponent;

    private void Start()
    {
        bulletDamage = bullet.DamagePoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthComponent = collision.GetComponent<HealthComponent>();
            healthComponent.MaxHealthPoints += bulletDamage;
            healthComponent.CurrentHealthPoints += bulletDamage;

            if (healthComponent.CurrentHealthPoints > healthComponent.MaxHealthPoints)
                healthComponent.CurrentHealthPoints = healthComponent.MaxHealthPoints;

        }
    }
}
