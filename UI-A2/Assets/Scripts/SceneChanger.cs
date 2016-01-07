using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToMenu()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("MainMenu");
        }
    }

    //public void ChangeToLvlSelect()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("LevelSelect");
    //    }
    //}

    public void ChangeToCredits()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Application.LoadLevel("Credits");
        }
    }

    //public void ChangeToHS()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("Highscore");
    //    }
    //}

    //public void ChangeToInfo()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("InfoScreen");
    //    }
    //}

    //public void ChangeToShop()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("Shop");
    //    }
    //}

    //public void ChangeToFL()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("FriendList");
    //    }
    //}

    //public void ChangeToOption()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Application.LoadLevel("Option");
    //    }
    //}
}
