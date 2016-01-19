using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    private float Delay;
    private bool TriggerChange, ChangeScreen;
    private string LoadScreen;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TriggerChange)
        {
            Delay += Time.deltaTime;
        }
        else
        {
            Delay = 0.0f;
        }
        if (Delay > 0.3f)
        {
            Application.LoadLevel(LoadScreen);
        }
    }

    void ChangeDelay()
    {

    }

    public void ChangeToMenu()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "MainMenu";
            BGMAudio.audio.Stop();
            BGMAudio.changeAudio = true;
        }
    }

    public void ChangeToLvlSelect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "StageSelect";
        }
    }

    public void ChangeToCredits()
    {
        if(Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Credits";
        }
    }

    public void ChangeToHS()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Highscore";
        }
    }

    public void ChangeToInfo()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Info";
        }
    }

    public void ChangeToAvatarShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Shop_Avatar";
        }
    }
    public void ChangeToGemShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Shop_Gem";
        }
    }
    public void ChangeToVIPShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Shop_VIP";
        }
    }
    public void ChangeToPowerUpShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Shop_PowerUp";
        }
    }

    public void ChangeToFL()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "FriendList";
        }
    }

    public void ChangeToOption()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Option";
        }
    }

    public void ChangeToGame()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            LoadScreen = "Game";
        }
    }
}
