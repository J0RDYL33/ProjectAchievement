using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D myRb;
    CharacterController2D myController;
    public float timeTilDeath;


    // Start is called before the first frame update
    void Start()
    {
        myController = FindObjectOfType<CharacterController2D>();
        myRb.velocity = (transform.right * speed * 1.5f) + transform.up * speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate it
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f), 1.0f);

        timeTilDeath -= Time.deltaTime;

        if (timeTilDeath <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "altplayer")
            return;

        if (other.tag != "grappleWall")
            Destroy(gameObject);

        if (other.tag == "grappleWall")
        {
            myController.GrappleToWall(gameObject.transform);
            Debug.Log(other.name);
            Debug.Log("Position: " + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", " + gameObject.transform.position.z);
            Destroy(gameObject);
        }
    }
}
