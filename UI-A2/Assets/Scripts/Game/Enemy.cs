using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectileManager;
	public float fireRate, timePassed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (timePassed > fireRate) {
			((BulletManager)projectileManager.GetComponent (typeof(BulletManager))).AddEnemyBullet();
			timePassed = 0f;
		}
		timePassed += Time.deltaTime;
	}
}
