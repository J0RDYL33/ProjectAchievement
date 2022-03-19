using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneAchievements : MonoBehaviour
{

    public int artefactCounter;
    private int enemiesLeft = 5;

    public bool artefactAchieved = false;
    public bool idolFound = false;
    public bool enemiesDefeated = false;
    public bool levelFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void AchieveIdol()
    {
        idolFound = true;
    }

    public void AchieveEnd()
    {
        levelFinished = true;
    }
}
