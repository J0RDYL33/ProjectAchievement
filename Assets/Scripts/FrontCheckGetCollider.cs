using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheckGetCollider : MonoBehaviour
{
    public bool isFrontClimbable = false;
    private Grappler myGrappler;
    private LevelTwoAchievements myAchievements;

    private void Start()
    {
        myAchievements = FindObjectOfType<LevelTwoAchievements>();
        myGrappler = FindObjectOfType<Grappler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "grappleWall")
        {
            isFrontClimbable = true;
        }
        if (collision.tag == "goldengrapple")
        {
            Destroy(collision.gameObject);
            myGrappler.goldenGrapple = true;
            myAchievements.AchieveGrapple();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFrontClimbable = false;
    }
}
