using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHat : MonoBehaviour
{
    public int myHatIndex;

    private LevelThreeAchievements myAchievements;
    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelThreeAchievements>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAchievements.UnlockHat(myHatIndex);
        Destroy(gameObject);
    }
}
