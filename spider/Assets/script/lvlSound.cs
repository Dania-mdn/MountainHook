using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlSound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.Play();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(audioSource.volume < 0.265f)
        {
            audioSource.volume = audioSource.volume + 0.003f;
        }
    }
}
