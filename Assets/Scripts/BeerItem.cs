using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerItem : MonoBehaviour
{
    public float speed = 5;
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameController.decreaseEnergy(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y > 0)
        {
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
