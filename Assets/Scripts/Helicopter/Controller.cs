using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject helicopter;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    private void FixedUpdate()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collisions here
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.name == "Trees")
        {
            // Restart Level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}
