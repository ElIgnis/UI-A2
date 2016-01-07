using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button VIPButton;
    public Button AvatarButton;
    public Button PowerUpButton;
    public Button BackButton;
    public Button GemButton;

    public Button SaberOptionButton;
    public Button RinOptionButton;
    public Button ShikiOptionButton;

    public Image SaberPopUp;
    public Image RinPopUp;
    public Image ShikiPopUp;

    public Button PopUpBackButton;
    public Button PopUpBuyButton;

    //Non Pop up buttons
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                SaberOptionButton_Active,
                RinOptionButton_Active,
                ShikiOptionButton_Active;
    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;
    // Use this for initialization
    void Start()
    {
        SaberPopUp.gameObject.SetActive(false);
        RinPopUp.gameObject.SetActive(false);
        ShikiPopUp.gameObject.SetActive(false);

        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        SaberOptionButton_Active = true;
        RinOptionButton_Active = true;
        ShikiOptionButton_Active = true;

        PopUpBuyButton.gameObject.SetActive(false);
        PopUpBackButton.gameObject.SetActive(false);

        PopUpBack_Active = false;
        PopUpBuy_Active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaberOptionSelected()
    {
        if (SaberOptionButton_Active)
        {
            SaberPopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void RinOptionSelected()
    {
        if (RinOptionButton_Active)
        {
            RinPopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void ShikiOptionSelected()
    {
        if (ShikiOptionButton_Active)
        {
            ShikiPopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }

    public void PopUpBackSelected()
    {
        if (ShikiPopUp.gameObject.activeSelf)
        {
            ShikiPopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (SaberPopUp.gameObject.activeSelf)
        {
            SaberPopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (RinPopUp.gameObject.activeSelf)
        {
            RinPopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
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
        SaberOptionButton_Active = active;
        RinOptionButton_Active = active;
        ShikiOptionButton_Active = active;
    }

    void SetPopUpButtonsActive(bool active)
    {
        PopUpBuy_Active = active;
        PopUpBuyButton.gameObject.SetActive(active);

        PopUpBack_Active = active;
        PopUpBackButton.gameObject.SetActive(active);
    }
}
