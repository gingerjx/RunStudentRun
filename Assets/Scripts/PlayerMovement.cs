using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Touch theTouch;
    private Rect p1Zone, p2Zone;
    private BoxCollider2D collider;
    private float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        p1Zone = new Rect(0, 0, Screen.width * 0.5f, Screen.height);
        p2Zone = new Rect(Screen.width * 0.5f, Screen.width * 0.5f, Screen.width * 0.5f ,Screen.height);
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if(p1Zone.Contains(theTouch.position) && transform.localPosition.x > -Screen.width*0.5) // w lewo
            {
                transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
                Debug.Log(-Screen.width * 0.5 + " " + transform.localPosition.x);
            }
            else if(p2Zone.Contains(theTouch.position) && transform.localPosition.x < Screen.width*0.5) // w prawo
            {
                transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0,0);

                Debug.Log(Screen.width * 0.5 + " " + transform.localPosition.x);
            }
        }
    }

}
