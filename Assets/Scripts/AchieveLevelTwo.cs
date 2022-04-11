using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveLevelTwo : MonoBehaviour
{
    private LevelTwoAchievements myAchievements;
    private bool achieved = false;
    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelTwoAchievements>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && achieved == false)
        {
            achieved = true;
            myAchievements.AchieveComplete();
        }
    }
}
