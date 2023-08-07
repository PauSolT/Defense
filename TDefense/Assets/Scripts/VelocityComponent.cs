using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    public float Velocity { get; set; } = 5.5f;
    void Update()
    {
        transform.position += Time.deltaTime * Velocity * Vector3.right;
    }
}
