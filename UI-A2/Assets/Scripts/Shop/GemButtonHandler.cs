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

    public Image Gem20PopUp;
    public Image Gem40PopUp;
    public Image Gem60PopUp;
    public Image Gem100PopUp;

    public Button PopUpBackButton;
    public Button PopUpBuyButton;

    //Non Pop up buttons
    private bool VIPButton_Active,
                AvatarButton_Active,
                PowerUpButton_Active,
                GemButton_Active,
                BackButton_Active,
                GemOption20Button_Active,
                GemOption40Button_Active,
                GemOption60Button_Active,
                GemOption100Button_Active;

    //Confirm Screen
    public Image PurchaseFeedback;
    private float FadeSpeed;
    private Color defaultColor;

    //Pop up buttons
    private bool PopUpBack_Active,
                 PopUpBuy_Active;
    // Use this for initialization
    void Start()
    {
        Gem20PopUp.gameObject.SetActive(false);
        Gem40PopUp.gameObject.SetActive(false);
        Gem60PopUp.gameObject.SetActive(false);
        Gem100PopUp.gameObject.SetActive(false);

        VIPButton_Active = true;
        AvatarButton_Active = true;
        PowerUpButton_Active = true;
        GemButton_Active = true;
        BackButton_Active = true;

        GemOption20Button_Active = true;
        GemOption40Button_Active = true;
        GemOption60Button_Active = true;
        GemOption100Button_Active = true;

        PurchaseFeedback.gameObject.SetActive(false);
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
    public void GemOption20Selected()
    {
        if(GemOption20Button_Active)
        {
            Gem20PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void GemOption40Selected()
    {
        if (GemOption40Button_Active)
        {
            Gem40PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void GemOption60Selected()
    {
        if (GemOption60Button_Active)
        {
            Gem60PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }
    public void GemOption100Selected()
    {
        if (GemOption100Button_Active)
        {
            Gem100PopUp.gameObject.SetActive(true);
            SetNonPopUpButtonsActive(false);
            SetPopUpButtonsActive(true);
        }
    }

    //Pop Up Options Selected
    public void PopUpBackSelected()
    {
        if (Gem20PopUp.gameObject.activeSelf)
        {
            Gem20PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (Gem40PopUp.gameObject.activeSelf)
        {
            Gem40PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (Gem60PopUp.gameObject.activeSelf)
        {
            Gem60PopUp.gameObject.SetActive(false);
            SetNonPopUpButtonsActive(true);
            SetPopUpButtonsActive(false);
        }
        else if (Gem100PopUp.gameObject.activeSelf)
        {
            Gem100PopUp.gameObject.SetActive(false);
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

        GemOption20Button_Active = active;
        GemOption40Button_Active = active;
        GemOption60Button_Active = active;
        GemOption100Button_Active = active;
    }
    void SetPopUpButtonsActive(bool active)
    {
        PopUpBuy_Active = active;
        PopUpBuyButton.gameObject.SetActive(active);

        PopUpBack_Active = active;
        PopUpBackButton.gameObject.SetActive(active);
    }
}
