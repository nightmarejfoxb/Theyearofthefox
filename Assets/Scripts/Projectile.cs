using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayedDestroy", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    void DelayedDestroy()
    {
        Destroy(gameObject);
    }
}
