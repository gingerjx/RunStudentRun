using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject paperPrefab;
    public GameObject bookPrefab;
    public GameObject drinkPrefab;
    public GameObject beerPrefab;
    public GameObject bedPrefab;

    public float spawnFreq;
    float spawnTimer;

    void Start()
    {
        spawnTimer = spawnFreq;
    }

    void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            GameObject[] prefabs = { paperPrefab, bookPrefab, drinkPrefab, beerPrefab, bedPrefab };
            int index = Random.Range(0, prefabs.Length);
            spawnGoodThing(prefabs[index]);
            spawnTimer = spawnFreq;
        }
    }

    void spawnGoodThing(GameObject prefab)
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 position = new Vector3(Random.Range(0, width), height, 0);
        Instantiate(prefab, position, transform.rotation);
    }
}
