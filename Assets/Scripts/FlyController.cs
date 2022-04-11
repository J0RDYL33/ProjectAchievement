using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public int flyHealth = 3;
    public bool partOfSwarm = false;
    public float flyThrust;
    public SoundManager soundManScript;

    private SpriteRenderer myRenderer;
    private LevelOneAchievements myAchievements;
    private Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelOneAchievements>();
        myRenderer = GetComponent<SpriteRenderer>();
        myRb = GetComponent<Rigidbody2D>();
        soundManScript = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If health hits 0, kill the fly
        if (flyHealth <= 0)
        {
            if (partOfSwarm == true)
                myAchievements.ReduceEnemies();
            soundManScript.PlaySound("flyDeath");
            Destroy(gameObject);
        }

        //Randomly move the fly around
        int randyDir = Random.Range(1, 5);
        Vector2 newPos = transform.position;
        switch (randyDir)
        {
            case (1):
                //newPos.x += 20.01f;
                myRb.AddForce(transform.up * flyThrust);
                //transform.position = newPos;
                break;
            case (2):
                //newPos.x-= 0.01f;
                myRb.AddForce(-(transform.up * flyThrust));
                //transform.position = newPos;
                break;
            case (3):
                //newPos.y+= 0.01f;
                myRb.AddForce(transform.right * flyThrust);
                //transform.position = newPos;
                break;
            case (4):
                //newPos.y-= 0.01f;
                myRb.AddForce(-(transform.right * flyThrust));
                //transform.position = newPos;
                break;
        }

    }

    public void TakeHit()
    {
        flyHealth--;

        int randInt = Random.Range(0, 2);
        if (randInt == 0)
            soundManScript.PlaySound("flyHit");
        else
            soundManScript.PlaySound("flyHit2");

        StartCoroutine(FlyColor());
    }

    IEnumerator FlyColor()
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        myRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "grapple")
        {
            TakeHit();
        }
    }
}
