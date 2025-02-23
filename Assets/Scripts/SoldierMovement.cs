using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
            {
                flip();
                currentPoint = pointA.transform;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
            {
                flip();
                currentPoint = pointB.transform;
            }
        }
    }


    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}