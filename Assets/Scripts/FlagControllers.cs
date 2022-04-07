using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagControllers : MonoBehaviour
{
    public bool isStartFlag;

    private SpeedSection mySection;
    // Start is called before the first frame update
    void Start()
    {
        mySection = FindObjectOfType<SpeedSection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isStartFlag == false)
        {
            mySection.Finished();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isStartFlag == true)
        {
            mySection.StartRace();
        }
    }
}
