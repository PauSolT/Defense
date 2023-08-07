using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField]
    float timerToDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timerToDestroy);
    }

}
