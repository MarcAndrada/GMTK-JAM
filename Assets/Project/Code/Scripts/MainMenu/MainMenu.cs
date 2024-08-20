using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallGuysSong;
    public LevelLoader levelLoader;
    public void GoToGame()
    {
        AudioManager.instance.Play2dLoop(fallGuysSong, "Music", 1, 1, 1);
        levelLoader.LoadSpecificLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
