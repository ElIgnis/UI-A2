using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    public Button Button_Right;
    public Button Button_Left;

    public Button ConfirmButton;

    public Sprite Image_Right;
    public Sprite Image_Left;

    public Sprite Image_Right_Active;
    public Sprite Image_Left_Active;

    private bool Active_Right;
    private bool Active_Left;

    public Text BGMOutput;
    public Text SFXOutput;

    public Scrollbar BGMSlider;
    public Scrollbar SFXSlider;

    private float BGMValue;
    private float SFXValue;

    public Image ConfirmFeedback;
    private float FadeSpeed;
    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        ConfirmFeedback.gameObject.SetActive(false);
        FadeSpeed = 1;
        defaultColor = ConfirmFeedback.gameObject.GetComponent<Image>().color;

        if(PlayerPrefs.HasKey("BGMVolume"))
        {
            BGMValue = PlayerPrefs.GetFloat("BGMVolume");
            BGMSlider.value = BGMValue * 0.01f;
            BGMOutput.text = BGMValue.ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
        }
        if(PlayerPrefs.HasKey("SFXVolume"))
        {
            SFXValue = PlayerPrefs.GetFloat("SFXVolume");
            SFXSlider.value = SFXValue * 0.01f;
            SFXOutput.text = SFXValue.ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        }

        if (PlayerPrefs.HasKey("RightLeft"))
        {
            if (PlayerPrefs.GetInt("RightLeft") == 1)
            {
                Button_Right.image.sprite = Image_Right_Active;
                Button_Left.image.sprite = Image_Left;
            }
            else
            {
                Button_Left.image.sprite = Image_Left_Active;
                Button_Right.image.sprite = Image_Right;
            }
        }
        else
        {
            PlayerPrefs.SetInt("RightLeft",1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(ConfirmFeedback.gameObject.activeSelf)
        {
            Color c = ConfirmFeedback.gameObject.GetComponent<Image>().color;
            c.a -= FadeSpeed * Time.deltaTime;
            ConfirmFeedback.gameObject.GetComponent<Image>().color = c;
            if (c.a < 0)
            {
                ConfirmFeedback.gameObject.SetActive(false);
            }
        }

        if(BGMSlider.value * 100 != BGMValue)
        {
            BGMValue = BGMSlider.value * 100;
            int value = (int)BGMValue;
            BGMOutput.text = value.ToString();
        }

        if (SFXSlider.value * 100 != SFXValue)
        {
            SFXValue = SFXSlider.value * 100;
            int value = (int)SFXValue;
            SFXOutput.text = value.ToString();
        }
    }

    public void ButtonRightSelected()
    {
        Button_Right.image.sprite = Image_Right_Active;
        Button_Left.image.sprite = Image_Left;
    }

    public void ButtonLeftSelected()
    {
        Button_Left.image.sprite = Image_Left_Active;
        Button_Right.image.sprite = Image_Right;
    }

    public void ConfirmButtonSelected()
    {
        if(Button_Left.image.sprite == Image_Left_Active)
        {
            PlayerPrefs.SetInt("RightLeft", 0);
        }
        else
        {
            PlayerPrefs.SetInt("RightLeft", 1);
        }

        PlayerPrefs.SetFloat("BGMVolume", BGMValue);
        PlayerPrefs.SetFloat("SFXVolume", SFXValue);

        ConfirmFeedback.gameObject.SetActive(true);
        ConfirmFeedback.gameObject.GetComponent<Image>().color = defaultColor;
    }
}
