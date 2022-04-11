using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHat : MonoBehaviour
{
    public int myHatIndex;
    public SoundManager soundManScript;

    private LevelThreeAchievements myAchievements;
    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelThreeAchievements>();
        soundManScript = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManScript.PlaySound("hat");
            myAchievements.UnlockHat(myHatIndex);
            Destroy(gameObject);
        }
    }
}
