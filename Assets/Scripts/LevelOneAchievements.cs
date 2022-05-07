using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneAchievements : MonoBehaviour
{

    public int artefactCounter;
    private int enemiesLeft = 5;
    private bool scrapbookShown = false;
    public SoundManager soundManScript;
    public MusicManager musicManScript;

    public bool artefactAchieved = false;
    public bool idolFound = false;
    public bool enemiesDefeated = false;
    public bool levelFinished = false;

    public GameObject scrapbook;
    public GameObject iconArtefact;
    public GameObject iconIdol;
    public GameObject iconCompleted;
    public GameObject iconFly;

    // Start is called before the first frame update
    void Start()
    {
        scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
        soundManScript = FindObjectOfType<SoundManager>();
        musicManScript = FindObjectOfType<MusicManager>();
        musicManScript.ChangeToLevel1();
        iconArtefact.SetActive(false);
        iconIdol.SetActive(false);
        iconFly.SetActive(false);
        iconCompleted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (scrapbookShown == false)
            {
                scrapbook.transform.localPosition = new Vector3(0, 0, 10);
                scrapbookShown = true;
                soundManScript.PlaySound("menuOpen");
            }
            else
            {
                scrapbook.transform.localPosition = new Vector3(0, 1000, 10);
                scrapbookShown = false;
                soundManScript.PlaySound("menuClose");
            }
        }
    }

    public void ReduceEnemies()
    {
        enemiesLeft--;
        if (enemiesLeft == 0)
            AchieveEnemies();
    }

    private void AchieveEnemies()
    {
        enemiesDefeated = true;
        iconFly.SetActive(true);
        soundManScript.PlaySound("scribble");
    }

    public void AddToArtefacts()
    {
        artefactCounter++;
        if (artefactCounter == 4)
            AchieveArtefacts();
    }

    private void AchieveArtefacts()
    {
        artefactAchieved = true;
        iconArtefact.SetActive(true);
        soundManScript.PlaySound("scribble");
    }

    public void AchieveIdol()
    {
        idolFound = true;
        iconIdol.SetActive(true);
        soundManScript.PlaySound("scribble");
    }

    public void AchieveEnd()
    {
        levelFinished = true;
        iconCompleted.SetActive(true);
        soundManScript.PlaySound("scribble");
    }
}
