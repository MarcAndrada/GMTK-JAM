using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallGuysSong;
    public LevelLoader levelLoader;
    AudioSource audioSource;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoToGame()
    {

        AudioManager.instance.StopLoopSound(audioSource);
        audioSource = AudioManager.instance.Play2dLoop(fallGuysSong, "Music", 1, 1, 1);
        levelLoader.LoadSpecificLevel(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
