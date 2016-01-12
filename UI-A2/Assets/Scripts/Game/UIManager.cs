using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public bool virtualGamepad, RightHandPlay;
	public Image joystick;
	public Button fireButton;
	public Canvas canvas;
	public GameObject LeftHandButtons;
	public GameObject RightHandButtons;

	bool virtualGamepadCreated;

	// Use this for initialization
	void Start () {
		if (virtualGamepad) {

			joystick.gameObject.SetActive(true);
			fireButton.gameObject.SetActive(true);

			virtualGamepadCreated = true;
		}

		if (RightHandPlay) {
			RightHandButtons.SetActive (true);
			LeftHandButtons.SetActive (false);
		} 
		else {
			LeftHandButtons.SetActive(true);
			RightHandButtons.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (virtualGamepad) {
			if (!virtualGamepadCreated) {
				joystick.gameObject.SetActive(true);
				fireButton.gameObject.SetActive(true);
				virtualGamepadCreated = true;
			}
		} 
		else {
			if (virtualGamepadCreated) {
				joystick.gameObject.SetActive(false);
				fireButton.gameObject.SetActive(false);
				virtualGamepadCreated = false;
			}
		}

		if (RightHandPlay) {
			RightHandButtons.SetActive (true);
			LeftHandButtons.SetActive (false);
		} 
		else {
			LeftHandButtons.SetActive(true);
			RightHandButtons.SetActive(false);
		}
	}
}
