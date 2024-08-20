using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] private AudioClip song;

    AudioSource audio;

    void Start()
    {
        audio = AudioManager.instance.Play2dLoop(song, "Music", 1, 1, 1);
        
    }
    private void OnDestroy()
    {
        AudioManager.instance.StopLoopSound(audio);
    }

    void Update()
    {
        
    }
}
