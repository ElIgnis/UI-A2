using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public GameObject player, uiManager;
	public bool gameover = false;
	public bool pausegame = false;
	public bool enterhighscore = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Player> ().health <= 0) {
			Time.timeScale = 0;
			gameover = true;
			uiManager.GetComponent<UIManager>().UIGameOver();
		}
	}
}
