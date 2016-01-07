using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GemButtonHandler : MonoBehaviour
{
    //Main Buttons
    public Button VIPButton;
    public Button AvatarButton;
    public Button PowerUpButton;
    public Button BackButton;
    public Button GemButton;

    public Button Gem20OptionButton;
    public Button Gem40OptionButton;
    public Button Gem60OptionButton;
    public Button Gem100OptionButton;
    public Button Gem150OptionButton;
    public Button Gem200OptionButton;
    public Button Gem300OptionButton;
    public Button Gem400OptionButton;
    public Button Gem500OptionButton;

    public Image Gem20PopUp;
    public Image Gem40PopUp;
    public Image Gem60PopUp;
    public Image Gem100PopUp;
    public Image Gem150PopUp;
    public Image Gem200PopUp;
    public Image Gem300PopUp;
    public Image Gem400PopUp;
    public Image Gem500PopUp;

    public Button PopUpBackButton;
    public Button PopUpBuyButton;

    //Non Pop up buttons
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                BackButton_Active,
                Gem20OptionButton_Active,
                Gem40OptionButton_Active,
                Gem60OptionButton_Active,
                Gem100OptionButton_Active,
                Gem150OptionButton_Active,
                Gem200OptionButton_Active,
                Gem300OptionButton_Active,
                Gem400OptionButton_Active,
                Gem500OptionButton_Active;

    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;
    // Use this for initialization
    void Start()
    {
        //Gem20PopUp.gameObject.SetActive(false);
        //Gem40PopUp.gameObject.SetActive(false);
        //Gem60PopUp.gameObject.SetActive(false);
        //Gem100PopUp.gameObject.SetActive(false);
        //Gem150PopUp.gameObject.SetActive(false);
        //Gem200PopUp.gameObject.SetActive(false);
        //Gem300PopUp.gameObject.SetActive(false);
        //Gem400PopUp.gameObject.SetActive(false);
        //Gem500PopUp.gameObject.SetActive(false);

        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        BackButton_Active = true;

        Gem20OptionButton_Active = true;
        Gem40OptionButton_Active = true;
        Gem60OptionButton_Active = true;
        Gem100OptionButton_Active = true;
        Gem150OptionButton_Active = true;
        Gem200OptionButton_Active = true;
        Gem300OptionButton_Active = true;
        Gem400OptionButton_Active = true;
        Gem500OptionButton_Active = true;

        //PopUpBuyButton.gameObject.SetActive(false);
        //PopUpBackButton.gameObject.SetActive(false);

        PopUpBack_Active = false;
        PopUpBuy_Active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Main Wheel Selected
    public void VIPButtonSelected()
    {
        if (VIPButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToVIPShop();
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

    //Gem Options Selected
    void GemOptionSelected()
    {

    }

    //Pop Up Options Selected
    public void PopUpBackSelected()
    {

    }
    public void PopUpBuySelected()
    {

    }

    void SetNonPopUpButtonsActive(bool active)
    {
        VIPButton_Active = active;
        AvatarButton_Active = active;
        PowerUpButton_Active = active;
        GemButton_Active = active;
        BackButton_Active = active;

        Gem20OptionButton_Active = active;
        Gem40OptionButton_Active = active;
        Gem60OptionButton_Active = active;
        Gem100OptionButton_Active = active;
        Gem150OptionButton_Active = active;
        Gem200OptionButton_Active = active;
        Gem300OptionButton_Active = active;
        Gem400OptionButton_Active = active;
        Gem500OptionButton_Active = active;
    }
    void SetPopUpButtonsActive(bool active)
    {
        PopUpBuy_Active = active;
        PopUpBuyButton.gameObject.SetActive(active);

        PopUpBack_Active = active;
        PopUpBackButton.gameObject.SetActive(active);
    }
}
