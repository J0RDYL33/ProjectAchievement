using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D myRb;
    CharacterController2D myController;


    // Start is called before the first frame update
    void Start()
    {
        myController = FindObjectOfType<CharacterController2D>();
        myRb.velocity = (transform.right * speed) + transform.up * speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "MainCharacter")
            return;

        //Send position to the player, add velocity to player in direction
        //Destroy bullet after 1 second of not hitting anything
        myController.GrappleToWall(gameObject.transform);
        Debug.Log(other.name);
        Debug.Log("Position: " + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", " + gameObject.transform.position.z);
        Destroy(gameObject);
    }
}
