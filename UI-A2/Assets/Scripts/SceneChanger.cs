using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    private float Delay;
    private bool TriggerChange, ChangeScreen;

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
    }

    void ChangeDelay()
    {

    }

    public void ChangeToMenu()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;
            Application.LoadLevel("MainMenu");
        }
    }

    public void ChangeToLvlSelect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TriggerChange = true;          
        }
        if(Delay > 0.4f)
        {
            Application.LoadLevel("StageSelect");
        }
    }

    public void ChangeToCredits()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Credits");
        }
    }

    public void ChangeToHS()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Highscore");
        }
    }

    public void ChangeToInfo()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Info");
        }
    }

    public void ChangeToAvatarShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Shop_Avatar");
        }
    }
    public void ChangeToGemShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Shop_Gem");
        }
    }
    public void ChangeToVIPShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Shop_VIP");
        }
    }
    public void ChangeToPowerUpShop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Shop_PowerUp");
        }
    }

    public void ChangeToFL()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("FriendList");
        }
    }

    public void ChangeToOption()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Option");
        }
    }
}
