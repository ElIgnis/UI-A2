using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

	public Image thumpad;
	public Image background;
	public Button fireButton;
	public GameObject player;
	public GameObject projectileManager;
	public GameObject uiManager;
	public GameObject gamestateManager;
	public float fireRate, timePassed;
	public static bool moveBack, moving, shoot, pausebuttonPressed;
	Touch LeftFinger;
	// Use this for initialization
	void Start () {
		shoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
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

			foreach(Touch touch in Input.touches){
				if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
					Vector3 pos = Camera.main.ScreenToViewportPoint(touch.position);
					if(pos.x <= 0.5f){
						LeftFinger = touch;
						break;
					}
				}
			}

			if (moving) {
				Vector3 origin = background.rectTransform.position;
				Vector3 newPos = new Vector3 (LeftFinger.position.x, LeftFinger.position.y, 1.0f);
				Vector3 direction = newPos - origin;

				Vector3 Translation = direction.normalized * player.GetComponent<Player>().moveSpeed;
				Translation.z = 0;

				player.transform.Translate (Translation * Time.deltaTime);

				Vector3 pos = Camera.main.WorldToViewportPoint (player.transform.position);
	
				pos.x = Mathf.Clamp (pos.x, 0.2f, 0.8f);
				pos.y = Mathf.Clamp (pos.y, 0.1f, 0.8f);

				player.transform.position = Camera.main.ViewportToWorldPoint (pos);
			}

			if (shoot && timePassed > fireRate && player.GetComponent<Player> ().resource > 0) {
				timePassed = 0;
				projectileManager.GetComponent <BulletManager> ().AddPlayerBullet ();
				player.GetComponent<Player> ().resource -= 3;
			} 
			else if (!shoot && player.GetComponent<Player> ().resource < 100) {
				player.GetComponent<Player> ().resource += 10 * Time.deltaTime;
				if (player.GetComponent<Player> ().resource > 100) {
					player.GetComponent<Player> ().resource = 100;
				}
			}

			if (gamestateManager.GetComponent<GameStateManager> ().gameover) {
				EndDragging ();
			}

			timePassed += Time.deltaTime;
		}
	}

	public void Dragging(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && ! gamestateManager.GetComponent<GameStateManager> ().gameover) {
			moveBack = false;
			float lengthLimit = background.rectTransform.rect.width / 2;
			Vector3 origin = background.rectTransform.position;
			Vector3 newPos = new Vector3 (LeftFinger.position.x, LeftFinger.position.y, 1.0f);
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
			projectileManager.GetComponent <BulletManager>().ClearEnemyBullet ();
		}
	}

	public void PausePressed(){
		HandlePause ();
	}

	public void HandlePause(){
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && !gamestateManager.GetComponent<GameStateManager> ().gameover) {
			projectileManager.GetComponent <BulletManager>().PauseBulletUpdate ();
			gamestateManager.GetComponent<GameStateManager> ().pausegame = true;
			uiManager.GetComponent<UIManager>().UIPause(true);
			return;
		}

		if (gamestateManager.GetComponent<GameStateManager> ().pausegame && !gamestateManager.GetComponent<GameStateManager> ().gameover) {
			projectileManager.GetComponent <BulletManager>().UnPauseBulletUpdate ();
			gamestateManager.GetComponent<GameStateManager> ().pausegame = false;
			uiManager.GetComponent<UIManager>().UIPause(false);
			return;
		}
	}

	public void Options(){
		uiManager.GetComponent<UIManager> ().UIOptions (true);
	}

	public void OptionsConfirmed(){
		uiManager.GetComponent<UIManager> ().UIOptions (false);
	}

	public void ButtonRightClicked(){
		uiManager.GetComponent<UIManager> ().UIOptionsSwapRightButton ();
	}

	public void ButtonLeftClicked(){
		uiManager.GetComponent<UIManager> ().UIOptionsSwapLeftButton ();
	}

	public void ContinueGame(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			player.GetComponent<Player> ().health = 100;
			projectileManager.GetComponent<BulletManager>().UnPauseBulletUpdate();
			gamestateManager.GetComponent<GameStateManager> ().gameover = false;
			EndDragging();
			uiManager.GetComponent<UIManager>().UIGameOverReset();
		}
	}

	public void RestartGame(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			player.GetComponent<Player> ().Reset ();
			projectileManager.GetComponent<BulletManager> ().ClearAllBullet ();
			uiManager.GetComponent<UIManager>().UIResetHighscore();

			if(gamestateManager.GetComponent<GameStateManager> ().pausegame){
				gamestateManager.GetComponent<GameStateManager> ().pausegame = false;
				uiManager.GetComponent<UIManager>().UISnapBackUnPause();
			}
			else if(gamestateManager.GetComponent<GameStateManager> ().gameover){
				gamestateManager.GetComponent<GameStateManager> ().gameover = false;
				uiManager.GetComponent<UIManager>().UIGameOverReset();
			}

			EndDragging();
		}
	}

	public void MainMenu(){
		if (!gamestateManager.GetComponent<GameStateManager> ().enterhighscore) {
			gamestateManager.GetComponent<GameStateManager> ().enterhighscore = true;
			uiManager.GetComponent<UIManager>().UIHighscore();
		}
	}

	public void BackToMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
