using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class test : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.isPlaying);
    }
}
