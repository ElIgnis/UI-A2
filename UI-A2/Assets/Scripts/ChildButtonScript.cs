using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChildButtonScript : MonoBehaviour
{
    public Button PlayBtn;
    public Button CreditsBtn;
    public Button HSBtn;
    public Button InfoBtn;
    public Button ShopBtn;
    public Button FLBtn;
    public Button OptionBtn;

    // Use this for initialization
    void Start()
    {
        //Assign button positions
        Vector3 zero = new Vector3(0, 0, 0);

        //Prevent snapping if the wheel is not spun
        if (ParentButtonScript.PlayBtnPos != zero)
        {
            PlayBtn.transform.position = ParentButtonScript.PlayBtnPos;
        }
        if (ParentButtonScript.CreditsBtnPos != zero)
        {
            CreditsBtn.transform.position = ParentButtonScript.CreditsBtnPos;
        }
        if (ParentButtonScript.HSBtnPos != zero)
        {
            HSBtn.transform.position = ParentButtonScript.HSBtnPos;
        }
        if (ParentButtonScript.InfoBtnPos != zero)
        {
            InfoBtn.transform.position = ParentButtonScript.InfoBtnPos;
        }
        if (ParentButtonScript.ShopBtnPos != zero)
        {
            ShopBtn.transform.position = ParentButtonScript.ShopBtnPos;
        }
        if (ParentButtonScript.FLBtnPos != zero)
        {
            FLBtn.transform.position = ParentButtonScript.FLBtnPos;
        }
        if (ParentButtonScript.OptionBtnPos != zero)
        {
            OptionBtn.transform.position = ParentButtonScript.OptionBtnPos;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}