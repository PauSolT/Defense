using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    public enum VelocityDirection
    {
        up,
        left,
        right,
        down
    }

    public float velocity = 10f;

    public VelocityDirection velocityDirection;
    Vector3 direction;

    private void Start()
    {
        switch (velocityDirection)
        {
            case VelocityDirection.up:
                direction = gameObject.transform.up;
                break;
            case VelocityDirection.left:
                direction = -gameObject.transform.right;
                break;
            case VelocityDirection.right:
                direction = gameObject.transform.right;
                break;
            case VelocityDirection.down:
                direction = -gameObject.transform.up;
                break;
            default:
                direction = gameObject.transform.up;
                break;
        }

    }


    void Update()
    {
        transform.position += Time.deltaTime * velocity * direction;
    }
}
