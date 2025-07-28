using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRDestroyZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Land"))
        {
            Destroy(other.gameObject);
        }
    }
}
