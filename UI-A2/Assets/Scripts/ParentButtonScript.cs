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
    private float WheelAngle;
    private float NumAngles = 6;    //Number of buttons

    private Vector3 initialPoint, finalPoint;
    private Vector3 finalPos;
    private float initialTime, flickSpeed, RotationSpeed, holdTimer;
    private bool isFlicked;



    // Use this for initialization
    void Start()
    {
        isFlicked = false;
        RotationSpeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //FlickWheel();
        //if (isFlicked == true)
        //{
           
        //}
        //else
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        holdTimer += Time.deltaTime;
        //        if(holdTimer > 0.2f)
        //        {
        //            SpinWheel();
        //        }
        //    }
        //}
    }
    
    public void SpinWheel()
    {
        //Drag direction check
        initialPoint = Input.mousePosition;
        Vector3 difference = finalPoint - initialPoint;

        WheelAngle = difference.normalized.y * RotationSpeed * Time.deltaTime;
        finalPoint = Input.mousePosition;

        //Calc the angle to spin for all buttons
        for (int i = 0; i < NumAngles; ++i)
        {
            switch (i)
            {
                case 0:
                    finalPos = RotatePointAroundPoint(OptionBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    OptionBtn.transform.position = finalPos;
                    OptionBtnPos = finalPos;
                    break;
                case 1:
                    finalPos = RotatePointAroundPoint(CreditsBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    CreditsBtn.transform.position = finalPos;
                    CreditsBtnPos = finalPos;
                    break;
                case 2:
                    finalPos = RotatePointAroundPoint(HSBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    HSBtn.transform.position = finalPos;
                    HSBtnPos = finalPos;
                    break;
                case 3:
                    finalPos = RotatePointAroundPoint(InfoBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    InfoBtn.transform.position = finalPos;
                    InfoBtnPos = finalPos;
                    break;
                case 4:
                    finalPos = RotatePointAroundPoint(ShopBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    ShopBtn.transform.position = finalPos;
                    ShopBtnPos = finalPos;
                    break;
                case 5:
                    finalPos = RotatePointAroundPoint(FLBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, WheelAngle));
                    FLBtn.transform.position = finalPos;
                    FLBtnPos = finalPos;
                    break;
                default:
                    break;
            }
        }
    }

    Vector3 RotatePointAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }

    //public void FlickBegin()
    //{
    //    //Store pos of flick
    //    initialPoint = Input.mousePosition;
    //    initialTime += Time.deltaTime;
    //    isFlicked = true;
    //}

    //public void FlickWheel()
    //{
    //    if (Input.GetMouseButtonDown(0) == false)
    //    {
    //        if (initialTime > 0.0f)
    //        {
    //            finalPoint = Input.mousePosition;
    //            flickSpeed = ((finalPoint - initialPoint).magnitude) * 5.0f;
    //            initialTime = 0.0f;
    //        }
    //        Vector3 difference = finalPoint - initialPoint;
    //        WheelAngle = difference.normalized.y * flickSpeed * Time.deltaTime;

    //        //Calc the angle to spin for all buttons
    //        for (int i = 0; i < NumAngles; ++i)
    //        {
    //            switch (i)
    //            {
    //                case 0:
    //                    finalPos = RotatePointAroundPoint(OptionBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    OptionBtn.transform.position = finalPos;
    //                    OptionBtnPos = finalPos;
    //                    break;
    //                case 1:
    //                    finalPos = RotatePointAroundPoint(CreditsBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    CreditsBtn.transform.position = finalPos;
    //                    CreditsBtnPos = finalPos;
    //                    break;
    //                case 2:
    //                    finalPos = RotatePointAroundPoint(HSBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    HSBtn.transform.position = finalPos;
    //                    HSBtnPos = finalPos;
    //                    break;
    //                case 3:
    //                    finalPos = RotatePointAroundPoint(InfoBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    InfoBtn.transform.position = finalPos;
    //                    InfoBtnPos = finalPos;
    //                    break;
    //                case 4:
    //                    finalPos = RotatePointAroundPoint(ShopBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    ShopBtn.transform.position = finalPos;
    //                    ShopBtnPos = finalPos;
    //                    break;
    //                case 5:
    //                    finalPos = RotatePointAroundPoint(FLBtn.transform.position, Wheel.rectTransform.position, Quaternion.Euler(0, 0, -WheelAngle));
    //                    FLBtn.transform.position = finalPos;
    //                    FLBtnPos = finalPos;
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        //Decrease speed overtime
    //        if (flickSpeed - Time.deltaTime < 0.0f && isFlicked == true)
    //        {
    //            flickSpeed = 0.0f;
    //            isFlicked = false;
    //        }
    //        else
    //        {
    //            flickSpeed -= 100.0f * Time.deltaTime;
    //        }
    //    }
    //}
}
