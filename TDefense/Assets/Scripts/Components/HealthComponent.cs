using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    int maxHealthPoints = 5;
    [SerializeField]
    int currentHealthPoints;
    public int MaxHealthPoints { get => maxHealthPoints; set => maxHealthPoints = value; }
    public int CurrentHealthPoints { get => currentHealthPoints; set => currentHealthPoints = value; }

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
