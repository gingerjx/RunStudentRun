using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumItem : MonoBehaviour
{
    public float speed = 5;
    public AudioClip collisionClip;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (collision.gameObject.name == "Player")
        {
            // Gdy nastąpi kolizja oraz dźwięk nie jest zmutowany
            if (player != null && collision != null && !GameController.soundMuted)
            {
                player.PlaySound(collisionClip);
            }

            int currentKP = PlayerPrefs.HasKey("KnowledgePoints") ? PlayerPrefs.GetInt("KnowledgePoints") : 0;
            PlayerPrefs.SetInt("KnowledgePoints", currentKP + 1);
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
