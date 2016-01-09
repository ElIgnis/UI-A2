using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonImageHandler : MonoBehaviour
{
    public Button Button;
    public Sprite Active, Inactive;
    public string SceneName, ButtonName;

    // Use this for initialization
    void Start()
    {
        Button = GameObject.Find(ButtonName).GetComponent<Button>();
        if (Application.loadedLevelName == SceneName)
        {
            Button.image.sprite = Active;
        }
        else
        {
            Button.image.sprite = Inactive;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}