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
    List<KeyValuePair<GameObject, float>> prefabs; // prefab - spawn probability

    public float spawnFreq;
    public int freqAccelaration = 15; // Accelerate spawning after x seconds
    float spawnTimer;
    float freqAccelarationTimer = 0;

    void Start()
    {
        spawnTimer = spawnFreq;
        prefabs = new List<KeyValuePair<GameObject, float>>() {
            new KeyValuePair<GameObject, float>(bedPrefab, 0.025f), //2.5%
            new KeyValuePair<GameObject, float>(paperPrefab, 0.05f), //5%
            new KeyValuePair<GameObject, float>(partyPrefab, 0.075f), //7.5%
            new KeyValuePair<GameObject, float>(drinkPrefab, 0.1f), //10%
            new KeyValuePair<GameObject, float>(bookPrefab, 0.1f), //10%
            new KeyValuePair<GameObject, float>(beerPrefab, 0.10f), //10%
            new KeyValuePair<GameObject, float>(cloverPrefab, 0.15f), //15%
            new KeyValuePair<GameObject, float>(gamepadPrefab, 0.15f), //15%
            new KeyValuePair<GameObject, float>(null, 0.25f) //25%
        };
    }

    void Update()
    {   
        handleFrequencyCheck();
        handleItemSpawn();
    }

    void handleFrequencyCheck() {
        freqAccelarationTimer += Time.deltaTime;
        if (spawnFreq > SPAWN_FREG_LIMIT && freqAccelarationTimer > freqAccelaration) {
            freqAccelarationTimer = 0.0f;
            spawnFreq *= 0.9f;
        } 
    }

    void handleItemSpawn() {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnGoodThing(drawItem());
            spawnTimer = spawnFreq;
        }
    }

    GameObject drawItem() {
        float value = Random.Range(0.0f, 1.0f);
        float sum = 0.0f;
        foreach (var item in prefabs) {
            sum += item.Value;
            if (value < sum)
            {
                return item.Key;
            }
        }     
        return null;
    }

    void spawnGoodThing(GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }
            

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 position = new Vector3(Random.Range(0, width), height, 0);
        Instantiate(prefab, position, transform.rotation);
    }
}
