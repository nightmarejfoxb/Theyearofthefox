using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    private bool sideCollision = false;

    public Transform groundDetector;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        groundDetector = gameObject.transform.Find("GroundDetector").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        RaycastHit2D groundRay =  Physics2D.Raycast(groundDetector.position, Vector2.down, 1f);

        if(groundRay.collider == null)
        {
            transform.Rotate(0f,180f,0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tail"))
        {
            /*
             * 
             * Update when jacob completes the player controller
            if (!sideCollision)
            {
                collision.gameObject.GetComponent<PlayerController>().Hurt();
            }
            */
        }
    }
}
