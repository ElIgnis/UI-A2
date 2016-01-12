using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ButtonAudio : MonoBehaviour
{
    public AudioClip SoundToPlay;
    AudioSource audio;
    private bool playSound;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playSound = true;
        }
        else
        {
            playSound = false;
        }

        //if(playSound)
        {
            if (!audio.isPlaying)
            {
                //audio.PlayOneShot(SoundToPlay, 10);
            }
        }
    }
}
