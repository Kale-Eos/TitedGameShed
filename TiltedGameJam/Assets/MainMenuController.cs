﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    AudioManager audioManager;
    public Animator BlurFade;
    public Animator CircleFade;
    public GameObject optionsmenu;

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }
    }

    // UI Sound Control ////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]                                        // instantiates field
    string hoverOverSound = "ButtonHover";                  // instantiates Hover Over Sound
    [SerializeField]
    string pressButtonSound = "ButtonPress";                // instantiates Press Button Sound
    [SerializeField]
    string music = "Music";                                 // instantiates title bgm
    [SerializeField]
    string level1_bgm = "Level1_BGM";                       // instantiates Level 1 BGM
    [SerializeField]
    string level2_bgm = "Level2_BGM";                       // instantiates Level 2 BGM
    [SerializeField]
    string level3_bgm = "Level3_BGM";                       // instantiates Level 3 BGM
    [SerializeField]
    string freeRoam = "FreeRoam";                           // instantiates Free Roam BGM
    [SerializeField]
    string credits_bgm = "Credits_BGM";                     // instantiates Credits BGM
    [SerializeField]
    string gameOver_bgm = "GameOver_BGM";                   // instantiates Game Over BGM

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);             // makes a sound when hovering
    }

    public void OnMouseDown()
    {
        audioManager.PlaySound(pressButtonSound);           // makes a sound when pressed
    }

    public void PlayMusic()
    {
        audioManager.PlaySound(music);                      // Plays title bgm
    }

    public void StopMusic()
    {
        audioManager.StopSound(music);                      // Stops title bgm
    }

    public void PlayLevel1_BGM()
    {
        audioManager.PlaySound(level1_bgm);                 // Plays Level 1 bgm
    }

    public void StopLevel1_BGM()
    {
        audioManager.StopSound(level1_bgm);                 // Stops Level 1 bgm
    }

    public void PlayLevel2_BGM()
    {
        audioManager.PlaySound(level2_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel2_BGM()
    {
        audioManager.StopSound(level2_bgm);                 // Stops Level 2 bgm
    }

    public void PlayLevel3_BGM()
    {
        audioManager.PlaySound(level3_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel3_BGM()
    {
        audioManager.StopSound(level3_bgm);                 // Stops Level 2 bgm
    }

    public void PlayFreeRoam_BGM()
    {
        audioManager.PlaySound(freeRoam);                   // Plays Free Roam bgm
    }

    public void StopFreeRoam_BGM()
    {
        audioManager.StopSound(freeRoam);                   // Stop Free Roam bgm
    }

    public void PlayCredits_BGM()
    {
        audioManager.PlaySound(credits_bgm);                // Plays Credits bgm
    }

    public void StopCredits_BGM()
    {
        audioManager.StopSound(credits_bgm);                // Stops Credits bgm
    }

    public void PlayGameOver_BGM()
    {
        audioManager.PlaySound(gameOver_bgm);                // Plays Game Over bgm
    }

    public void StopGameOver_BGM()
    {
        audioManager.StopSound(gameOver_bgm);                // Stops Game Over bgm
    }

    // Level BGM Control ///////////////////////////////////////////////////////////////////////////////////

    public void BackToMainMenu()
    {
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
        audioManager.PlaySound("Music");            // Restarts main menu music
    }

    public void CreditsToMainMenu()
    {
        BlurFade.SetTrigger("SetBlur");
        Invoke("CreditsToMenu", 5);
    }

    void CreditsToMenu()
    {
        SceneManager.LoadScene("TitleScene");        // Reverses the the scene change to go back to Title Scene
        audioManager.StopSound("Credits_BGM");       // Stop playing Credits_BGM
        audioManager.PlaySound("Music");             // Restarts main menu music
    }

    void GameOverRetry()
    {
        SceneManager.LoadScene("Level1");           // Reverses the the scene change to go back to Level1
        audioManager.StopSound("GameOver_BGM");     // Stop playing GameOver_BGM
        audioManager.PlaySound("Level1_BGM");       // Restarts main menu music
    }

    public void GameOverToMainMenu()
    {
        BlurFade.SetTrigger("SetBlur");
        Invoke("GameOverToMenu", 5);
    }

    void GameOverToMenu()
    {
        SceneManager.LoadScene("TitleScene");        // Reverses the the scene change to go back to Title Scene
        audioManager.StopSound("GameOver_BGM");      // Stop playing GameOver_BGM
        audioManager.PlaySound("Music");             // Restarts main menu music
    }

    public void QuitGame()
    {
        audioManager.PlaySound(pressButtonSound);
        Debug.Log("Quitting Game");     // types out ~Quitting Game~
        Application.Quit();             // and quits game
    }

    //Matt's added functions

    public void StartGame()
    {
        audioManager.PlaySound(pressButtonSound);
        AudioManager.instance.StopSound("GameOver");
        AudioManager.instance.PlaySound("Music");
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        audioManager.PlaySound(pressButtonSound);
        optionsmenu.SetActive(true);
    }

    public void CloseOptions()
    {
        audioManager.PlaySound(pressButtonSound);
        optionsmenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        audioManager.PlaySound(pressButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
