using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;
    float offsetZ;

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
        offsetZ = transform.position.z - target.position.z;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        float targetZ = target.position.z + offsetZ;
        pos.z = Mathf.Max(transform.position.z, targetZ);
        transform.position = pos;
    }
}
