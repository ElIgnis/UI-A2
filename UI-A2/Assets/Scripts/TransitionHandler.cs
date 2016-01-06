using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionHandler : MonoBehaviour
{
    public Image InfoBarBG;
    public Image Title;

    private Vector3 InfoBarBGPos;    //Current position
    private Vector3 TitlePos;   //Current position
 
    float Destination;  //Destination position

    public float TransitionSpeed = 10.0f;   //Speed of Transition

    public Vector3 worldPos;

    // Use this for initialization
    void Start()
    {
        Destination = 315.25f;
        InfoBarBGPos = InfoBarBG.transform.position;
        TitlePos = Title.transform.position;
        //InfoBarBG.transform.position = new Vector3(315.25f, InfoBarBGPos.y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        InfoBarTransition();

        TitleTransition();

        worldPos = InfoBarBG.transform.position;
    }

    void InfoBarTransition()
    {
        if (InfoBarBG.transform.position.x != Destination)
        {
            InfoBarBGPos.x += TransitionSpeed * Time.deltaTime;
            if (InfoBarBGPos.x > Destination)
            {
                InfoBarBGPos.x = Destination;
            }

            InfoBarBG.transform.position = InfoBarBGPos;
        }
    }

    void TitleTransition()
    {
        if (Title.transform.position.x != Destination)
        {
            TitlePos.x += TransitionSpeed * Time.deltaTime;
            if (TitlePos.x > Destination)
            {
                TitlePos.x = Destination;
            }

            Title.transform.position = TitlePos;
        }
    }
}
