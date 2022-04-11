using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactRemover : MonoBehaviour
{
    public SoundManager soundManScript;
    private LevelOneAchievements myAchievements;

    private void Start()
    {
        myAchievements = FindObjectOfType<LevelOneAchievements>();
        soundManScript = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soundManScript.PlaySound("artefact");
            myAchievements.AddToArtefacts();
            Destroy(gameObject);
        }
    }
}
