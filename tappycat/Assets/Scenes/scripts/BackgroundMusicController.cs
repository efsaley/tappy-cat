using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController: MonoBehaviour
{
    private static BackgroundMusicController instance;
    private AudioSource audioSource;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
