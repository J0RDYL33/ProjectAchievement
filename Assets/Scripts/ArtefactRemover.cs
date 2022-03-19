using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactRemover : MonoBehaviour
{
    private LevelOneAchievements myAchievements;

    private void Start()
    {
        myAchievements = FindObjectOfType<LevelOneAchievements>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            myAchievements.AddToArtefacts();
            Destroy(gameObject);
        }
    }
}
