using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BGMAudio : MonoBehaviour {

    public AudioClip[] SoundToPlay;
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
                audio = GetComponent<AudioSource>();
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            if(Application.loadedLevelName == "Splash")
            {
                audio.PlayOneShot(SoundToPlay[0], PlayerPrefs.GetFloat("BGMVolume") / 10.0f);
            }
            else
            {
                audio.PlayOneShot(SoundToPlay[1], PlayerPrefs.GetFloat("BGMVolume") / 10.0f);
            }
            
            //SoundToPlay
        }
        audio.volume = PlayerPrefs.GetFloat("BGMVolume") / 10.0f;
    }

    public void PlaySound()
    {
        
    }
}
