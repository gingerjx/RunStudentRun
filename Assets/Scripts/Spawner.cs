using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goodPrefab;
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
            spawnGoodThing();
            spawnTimer = spawnFreq;
        }
    }

    void spawnGoodThing()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 position = new Vector3(Random.Range(0, width), height, 0);
        Instantiate(goodPrefab, position, transform.rotation);
    }
}
