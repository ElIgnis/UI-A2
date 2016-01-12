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


        PopUpBack_Active = false;
        PopUpBuy_Active = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
