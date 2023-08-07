using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealthPoints { get; set; } = 125;
    public int CurrentHealthPoints { get; set; }

    public void InitHealthComponent()
    {
        CurrentHealthPoints = MaxHealthPoints;
    }

    public bool TakeDamage(int damagePoints)
    {
        bool isDead = false;
        CurrentHealthPoints -= damagePoints;

        if (CurrentHealthPoints <= 0)
        {
            isDead = true;
        }

        return isDead;
    }

    public void LogHealth()
    {
        Debug.Log(name + " health: " + CurrentHealthPoints + "/" + MaxHealthPoints);
    }
}
