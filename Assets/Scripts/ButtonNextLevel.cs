using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
    MusicManager myMusic;
    SoundManager mySound;
    // Start is called before the first frame update
    void Start()
    {
        myMusic = FindObjectOfType<MusicManager>();
        mySound = FindObjectOfType<SoundManager>();
        myMusic.ChangeToEndLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnOnClick()
    {
        Destroy(myMusic.gameObject);
        Destroy(mySound.gameObject);
        SceneManager.LoadScene(0);
    }
}
