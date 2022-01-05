using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float SPAWN_FREG_LIMIT = 0.7f;

    public GameObject paperPrefab;
    public GameObject bookPrefab;
    public GameObject drinkPrefab;
    public GameObject beerPrefab;
    public GameObject bedPrefab;
    public GameObject cloverPrefab;
    public GameObject gamepadPrefab;
    public GameObject partyPrefab;

    public float spawnFreq;
    public int freqAccelaration = 15; // Accelerate spawning after x seconds
    float spawnTimer;
    float freqAccelarationTimer = 0;

    void Start()
    {
        spawnTimer = spawnFreq;
    }

    void Update()
    {   
        handleFrequencyCheck();

        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            GameObject[] prefabs = { paperPrefab, bookPrefab, drinkPrefab, beerPrefab, bedPrefab, cloverPrefab, gamepadPrefab, partyPrefab };
            int index = Random.Range(0, prefabs.Length);
            spawnGoodThing(prefabs[index]);
            spawnTimer = spawnFreq;
        }
    }

    void handleFrequencyCheck() {
        freqAccelarationTimer += Time.deltaTime;
        if (spawnFreq > SPAWN_FREG_LIMIT && freqAccelarationTimer > freqAccelaration) {
            freqAccelarationTimer = 0.0f;
            spawnFreq *= 0.9f;
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
