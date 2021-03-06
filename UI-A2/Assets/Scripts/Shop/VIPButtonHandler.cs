﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VIPButtonHandler : MonoBehaviour
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

    //VIP Option Buttons
    public Button VIPOption_1;
    public Button VIPOption_2;
    public Button VIPOption_3;
    public Button VIPOption_4;

    //Pop Ups
    public Image VIP1_PopUp;
    public Image VIP2_PopUp;
    public Image VIP3_PopUp;
    public Image VIP4_PopUp;

    //PopUp Buttons
    public Button PopUpBackButton;
    public Button PopUpBuyButton;

    //Non Pop up buttons
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                BackButton_Active,
                VIP1_Active,
                VIP2_Active,
                VIP3_Active,
                VIP4_Active;

    //Confirm Screen
    public Image PurchaseFeedback;
    public Image ErrorFeedback;
    private float FadeSpeed;
    private Color defaultColor;

    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("MoneyValue"))
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
        VIP1_PopUp.gameObject.SetActive(false);
        VIP2_PopUp.gameObject.SetActive(false);
        VIP3_PopUp.gameObject.SetActive(false);
        VIP4_PopUp.gameObject.SetActive(false);

        //Main buttons
        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        BackButton_Active = true;

        //Option Buttons
        VIP1_Active = true;
        VIP2_Active = true;
        VIP3_Active = true;
        VIP4_Active = true;

        PurchaseFeedback.gameObject.SetActive(false);
        ErrorFeedback.gameObject.SetActive(false);
        defaultColor = PurchaseFeedback.gameObject.GetComponent<Image>().color;

        FadeSpeed = 1;

        PopUpBuyButton.gameObject.SetActive(false);
        PopUpBackButton.gameObject.SetActive(false);

        PopUpBack_Active = false;
        PopUpBuy_Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Feedback transition
        if (PurchaseFeedback.gameObject.activeSelf)
        {
            Color c = PurchaseFeedback.gameObject.GetComponent<Image>().color;
            c.a -= FadeSpeed * Time.deltaTime;
            PurchaseFeedback.gameObject.GetComponent<Image>().color = c;
            if (c.a < 0)
            {
                PurchaseFeedback.gameObject.SetActive(false);
            }
        }

        //Feedback Transition
        if (ErrorFeedback.gameObject.activeSelf)
        {
            Color c = ErrorFeedback.gameObject.GetComponent<Image>().color;
            c.a -= FadeSpeed * Time.deltaTime;
            ErrorFeedback.gameObject.GetComponent<Image>().color = c;
            if (c.a < 0)
            {
                ErrorFeedback.gameObject.SetActive(false);
            }
        }

        //Checking if modified
        if (MoneyValue.ToString() != MoneyOutput.text)
        {
            MoneyOutput.text = MoneyValue.ToString();
        }
        if (GemValue.ToString() != GemOutput.text)
        {
            GemOutput.text = GemValue.ToString();
        }
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

    //VIP Options Selected
    public void VIP_1_Selected()
    {
        if (VIP1_Active)
        {
            VIP1_PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void VIP_2_Selected()
    {
        if (VIP2_Active)
        {
            VIP2_PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void VIP_3_Selected()
    {
        if (VIP3_Active)
        {
            VIP3_PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void VIP_4_Selected()
    {
        if (VIP4_Active)
        {
            VIP4_PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }

    //Pop Up Options Selected
    public void PopUpBackSelected()
    {
        if (VIP1_PopUp.gameObject.activeSelf)
        {
            VIP1_PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (VIP2_PopUp.gameObject.activeSelf)
        {
            VIP2_PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (VIP3_PopUp.gameObject.activeSelf)
        {
            VIP3_PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (VIP4_PopUp.gameObject.activeSelf)
        {
            VIP4_PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
    }
    public void PopUpBuySelected()
    {
        if (VIP1_PopUp.gameObject.activeSelf)
        {
            BuyItem(20);
        }
        else if (VIP2_PopUp.gameObject.activeSelf)
        {
            BuyItem(40);
        }
        else if (VIP3_PopUp.gameObject.activeSelf)
        {
            BuyItem(60);
        }
        else if (VIP4_PopUp.gameObject.activeSelf)
        {
            BuyItem(80);
        }
    }

    void SetNonPopUpButtonsActive(bool active)
    {
        VIPButton_Active = active;
        AvatarButton_Active = active;
        PowerUpButton_Active = active;
        GemButton_Active = active;
        BackButton_Active = active;

        VIP1_Active = active;
        VIP2_Active = active;
        VIP3_Active = active;
        VIP4_Active = active;
    }
    void SetPopUpButtonsActive(bool active)
    {
        PopUpBuy_Active = active;
        PopUpBuyButton.gameObject.SetActive(active);

        PopUpBack_Active = active;
        PopUpBackButton.gameObject.SetActive(active);
    }
    void BuyItem(int price)
    {
        //Check if able to purchase
        if (GemValue >= price)
        {
            GemValue -= price;
            //Purchase successful Feedback
            PurchaseFeedback.gameObject.SetActive(true);
            PurchaseFeedback.gameObject.GetComponent<Image>().color = defaultColor;
            PlayerPrefs.SetInt("GemValue", GemValue);
        }
        else
        {
            //Error Feedback
            ErrorFeedback.gameObject.SetActive(true);
            ErrorFeedback.gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}
