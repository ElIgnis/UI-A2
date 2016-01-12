﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvatarButtonHandler : MonoBehaviour
{
    //Currency
    public Text MoneyOutput;
    public Text GemOutput;

    private int MoneyValue;
    private int GemValue;
    //Main Buttons
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
                BackButton_Active,
                SaberOptionButton_Active,
                RinOptionButton_Active,
                ShikiOptionButton_Active;

    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;
    
    //Confirm Screen
    public Image PurchaseFeedback;
    private float FadeSpeed;
    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        if(PlayerPrefs.HasKey("MoneyValue"))
        {
            MoneyValue = PlayerPrefs.GetInt("MoneyValue");
        }
        else
        {
            PlayerPrefs.SetInt("MoneyValue", 1000000);
        }
        if (PlayerPrefs.HasKey("GemValue"))
        {
            GemValue = PlayerPrefs.GetInt("GemValue");
        }
        else
        {
            PlayerPrefs.SetInt("GemValue", 10000);
        }
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
        BackButton_Active = true;

        PopUpBuyButton.gameObject.SetActive(false);
        PopUpBackButton.gameObject.SetActive(false);

        PurchaseFeedback.gameObject.SetActive(false);
        defaultColor = PurchaseFeedback.gameObject.GetComponent<Image>().color;

        FadeSpeed = 1;

        PopUpBack_Active = false;
        PopUpBuy_Active = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(PurchaseFeedback.gameObject.activeSelf)
        {
            Color c = PurchaseFeedback.gameObject.GetComponent<Image>().color;
            c.a -= FadeSpeed * Time.deltaTime;
            PurchaseFeedback.gameObject.GetComponent<Image>().color = c;
            if(c.a < 0)
            {
                PurchaseFeedback.gameObject.SetActive(false);
            }
        }

        //Checking if modified
        if(MoneyValue.ToString() != MoneyOutput.text)
        {
            MoneyOutput.text = MoneyValue.ToString();
        }
        if (GemValue.ToString() != GemOutput.text)
        {
            GemOutput.text = GemValue.ToString();
        }
    }

    //Main Wheel Selected
    public void VIPButtonSelected()
    {
        if(VIPButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToVIPShop();
        }
    }
    public void GemButtonSelected()
    {
        if (GemButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToGemShop();
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

    //Avatar Options Selected
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

    //Pop Up Options Selected
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
        PurchaseFeedback.gameObject.SetActive(true);
        PurchaseFeedback.gameObject.GetComponent<Image>().color = defaultColor;
    }

    void SetNonPopUpButtonsActive(bool active)
    {
        VIPButton_Active = active;
        AvatarButton_Active = active;
        PowerUpButton_Active = active;
        GemButton_Active = active;
        BackButton_Active = active;

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
