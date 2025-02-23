using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject helicopter;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private ParticleSystem explosionFX;

    private Vector2 movement;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        if (!LevelManager.instance.GameIsOver())
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if (movement.x < 0)
            {
                helicopter.transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate to face left
            }
            else if (movement.x > 0)
            {
                helicopter.transform.rotation = Quaternion.Euler(0, 0, 0); // Rotate to face right
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Tree")
        {
            // Explode the helicopter
            explosionFX.Play();
            helicopter.GetComponent<SpriteRenderer>().sortingOrder = -1;
            // Restart Level
            LevelManager.instance.GameOver();
        }

        if (collision.gameObject.tag == "Soldier")

            // +1 soldier if not at max capacity
            if (LevelManager.instance.getHeliCount() < 3)
            {
                audioManager.PlaySFX(audioManager.pickup);
                LevelManager.instance.addHeliCount();
                Destroy(collision.gameObject);
            }

        if (collision.gameObject.tag == "Tent" && LevelManager.instance.getHeliCount() != 0)
        {
            audioManager.PlaySFX(audioManager.rescue);
            LevelManager.instance.addRescuedScore(LevelManager.instance.getHeliCount());
            LevelManager.instance.resetHeliCount();
        }
    }
}
