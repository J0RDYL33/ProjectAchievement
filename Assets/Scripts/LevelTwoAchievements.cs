using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoAchievements : MonoBehaviour
{
    public SpriteRenderer grappleAchievement;
    public SpriteRenderer speedAchievement;
    public SpriteRenderer coinAchievement;
    public SpriteRenderer completeAchievement;
    public Sprite newGrapple;
    public Sprite newSpeed;
    public Sprite newCoin;
    public Sprite newComplete;
    public GameObject scrapbook;

    private bool scrapbookShown = false;
    // Start is called before the first frame update
    void Start()
    {
        scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (scrapbookShown == false)
            {
                scrapbook.transform.localPosition = new Vector3(0, 0, 10);
                scrapbookShown = true;
            }
            else
            {
                scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
                scrapbookShown = false;
            }
        }
    }

    public void AchieveGrapple()
    {
        grappleAchievement.sprite = newGrapple;
    }

    public void AchieveCoins()
    {
        coinAchievement.sprite = newCoin;
    }

    public void AchieveSpeed()
    {
        speedAchievement.sprite = newSpeed;
    }

    public void AchieveComplete()
    {
        completeAchievement.sprite = newComplete;
    }
}
