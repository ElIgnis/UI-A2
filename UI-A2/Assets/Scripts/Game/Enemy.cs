using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectileManager, gamestateManager;
	public float fireRate, timePassed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (timePassed > fireRate) {
			projectileManager.GetComponent <BulletManager>().AddEnemyBullet();
			timePassed = 0f;
		}
		if (!gamestateManager.GetComponent<GameStateManager> ().pausegame && !gamestateManager.GetComponent<GameStateManager> ().gameover) {
			timePassed += Time.deltaTime;
		}
	}
}
