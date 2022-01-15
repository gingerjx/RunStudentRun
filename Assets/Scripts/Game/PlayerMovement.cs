using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rect p1Zone, p2Zone;
    private const float MOVEMENT_SPEED_NORMAL = 100f;
    private const float MOVEMENT_SPEED_BOOST = 300f;
    private const float ANIMATOR_SPEED_NORMAL = 1;
    private const float ANIMATOR_SPEED_BOOST = 5; 
    PlayerInputActions playerInputActions;
    Vector2 touchPosition;
    float moving;
    private AudioSource audioSource;
    private AudioSource music;
    private Animator animator;

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
        animator = GetComponent<Animator>();
        music = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    void Update()
    {
        var deadlineBoostActive = EquipmentHandler.IsDeadlineBoostActive();
        touchPosition = playerInputActions.Player.Move.ReadValue<Vector2>();
        moving = playerInputActions.Player.Touch.ReadValue<float>();

        if (moving > 0)
        {
            var movementSpeed = !deadlineBoostActive ? MOVEMENT_SPEED_NORMAL : MOVEMENT_SPEED_BOOST;
            animator.speed = !deadlineBoostActive ? ANIMATOR_SPEED_NORMAL : ANIMATOR_SPEED_BOOST;

            if (p1Zone.Contains(touchPosition) && transform.localPosition.x > -Screen.width * 0.5) // w lewo
            {
                animator.SetFloat("Move X", -1);
                transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
            }
            else if (p2Zone.Contains(touchPosition) && transform.localPosition.x < Screen.width * 0.5) // w prawo
            {
                animator.SetFloat("Move X", 1);
                transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
            }
        } else {
            animator.speed = 0;
        }

        // mutowanie muzyki globalnie
        if (GameController.musicMuted == false)  music.volume = 1;
        else music.volume = 0;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}