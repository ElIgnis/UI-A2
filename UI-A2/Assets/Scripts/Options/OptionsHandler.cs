using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    public Button Button_1Hand;
    public Button Button_2Hand;
    public Button Button_Right;
    public Button Button_Left;

    public Sprite Image_1Hand;
    public Sprite Image_2Hand;
    public Sprite Image_Right;
    public Sprite Image_Left;

    public Sprite Image_1Hand_Active;
    public Sprite Image_2Hand_Active;
    public Sprite Image_Right_Active;
    public Sprite Image_Left_Active;

    private bool Active_1Hand;
    private bool Active_2Hand;
    private bool Active_Right;
    private bool Active_Left;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Button1HandSelected()
    {
        Button_1Hand.image.sprite = Image_1Hand_Active;
        Button_2Hand.image.sprite = Image_2Hand;
    }
    public void Button2HandSelected()
    {
        Button_2Hand.image.sprite = Image_2Hand_Active;
        Button_1Hand.image.sprite = Image_1Hand;
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
}
