using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeBack : MonoBehaviour
{

    public Image InfoBarBG;
    public Image Title;
    public Image DestinationPoint;
    public ScrollRect ScrollingView;

    private Vector3 InfoBarBGPos;    //Current position
    private Vector3 TitlePos;   //Current position
    private Vector3 ScrollViewPos;   //Current position
    private ushort ClearCount;
    private bool Swipe;

    float Destination;  //Destination position

    public float TransitionSpeed;   //Speed of Transition
    private Vector3 worldPos, initialPoint, endPoint;
    private float dragTime, dragSpeed;
    private bool dragStarted;

    // Use this for initialization
    void Start()
    {
        Swipe = false;
        dragStarted = false;
        ClearCount = 0;
        Destination = DestinationPoint.transform.position.x;
        InfoBarBGPos = InfoBarBG.transform.position;
        TitlePos = Title.transform.position;
        ScrollViewPos = ScrollingView.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dragStarted)
        {
            dragTime += Time.deltaTime;
        }
        
        if (Swipe)
        {
            InfoBarTransition();
            TitleTransition();
            ScrollViewTransition();
        }

        if (ClearCount == 3)
        {
            Application.LoadLevel("MainMenu");
        }

        worldPos = InfoBarBG.transform.position;
    }

    public void DragBegin()
    {
        initialPoint = Input.mousePosition;
        dragStarted = true;
        dragTime = 0.0f;
    }

    public void DragEnd()
    {
        endPoint = Input.mousePosition;
        Vector3 difference = endPoint - initialPoint;

        dragSpeed = TransitionSpeed / dragTime;

        //Check for left drag and less than 1 sec of drag time
        if (difference.x < -100 && dragSpeed < -5000.0f)
        {
            Swipe = true;
            dragStarted = false;
            dragSpeed = 0.0f;
        }
    }

    void InfoBarTransition()
    {
        if (InfoBarBG.transform.position.x != Destination)
        {
            InfoBarBGPos.x += TransitionSpeed * Time.deltaTime;
            InfoBarBG.transform.Translate(TransitionSpeed * Time.deltaTime, 0, 0);
            if (InfoBarBG.transform.position.x < Destination)
            {
                InfoBarBG.transform.position = new Vector3(Destination, InfoBarBG.transform.position.y, InfoBarBG.transform.position.z);
                ++ClearCount;
            }
        }
        else
        {
            ++ClearCount;
        }
    }

    void TitleTransition()
    {
        if (Title.transform.position.x != Destination)
        {
            TitlePos.x += TransitionSpeed * Time.deltaTime;
            Title.transform.Translate(TransitionSpeed * Time.deltaTime, 0, 0);
            if (Title.transform.position.x < Destination)
            {
                Title.transform.position = new Vector3(Destination, Title.transform.position.y, Title.transform.position.z);
                ++ClearCount;
            }
        }
        else
        {
            ++ClearCount;
        }
    }

    void ScrollViewTransition()
    {
        if (ScrollingView.transform.position.x != Destination)
        {
            ScrollViewPos.x += TransitionSpeed * Time.deltaTime;
            ScrollingView.transform.Translate(TransitionSpeed * Time.deltaTime, 0, 0);
            if (ScrollingView.transform.position.x < Destination)
            {
                ScrollingView.transform.position = new Vector3(Destination, ScrollingView.transform.position.y, ScrollingView.transform.position.z);
                ++ClearCount;
            }
        }
        else
        {
            ++ClearCount;
        }
    }
}
