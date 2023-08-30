using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.TryGetComponent(out DamageComponent damageComponent);
            playerHealth.TakeDamage(damageComponent.DamagePoints);
            Destroy(enemy);
        }
    }
}
