using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private int coinCount;
    public TextMeshProUGUI coinText;
    private LevelTwoAchievements myAchievements;
    // Start is called before the first frame update
    void Start()
    {
        myAchievements = FindObjectOfType<LevelTwoAchievements>();
        coinText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coinCount += 5;
        coinText.text = coinCount.ToString();

        if (coinCount >= 25)
        {
            myAchievements.AchieveCoins();
        }
    }    
}
