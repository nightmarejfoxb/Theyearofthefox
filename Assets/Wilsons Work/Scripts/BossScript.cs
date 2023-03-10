using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public bool sideCollision;
    public Animator animator;
    public Transform[] Brokenbullstatue;
    public float speed;
    public GameObject projectile;
    public Transform[] holes;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine ("PossessedBullStatue");
    }

    // Update is called once per frame
    void Update()
    {
        if(sideCollision)
        {
            animator.SetTrigger("IsHurt");
            sideCollision = false;
        }
    }

    IEnumerator PossessedBullStatue()
    {
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
        while (i<6)
        {
           GameObject Fireball= (GameObject)Instantiate(projectile,holes[Random.Range(0,2)].position, Quaternion.identity);
            Fireball.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
            i++;
            yield return new WaitForSeconds(.7f);
        }
    }
}
