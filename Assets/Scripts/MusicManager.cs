using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSrc;
    private float audioVolume = 0.25f;
    public AudioClip menuMusic, level1Music, level2Music, level3Music, victoryMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }

    public void ChangeToMenu()
    {
        audioSrc.PlayOneShot(menuMusic);
    }

    public void ChangeToLevel1()
    {
        audioSrc.PlayOneShot(level1Music);
    }
}
