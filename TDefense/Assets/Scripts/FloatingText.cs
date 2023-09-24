using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Vector3 position;
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += position;
    }

}
