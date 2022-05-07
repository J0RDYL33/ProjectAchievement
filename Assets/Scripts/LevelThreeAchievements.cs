using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelThreeAchievements : MonoBehaviour
{
    public GameObject scrapbook;
    public Sprite[] listOfHats;
    public SpriteRenderer hatContainer;
    public Image[] buttonImages;
    public SoundManager soundManScript;
    public MusicManager musicManScript;

    private Sprite tempSprite;
    private bool scrapbookShown = false;
    private bool[] unlocked = new bool[10];
    // Start is called before the first frame update
    void Start()
    {
        scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
        unlocked[0] = true;
        soundManScript = FindObjectOfType<SoundManager>();
        musicManScript = FindObjectOfType<MusicManager>();
        musicManScript.ChangeToLevel3();
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

    public void SwitchToHat(int hatToSwitch)
    {
        if(unlocked[hatToSwitch] == true)
        {
            soundManScript.PlaySound("hatConfirm");
            hatContainer.sprite = listOfHats[hatToSwitch];
        }
    }

    public void UnlockHat(int hatToUnlock)
    {
        unlocked[hatToUnlock] = true;
        buttonImages[hatToUnlock].color = Color.white;
        soundManScript.PlaySound("hat");
    }
}
