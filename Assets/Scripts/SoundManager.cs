using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip scribble, coin, flyDeath, flyHit, flyHit2, footsteps1, footsteps2, footsteps3, footsteps4, footsteps5, footsteps6, grappleAttach, goldenGrapple, grappleReel, grappleShoot, vineHit, hat, hatConfirm, jumpEffort, menuClose, menuOpen, button, fanfare, sword, artefact;
    public AudioSource audioSrc;
    public AudioSource walkingSrc;
    private float audioVolume = 0.4f;
    private float walkingVolume = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        //audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
        walkingSrc.volume = audioVolume * walkingVolume;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "scribble":
                audioSrc.PlayOneShot(scribble);
                break;
            case "coin":
                audioSrc.PlayOneShot(coin);
                break;
            case "flyDeath":
                audioSrc.PlayOneShot(flyDeath);
                break;
            case "flyHit":
                audioSrc.PlayOneShot(flyHit);
                break;
            case "flyHit2":
                audioSrc.PlayOneShot(flyHit2);
                break;
            case "walking":
                int rand = Random.Range(0, 6);
                if (rand == 0)
                    walkingSrc.PlayOneShot(footsteps1);
                else if (rand == 1)
                    walkingSrc.PlayOneShot(footsteps2);
                else if (rand == 2)
                    walkingSrc.PlayOneShot(footsteps3);
                else if (rand == 3)
                    walkingSrc.PlayOneShot(footsteps4);
                else if (rand == 4)
                    walkingSrc.PlayOneShot(footsteps5);
                else
                    walkingSrc.PlayOneShot(footsteps6);
                break;
            case "grappleAttach":
                audioSrc.PlayOneShot(grappleAttach);
                break;
            case "goldenGrapple":
                audioSrc.PlayOneShot(goldenGrapple);
                break;
            case "grappleReel":
                audioSrc.PlayOneShot(grappleReel);
                break;
            case "grappleShoot":
                audioSrc.PlayOneShot(grappleShoot);
                break;
            case "vineHit":
                audioSrc.PlayOneShot(vineHit);
                break;
            case "hat":
                audioSrc.PlayOneShot(hat);
                break;
            case "hatConfirm":
                audioSrc.PlayOneShot(hatConfirm);
                break;
            case "jumpEffort":
                walkingSrc.PlayOneShot(jumpEffort);
                break;
            case "menuClose":
                audioSrc.PlayOneShot(menuClose);
                break;
            case "menuOpen":
                audioSrc.PlayOneShot(menuOpen);
                break;
            case "button":
                audioSrc.PlayOneShot(button);
                break;
            case "fanfare":
                audioSrc.PlayOneShot(fanfare);
                break;
            case "sword":
                audioSrc.PlayOneShot(sword);
                break;
            case "artefact":
                audioSrc.PlayOneShot(artefact);
                break;
        }
    }
}
