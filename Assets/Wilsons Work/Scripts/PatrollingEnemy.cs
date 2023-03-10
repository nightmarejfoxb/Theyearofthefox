using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public bool sideCollision = false;
    public Animator animator;

    public Transform groundDetector;
    public float speed;

    public AudioClip deathSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        groundDetector = gameObject.transform.Find("GroundDetector").transform;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Tail"))
        {
           
            if (!sideCollision)
            {
                //collision.gameObject.GetComponent<PlayerController>().Hurt();
            }
            else
            {
                
            }
            
        }

        */
    }

    void DelayedDestroy()
    {
        Destroy(gameObject);
    }

    public void Hurt()
    {
        speed = 0.0f;

        animator.SetBool("IsHurt", true);
        audioSource.PlayOneShot(deathSound);

        Invoke("DelayedDestroy", 1);
        
    }

}
