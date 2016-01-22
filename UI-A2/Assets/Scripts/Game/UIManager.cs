using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public bool virtualGamepad, RightHandPlay;
	public Image joystick;
	public Button fireButton;
	public Canvas canvas;
	public GameObject GameOverUI;
	public GameObject LeftHandButtons;
	public GameObject RightHandButtons;
	public GameObject OptionsUI;
	public GameObject LeftHand;
	public GameObject RightHand;
	public Scrollbar BGMSlider;
	public Scrollbar SFXSlider;
	public GameObject EnterHighscoreUI;
	public Text Highscore;
	public Text BGMOutput;
	public Text SFXOutput;
	public Image HealthBar;
	public Image ResourceBar;
	public GameObject Player;

	bool virtualGamepadCreated;
	float HealthBarMinX, HealthBarMaxX;
	float ResourceBarMinX, ResourceBarMaxX;
	float maxHealth, maxResource;
	float currentHealth, currentResource;

	float BGMValue;
	float SFXValue;

	// Use this for initialization
	void Start () {
		if (virtualGamepad) {

			joystick.gameObject.SetActive(true);
			fireButton.gameObject.SetActive(true);

			virtualGamepadCreated = true;
		}

		if(PlayerPrefs.HasKey("BGMVolume"))
		{
			BGMValue = PlayerPrefs.GetFloat("BGMVolume");
			BGMSlider.value = BGMValue * 0.01f;
			BGMOutput.text = ((int)BGMValue).ToString();
		}
		else
		{
			PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
		}
		if(PlayerPrefs.HasKey("SFXVolume"))
		{
			SFXValue = PlayerPrefs.GetFloat("SFXVolume");
			SFXSlider.value = SFXValue * 0.01f;
			SFXOutput.text = ((int)SFXValue).ToString();
		}
		else
		{
			PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
		}

		if (PlayerPrefs.HasKey ("Playstyle")) {
			if (PlayerPrefs.GetInt ("RightLeft") == 1) {
				RightHand.SetActive (true);
				LeftHand.SetActive (false);
				RightHandButtons.SetActive (true);
				LeftHandButtons.SetActive (false);
			} else {
				LeftHand.SetActive (true);
				RightHand.SetActive (false);
				LeftHandButtons.SetActive (true);
				RightHandButtons.SetActive (false);
			}
		}

		HealthBarMaxX = HealthBar.rectTransform.position.x;
		HealthBarMinX = HealthBar.transform.GetChild (0).position.x;

		ResourceBarMaxX = ResourceBar.rectTransform.position.x;
		ResourceBarMinX = ResourceBar.transform.GetChild (0).position.x;

		currentHealth = Player.GetComponent<Player> ().health;
		maxHealth = currentHealth;
		currentResource = Player.GetComponent<Player> ().resource;
		maxResource = currentResource;
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

		if (currentHealth != Player.GetComponent<Player> ().health) {
			currentHealth = Player.GetComponent<Player> ().health;
			float healthBarOffset = (currentHealth) * (HealthBarMaxX - HealthBarMinX) / (maxHealth - 0) + HealthBarMinX;
			HealthBar.rectTransform.position = new Vector2(healthBarOffset, HealthBar.rectTransform.position.y);
		}

		if (currentResource != Player.GetComponent<Player> ().resource) {
			currentResource = Player.GetComponent<Player> ().resource;
			float resourceBarOffset = (currentResource) * (ResourceBarMaxX - ResourceBarMinX) / (maxResource - 0) + ResourceBarMinX;
			ResourceBar.rectTransform.position = new Vector2(resourceBarOffset, ResourceBar.rectTransform.position.y);
		}

		if (BGMSlider.value * 100 != BGMValue) {
			BGMValue = BGMSlider.value * 100;
			BGMOutput.text = ((int)(BGMValue)).ToString();
			PlayerPrefs.SetFloat("BGMVolume", BGMValue);
		}
		
		if (SFXSlider.value * 100 != SFXValue) {
			SFXValue = SFXSlider.value * 100;
			SFXOutput.text = ((int)(SFXValue)).ToString();
			PlayerPrefs.SetFloat("SFXVolume", SFXValue);
		}
	}

	public void UIPause(bool active){
		RightHandButtons.transform.FindChild("PauseUI").GetComponent<MovingPauseUI>().Move(active);
		LeftHandButtons.transform.FindChild("PauseUI").GetComponent<MovingPauseUI>().Move(active);
	}

	public void UISnapBackUnPause(){
		RightHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapBack ();
		LeftHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapBack ();
	}

	public void UIOptions(bool active){
		OptionsUI.SetActive (active);
	}

	public void UIOptionsSwapRightButton(){
		RightHand.SetActive (true);
		LeftHand.SetActive (false);
		RightHandButtons.SetActive (true);
		LeftHandButtons.SetActive (true);
		RightHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapFoward ();
		LeftHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapBack ();
		RightHandButtons.SetActive (true);
		LeftHandButtons.SetActive (false);
		PlayerPrefs.SetInt("RightLeft", 1);
	}

	public void UIOptionsSwapLeftButton(){
		LeftHand.SetActive (true);
		RightHand.SetActive (false);
		LeftHandButtons.SetActive(true);
		RightHandButtons.SetActive(true);
		LeftHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapFoward ();
		RightHandButtons.transform.FindChild ("PauseUI").GetComponent<MovingPauseUI> ().SnapBack ();
		LeftHandButtons.SetActive(true);
		RightHandButtons.SetActive(false);
		PlayerPrefs.SetInt("RightLeft", 0);
	}

	public void UIGameOver(){
		GameOverUI.SetActive (true);
	}

	public void UIGameOverReset(){
		GameOverUI.SetActive(false);
	}

	public void UIHighscore(){
		EnterHighscoreUI.transform.GetChild(0).transform.GetComponent<Text>().text = "Final Score: " + Highscore.text;
		EnterHighscoreUI.SetActive(true);
	}

	public void UIResetHighscore(){
		Highscore.text = "0";
	}
}
