using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public SoundManager soundManScript;
    private CoinController myCoins;
    // Start is called before the first frame update
    void Start()
    {
        soundManScript = FindObjectOfType<SoundManager>();
        myCoins = FindObjectOfType<CoinController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FrontCheck")
        {
            soundManScript.PlaySound("coin");
            myCoins.AddCoins();
            Destroy(gameObject);
        }
    }
}
