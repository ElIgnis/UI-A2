using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BGMAudio : MonoBehaviour {

    public AudioClip SoundToPlay;
    AudioSource audio;
    public static BGMAudio Instance;

    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevelName != "Game")
        {
            if(Instance)
            {
                DestroyImmediate(this);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }          
        }
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(SoundToPlay, PlayerPrefs.GetFloat("BGMVolume") / 10.0f);
        }
        audio.volume = PlayerPrefs.GetFloat("BGMVolume") / 10.0f;
    }

    public void PlaySound()
    {
        
    }
}
