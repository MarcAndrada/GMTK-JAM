using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallGuysSong;
    public LevelLoader levelLoader;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoToGame()
    {
        levelLoader.LoadSpecificLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
