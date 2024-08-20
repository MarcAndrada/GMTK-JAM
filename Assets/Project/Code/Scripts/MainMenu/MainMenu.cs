using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip fallGuysSong;

    public void GoToGame()
    {
        AudioManager.instance.Play2dLoop(fallGuysSong, "Music", 1, 1, 1);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
