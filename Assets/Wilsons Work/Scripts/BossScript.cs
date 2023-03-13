using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float hp = 100;
    public bool sideCollision;
    public Animator animator;
    public Transform[] Brokenbullstatue;
    public float speed;
    public GameObject projectile;
    GameObject player;
    public Transform[] holes;
    Vector3 playerPos;
    public bool vulnerable;

    public GameObject Cracked;
    public Sprite[] sprites;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Tail");
        animator = GetComponent<Animator>();
        StartCoroutine ("PossessedBullStatue");
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0 && !dead)
        {
            dead = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
            StopCoroutine("boss");
           // Instantiate(Cracked, transform.position, Quaternion.identity);

            Invoke("DelayedDestroy", 2);
            //Just like in your patrolling enemy


        }
        if(sideCollision)
        {
            animator.SetTrigger("IsHurt");
            sideCollision = false;
        }
    }

    IEnumerator PossessedBullStatue()
    {
        while (true)
        {
            //FIRST ATTACK
            /*
            while (transform.position.x != Brokenbullstatue[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Brokenbullstatue[0].position.x, transform.position.y), speed);

                yield return null;
            }
            */

            //transform.localScale=new Vector2(-1, 1);

            yield return new WaitForSeconds(1f);

            int i = 0;
            while (i < 6)
            {
                GameObject Fireball = (GameObject)Instantiate(projectile, holes[Random.Range(0, 2)].position, Quaternion.identity);
                Fireball.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
                i++;
                yield return new WaitForSeconds(.7f);
            }

            //SECOND ATTACK
            GetComponent<Rigidbody2D>().isKinematic = true;
            while (transform.position != Brokenbullstatue[2].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, Brokenbullstatue[2].position, speed);
                yield return null;
            }

            playerPos = player.transform.position;

            yield return new WaitForSeconds(1f);
            GetComponent<Rigidbody2D>().isKinematic = false;

            while (transform.position.x != playerPos.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed);

                yield return null;
            }

            this.tag = "Untagged";
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            vulnerable = true;
            yield return new WaitForSeconds(4);
            this.tag = "deadly";
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            vulnerable = false;

            //THIRD ATTACK
            Transform temp;
            if (transform.position.x > player.transform.position.x)
            {
                temp = Brokenbullstatue[1];
            }
            else
            {
                temp = Brokenbullstatue[0];
            }
            while (transform.position.x != temp.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), speed);

                yield return null;
            }


        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Tail" /*&& vulnerable*/)
        {
            hp -= 30;
            vulnerable = false;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tail" /*&& vulnerable*/)
        {
            hp -= 30;
            vulnerable = false;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    void DelayedDestroy()
    {
        Destroy(gameObject);
    }
    public void Hurt()
    {
        speed = 0.0f;

        animator.SetBool("IsHurt", true);

        Invoke("DelayedDestroy", 1);
    }
}
