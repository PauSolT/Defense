using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DamageComponent>().DamagePoints = FindFirstObjectByType<Player>().gameObject.GetComponent<HealthComponent>().MaxHealthPoints;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

   
}
