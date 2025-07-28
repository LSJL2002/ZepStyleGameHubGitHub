using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject carPrefab;
    [Header("Setting")]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float carSpeed = 5f;
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars() //Spawn cars in a random interveral between 3f and 5f
    {
        while (true)
        {
            GameObject car = Instantiate(carPrefab, transform.position, transform.rotation);
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
