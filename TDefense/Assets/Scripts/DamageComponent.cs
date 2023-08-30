using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField]
    int damagePoints = 1;

    public int DamagePoints { get => damagePoints; }
}
