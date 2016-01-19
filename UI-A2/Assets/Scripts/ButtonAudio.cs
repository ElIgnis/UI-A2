using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ButtonAudio : MonoBehaviour
{
    public AudioClip SoundToPlay;
    AudioSource audio;
    public bool PlayIntro;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(PlayIntro)
        {
            audio.PlayOneShot(SoundToPlay, PlayerPrefs.GetFloat("SFXVolume") / 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(SoundToPlay, PlayerPrefs.GetFloat("SFXVolume") / 10.0f);
        }
    }
}
