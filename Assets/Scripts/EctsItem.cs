using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EctsItem : MonoBehaviour
{
    public float speed = 5;
    public int points = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Player")
        {
            GameController.addEcts(points);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(transform.position.y > 0)
        {
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
            
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
