using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //Move in a cosnsitant rate forward
    }
}
