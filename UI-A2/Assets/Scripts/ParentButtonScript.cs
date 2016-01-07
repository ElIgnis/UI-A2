using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParentButtonScript : MonoBehaviour
{
    public Button PlayBtn;
    public Button CreditsBtn;
    public Button HSBtn;
    public Button InfoBtn;
    public Button ShopBtn;
    public Button FLBtn;
    public Button OptionBtn;

    public static Vector3 PlayBtnPos;
    public static bool PlayActive;

    public static Vector3 CreditsBtnPos;
    public static bool CreditsActive;

    public static Vector3 HSBtnPos;
    public static bool HSActive;

    public static Vector3 InfoBtnPos;
    public static bool InfoActive;

    public static Vector3 ShopBtnPos;
    public static bool ShopActive;

    public static Vector3 FLBtnPos;
    public static bool FLActive;

    public static Vector3 OptionBtnPos;
    public static bool OptionActive;

    public Image Wheel;
    private float NumAngles;
    private float WheelAngle;
    static public float[] AngleList = new float[6];
    Vector3 initialPoint, finalPoint;

    // Use this for initialization
    void Start()
    {
        NumAngles = 6;
        for(int i = 1; i < NumAngles; ++i)
        {
            AngleList[i] = AngleList[0] + i * 60;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MouseDown()
    {
        initialPoint = Input.mousePosition;
    }
    
    public void SpinWheel()
    {
        Vector3 newPos;
        Vector3 finalPos;
        float WheelArc = Wheel.rectTransform.rect.width / 2;

        //Drag direction check
        finalPoint = Input.mousePosition;
        Vector3 difference = finalPoint - initialPoint;
        
        WheelAngle += difference.y * 0.001f;

        //Calc the angle to spin for all buttons
        for (int i = 0; i < NumAngles; ++i)
        {
            AngleList[i] += WheelAngle;
            newPos = new Vector3(Wheel.rectTransform.position.x * Mathf.Sin(AngleList[i]), Wheel.rectTransform.position.y * Mathf.Cos(AngleList[i]), 0.0f);
            finalPos = Wheel.rectTransform.position + (newPos).normalized * WheelArc;

            switch (i)
            {
                case 0:
                    PlayBtn.transform.position = finalPos;
                    PlayBtnPos = finalPos;
                    break;
                case 1:
                    CreditsBtn.transform.position = finalPos;
                    CreditsBtnPos = finalPos;
                    break;
                default:
                    break;
            }
            
        }
        
        
        //newPos = Wheel.rectTransform.position + (Wheel.rectTransform.position).normalized * WheelArc;
        
        
        
        //TODO: Wheel rotation
        //if(buttonType == PlayBtn)
        //{
        //    buttonType.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        //    PlayBtnPos = buttonType.transform.position;
        //}
        //if (buttonType == CreditsBtn)
        //{
        //    buttonType.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        //    CreditsBtnPos = buttonType.transform.position;
        //}
    }
}
