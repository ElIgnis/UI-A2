using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VIPButtonHandler : MonoBehaviour {

    //Main Buttons
    public Button VIPButton;
    public Button AvatarButton;
    public Button PowerUpButton;
    public Button BackButton;
    public Button GemButton;

    //Non Pop up buttons
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                BackButton_Active;

    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;

	// Use this for initialization
	void Start () {

        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        BackButton_Active = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Main Wheel Selected
    public void GemButtonSelected()
    {
        if (GemButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToGemShop();
        }
    }
    public void AvatarButtonSelected()
    {
        if (AvatarButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToAvatarShop();
        }
    }
    public void PowerUpButtonSelected()
    {
        if (PowerUpButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToPowerUpShop();
        }
    }
    public void BackButtonSelected()
    {
        if (BackButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToMenu();
        }
    }
}
