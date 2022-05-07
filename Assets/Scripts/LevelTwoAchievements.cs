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
    public SoundManager soundManScript;
    public MusicManager musicManScript;

    private bool scrapbookShown = false;
    // Start is called before the first frame update
    void Start()
    {
        scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
        soundManScript = FindObjectOfType<SoundManager>();
        musicManScript = FindObjectOfType<MusicManager>();
        musicManScript.ChangeToLevel2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (scrapbookShown == false)
            {
                scrapbook.transform.localPosition = new Vector3(0, 0, 10);
                scrapbookShown = true;
                soundManScript.PlaySound("menuOpen");
            }
            else
            {
                scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
                scrapbookShown = false;
                soundManScript.PlaySound("menuClose");
            }
        }
    }

    public void AchieveGrapple()
    {
        grappleAchievement.sprite = newGrapple;
        soundManScript.PlaySound("goldenGrapple");
    }

    public void AchieveCoins()
    {
        coinAchievement.sprite = newCoin;
        soundManScript.PlaySound("fanfare");
    }

    public void AchieveSpeed()
    {
        speedAchievement.sprite = newSpeed;
        soundManScript.PlaySound("fanfare");
    }

    public void AchieveComplete()
    {
        completeAchievement.sprite = newComplete;
        soundManScript.PlaySound("fanfare");
    }
}
