using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button quitButton;
    public Button settingsBackButton;
    public Button creditsBackButton;
    public SoundManager soundManScript;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        soundManScript = FindObjectOfType<SoundManager>();
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);

        startButton.onClick.AddListener(StartOnClick);
        settingsButton.onClick.AddListener(SettingsOnClick);
        creditsButton.onClick.AddListener(CreditsOnClick);
        quitButton.onClick.AddListener(QuitOnClick);

        settingsBackButton.onClick.AddListener(SetBackOnClick);
        creditsBackButton.onClick.AddListener(SetBackOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartOnClick()
    {
        soundManScript.PlaySound("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void SettingsOnClick()
    {
        soundManScript.PlaySound("button");
    }

    void CreditsOnClick()
    {
        soundManScript.PlaySound("button");
    }

    void QuitOnClick()
    {
        soundManScript.PlaySound("button");
        Debug.Log("Quit button pressed");
        Application.Quit();
    }

    void SetBackOnClick()
    {
        soundManScript.PlaySound("button");
    }
}
