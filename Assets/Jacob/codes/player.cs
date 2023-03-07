using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float horizontalInput;
    public float moveSpeed;

    public float jumpForce;
    public KeyCode jumpButton = KeyCode.Space;
    private Rigidbody2D rb;
    public bool isOnGround = true;

    private SpriteRenderer sr;

    public Animator ai;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ai = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * horizontalInput);
        ai.SetFloat("move", 0);

        //flip the sprite if facing left
        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
        }



        if (Input.GetKeyDown(jumpButton) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Force Added");
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }
}
