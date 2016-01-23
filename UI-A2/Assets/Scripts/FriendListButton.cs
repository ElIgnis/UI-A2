using UnityEngine;
using System.Collections;

public class FriendListButton : MonoBehaviour {

	public GameObject ConfirmationUI;
	bool duelButtonPressed;
	// Use this for initialization
	void Start () {
		ConfirmationUI.SetActive (false);
		duelButtonPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DuelPressed(){
		if (!duelButtonPressed) {
			ConfirmationUI.SetActive (true);
			duelButtonPressed = true;
		}
	}

	public void ConfirmationPressed(){
		ConfirmationUI.SetActive (false);
	}
}
