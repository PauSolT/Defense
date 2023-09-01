using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyInfo", order = 1)]
public class EnemyInfo : ScriptableObject
{
    public int healthBase;
    public int healthGrow;
    public int waveGrow;
    public int wavesToGrow;
    public int waveRequirement;
    public int money;
}
