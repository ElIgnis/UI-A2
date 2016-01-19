using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

	public Image thumpad;
	public Image background;
	public Button fireButton;
	public Text Highscore;
	public GameObject player;
	public GameObject projectileManager;
	public GameObject uiManager;
	public GameObject gamestateManager;
	public float fireRate, timePassed;
	public static bool moveBack, moving, shoot, pausebuttonPressed;

	// Use this for initialization
	void Start () {
		shoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveBack) {
			Vector3 origin = background.rectTransform.position;
			Vector3 current = thumpad.rectTransform.position;
			if ((origin - current).magnitude > 0) {
				Vector3 direction = (origin - current).normalized;
				thumpad.rectTransform.position += direction * 250 * Time.deltaTime;
				
				if ((background.rectTransform.position - thumpad.rectTransform.position).magnitude < 1) {
					thumpad.rectTransform.position = background.rectTransform.position;
					moveBack = false;
				}
			}
		}

		if (moving) {
			Vector3 origin = background.rectTransform.position;
			Vector3 newPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1.0f);
			Vector3 direction = newPos - origin;

			Vector3 Translation = direction.normalized * ((Player)player.GetComponent(typeof(Player))).moveSpeed;
			Translation.z = 0;

			player.transform.Translate (Translation * Time.deltaTime);

			Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
	
			pos.x = Mathf.Clamp(pos.x, 0.2f, 0.8f);
			pos.y = Mathf.Clamp(pos.y, 0.1f, 0.8f);

			player.transform.position = Camera.main.ViewportToWorldPoint(pos);
		}

		if (shoot && timePassed > fireRate && player.GetComponent<Player> ().resource > 0) {
			timePassed = 0;
			((BulletManager)projectileManager.GetComponent (typeof(BulletManager))).AddPlayerBullet ();
			player.GetComponent<Player> ().resource -= 3;
		}
		else if (!shoot && player.GetComponent<Player> ().resource < 100) {
			player.GetComponent<Player>().resource += 10 * Time.deltaTime;
			if(player.GetComponent<Player>().resource > 100) {
				player.GetComponent<Player>().resource = 100;
			}
		}

		timePassed += Time.deltaTime;
	}

	public void Dragging(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			moveBack = false;
			float lengthLimit = background.rectTransform.rect.width / 2;
			Vector3 origin = background.rectTransform.position;
			Vector3 newPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1.0f);
			Vector3 direction = newPos - origin;
			if ((newPos - origin).magnitude > lengthLimit) {
				newPos = origin + direction.normalized * lengthLimit;
			}
			thumpad.rectTransform.position = newPos;

			moving = true;
		}
	}
	
	public void EndDragging(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			moveBack = true;
			moving = false;
		}
	}

	public void Fire(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			shoot = true;
		}
	}

	public void StopFire(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			shoot = false;
		}
	}

	public void UseBombSkill(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			((BulletManager)projectileManager.GetComponent (typeof(BulletManager))).ClearEnemyBullet ();
		}
	}

	public void PausePressed(){
		HandlePause ();
	}

	public void HandlePause(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && !gamestateManager.GetComponent<GameStateManager> ().gameover) {
			Time.timeScale = 0;
			gamestateManager.GetComponent<GameStateManager> ().pausegame = true;
			return;
		}

		if (gamestateManager.GetComponent<GameStateManager> ().pausegame && !gamestateManager.GetComponent<GameStateManager> ().gameover) {
			Time.timeScale = 1;
			gamestateManager.GetComponent<GameStateManager> ().pausegame = false;
			return;
		}
	}

	public void ContinueGame(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			player.GetComponent<Player> ().health = 100;
			Time.timeScale = 1;
			gamestateManager.GetComponent<GameStateManager> ().gameover = false;
		}
	}

	public void RestartGame(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			player.GetComponent<Player> ().Reset ();
			Highscore.text = "0";
			projectileManager.GetComponent<BulletManager> ().ClearAllBullet ();
			Time.timeScale = 1;
			gamestateManager.GetComponent<GameStateManager> ().gameover = false;
		}
	}

	public void MainMenu(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			gamestateManager.GetComponent<GameStateManager> ().enterhighscore = true;
		}
	}
}
