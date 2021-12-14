using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EctsItem : MonoBehaviour
{
    public float speed = 5;
    public int points = 1;
    public AudioClip collisionClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if(collision.gameObject.name == "Player")
        {
            if (player != null && collision != null)
            {
                player.PlaySound(collisionClip);
            }
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
