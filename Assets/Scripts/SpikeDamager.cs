using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamager : MonoBehaviour
{
    private CharacterController2D myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myPlayer.TakeDamage();
        }
    }
}
