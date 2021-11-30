using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodThing : MonoBehaviour
{
    public float speed = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Player")
        {
            GameController.addPoint();
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
