using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public int flyHealth = 3;
    public bool partOfSwarm = false;
    private SpriteRenderer myRenderer;
    private LevelOneAchievements myAchievements;

    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelOneAchievements>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //If health hits 0, kill the fly
        if (flyHealth == 0)
        {
            if (partOfSwarm == true)
                myAchievements.ReduceEnemies();
            Destroy(gameObject);
        }

        //Randomly move the fly around
        int randyDir = Random.Range(1, 5);
        Vector2 newPos = transform.position;
        switch (randyDir)
        {
            case (1):
                newPos.x += 0.01f;
                transform.position = newPos;
                break;
            case (2):
                newPos.x-= 0.01f;
                transform.position = newPos;
                break;
            case (3):
                newPos.y+= 0.01f;
                transform.position = newPos;
                break;
            case (4):
                newPos.y-= 0.01f;
                transform.position = newPos;
                break;
        }

    }

    public void TakeHit()
    {
        flyHealth--;
        StartCoroutine(FlyColor());
    }

    IEnumerator FlyColor()
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        myRenderer.color = Color.white;
    }
}
