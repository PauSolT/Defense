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
        playerHealth.LogHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
