using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSection : MonoBehaviour
{
    public bool speedWon = false;

    private float playerSpeed;
    private float desiredTime = 30.0f;
    private bool inSection = false;
    private bool finished = false;
    private bool achieved = false;
    private LevelTwoAchievements myAchievements;
    
    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelTwoAchievements>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inSection == true)
        {
            playerSpeed += Time.deltaTime;
        }
    }

    public void StartRace()
    {
        finished = false;
        playerSpeed = 0.0f;
        inSection = true;
    }

    public void Finished()
    {
        inSection = false;
        finished = true;

        if (playerSpeed < desiredTime && achieved == false)
        {
            achieved = true;
            myAchievements.AchieveSpeed();
        }
    }
}
