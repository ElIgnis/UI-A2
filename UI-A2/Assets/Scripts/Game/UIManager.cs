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
	public GameObject EnterHighscoreUI;
	public Text Highscore;
	public Image HealthBar;
	public Image ResourceBar;
	public GameObject Player;
	public GameObject GameStateManager;

	bool virtualGamepadCreated;
	float HealthBarMinX, HealthBarMaxX;
	float ResourceBarMinX, ResourceBarMaxX;
	float maxHealth, maxResource;
	float currentHealth, currentResource;

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

		HealthBarMaxX = HealthBar.rectTransform.position.x;
		HealthBarMinX = HealthBar.transform.GetChild (0).position.x;
			//HealthBar.rectTransform.position.x - HealthBar.rectTransform.rect.width; //* canvas.scaleFactor;

		ResourceBarMaxX = ResourceBar.rectTransform.position.x;
		ResourceBarMinX = ResourceBar.transform.GetChild (0).position.x;
			//ResourceBar.rectTransform.position.x + ResourceBar.rectTransform.rect.width; //* canvas.scaleFactor;

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

		if (RightHandPlay) {
			RightHandButtons.SetActive (true);
			LeftHandButtons.SetActive (false);
		} 
		else {
			LeftHandButtons.SetActive(true);
			RightHandButtons.SetActive(false);
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

		if (GameStateManager.GetComponent<GameStateManager> ().gameover) {
			GameOverUI.SetActive (true);
		}
		else {
			GameOverUI.SetActive(false);
		}

		if (GameStateManager.GetComponent<GameStateManager> ().enterhighscore) {
			EnterHighscoreUI.transform.GetChild(0).transform.GetComponent<Text>().text = "Final Score: " + Highscore.text;
			EnterHighscoreUI.SetActive(true);
		}
	}
}
