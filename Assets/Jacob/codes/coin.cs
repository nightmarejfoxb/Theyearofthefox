using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private GameManager gameManager;
    public static int totalCoins = 0;
    public int pointValue;

    private void Start()
    {
        gameManager = GameObject.Find("maincode").GetComponent<GameManager>();
    }

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            
            totalCoins++;
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
