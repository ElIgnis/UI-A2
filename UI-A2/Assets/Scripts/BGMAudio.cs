using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BGMAudio : MonoBehaviour {

    public AudioClip[] SoundToPlay;
    public static AudioSource audio;
    //public static BGMAudio Instance;
    public static bool changeAudio;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        //if (Application.loadedLevelName != "Game")
        //{
        //    if(Instance)
        //    {
        //        DestroyImmediate(this);
        //    }
        //    else
        //    {

        //        Instance = this;               
        //    }          
        //}
        audio = GetComponent<AudioSource>();
        audio.loop = true;
        changeAudio = false;

        if (Application.loadedLevelName == "Splash")
        {
            audio.clip = SoundToPlay[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {          
            audio.Play();
        }

        if (changeAudio)
        {
            audio.Stop();
            audio.clip = SoundToPlay[1];
            audio.Play();
            changeAudio = false;
        }
        audio.volume = PlayerPrefs.GetFloat("BGMVolume") / 10.0f;
    }

    public void PlaySound()
    {
        
    }
}
