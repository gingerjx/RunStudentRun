using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rect p1Zone, p2Zone;
    private float movementSpeed = 100f;
    PlayerInputActions playerInputActions;
    Vector2 touchPosition;
    float moving;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void Start()
    {
        p1Zone = new Rect(0, 0, Screen.width * 0.5f, Screen.height);
        p2Zone = new Rect(Screen.width * 0.5f, 0, Screen.width * 0.5f, Screen.height);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        touchPosition = playerInputActions.Player.Move.ReadValue<Vector2>();
        moving = playerInputActions.Player.Touch.ReadValue<float>();
        if (moving > 0)
        {
            if (p1Zone.Contains(touchPosition) && transform.localPosition.x > -Screen.width * 0.5) // w lewo
            {
                transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
            }
            else if (p2Zone.Contains(touchPosition) && transform.localPosition.x < Screen.width * 0.5) // w prawo
            {
                transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
