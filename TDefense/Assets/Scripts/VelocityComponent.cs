using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    public float Velocity { get; set; } = 10f;
    void Update()
    {
        transform.position += Time.deltaTime * Velocity * gameObject.transform.up;
    }
}
