using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZigZagMovement());
    }

    IEnumerator ZigZagMovement()
    {
        HealthComponent health = GetComponent<HealthComponent>();
        if (transform.position.y == 0)
        {
            transform.position += Vector3.up;
        }

        while (health.CurrentHealthPoints > 0)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); ;
            yield return new WaitForSeconds(1.5f);
        }

        yield return null;
    }
}
