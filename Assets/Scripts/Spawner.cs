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
        Vector3 position = new Vector3(Random.Range(0, Screen.width), Screen.height, 0);
        Instantiate(goodPrefab, position, transform.rotation);
    }
}
