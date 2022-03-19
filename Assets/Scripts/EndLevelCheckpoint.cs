using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelCheckpoint : MonoBehaviour
{
    private LevelOneAchievements myAchievements;
    private bool achieved = false;

    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelOneAchievements>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && achieved == false)
        {
            achieved = true;
            myAchievements.AchieveEnd();
        }
    }
}
