using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpButtonHandler : MonoBehaviour
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

    //Option Buttons
    public Button RinOption;

    //Upgrade Buttons
    public Button UpgradeHealButton;
    public Button UpgradeSprintButton;
    public Button UpgradeExhaustButton;
    public Button UpgradeFireballButton;

    public Button PopUpBackButton;

    public Image RinSkillPopUp;

    //Non Pop up buttons active
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                BackButton_Active,
                RinOption_Active;

    //Pop up buttons active
    private bool PopUpBack_Active,
                 UpgradeHeal_Active,
                 UpgradeSprint_Active,
                 UpgradeExhaust_Active,
                 UpgradeFireball_Active;

    //Feedback Screens
    public Image PurchaseFeedback;
    public Image ErrorFeedback;
    private float FadeSpeed;
    private Color defaultColor;

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
        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        BackButton_Active = true;
        RinOption_Active = true;

        RinSkillPopUp.gameObject.SetActive(false);

        PurchaseFeedback.gameObject.SetActive(false);
        ErrorFeedback.gameObject.SetActive(false);
        defaultColor = PurchaseFeedback.gameObject.GetComponent<Image>().color;
        //Speed of feedback transition
        FadeSpeed = 1;

        SetPopUpButtonsActive(false);
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
    public void VIPButtonSelected()
    {
        if (VIPButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToVIPShop();
        }
    }
    public void BackButtonSelected()
    {
        if (BackButton_Active)
        {
            gameObject.GetComponent<SceneChanger>().ChangeToMenu();
        }
    }

    //Option selected
    public void RinOptionSelected()
    {
        RinSkillPopUp.gameObject.SetActive(true);
        SetNonPopUpButtonsActive(false);
        SetPopUpButtonsActive(true);
    }

    //Upgrade ButtonSelected
    public void UpgradeSelected()
    {
        BuyItem(777);
    }

    public void PopUpBackSelected()
    {
        RinSkillPopUp.gameObject.SetActive(false);
        SetNonPopUpButtonsActive(true);
        SetPopUpButtonsActive(false);
    }

    void BuyItem(int price)
    {
        //Check if able to purchase
        if (MoneyValue >= price)
        {
            MoneyValue -= price;
            //Purchase successful Feedback
            PurchaseFeedback.gameObject.SetActive(true);
            PurchaseFeedback.gameObject.GetComponent<Image>().color = defaultColor;
            PlayerPrefs.SetInt("MoneyValue", MoneyValue);
        }
        else
        {
            //Error Feedback
            ErrorFeedback.gameObject.SetActive(true);
            ErrorFeedback.gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
    void SetNonPopUpButtonsActive(bool active)
    {
        VIPButton_Active = active;
        AvatarButton_Active = active;
        PowerUpButton_Active = active;
        GemButton_Active = active;
        BackButton_Active = active;

        RinOption_Active = active;
    }
    void SetPopUpButtonsActive(bool active)
    {
        PopUpBack_Active = active;

        UpgradeHeal_Active = active;
        UpgradeSprint_Active = active;
        UpgradeExhaust_Active = active;
        UpgradeFireball_Active = active;
    }
}
