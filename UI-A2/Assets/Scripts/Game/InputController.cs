using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

	public Image thumpad;
	public Image background;
	public Button fireButton;
	public GameObject player;
	public GameObject projectileManager;
	public float fireRate, timePassed;
	public static bool moveBack, moving, shoot;

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

		if (shoot && timePassed > fireRate) {
			timePassed = 0;
			((BulletManager)projectileManager.GetComponent (typeof(BulletManager))).AddPlayerBullet ();
		}

		timePassed += Time.deltaTime;
	}

	public void Dragging(){
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
	
	public void EndDragging(){
		moveBack = true;
		moving = false;
	}

	public void Fire(){
		shoot = true;
	}

	public void StopFire(){
		shoot = false;
	}
}
