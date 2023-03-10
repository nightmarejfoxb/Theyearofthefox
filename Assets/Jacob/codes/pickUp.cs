using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;

    public bool pickUpAllowed;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(pickUpAllowed && Input.GetKeyDown(KeyCode.E))
       {
            PickUp();
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("fox spirit"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }

}
