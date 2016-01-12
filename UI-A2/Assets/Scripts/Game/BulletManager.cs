using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {

	public List<GameObject> BulletList; 
	public GameObject player;
	public GameObject enemy;
	public GameObject playerProjectile;
	public GameObject enemyProjectile;

	// Use this for initialization
	void Start () {
		BulletList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		for (int i = 0; i < BulletList.Count; ++i) {
			if(BulletList[i] == null){
				BulletList.RemoveAt(i);
				continue;
			}

			Vector3 pos = Camera.main.WorldToViewportPoint(BulletList[i].transform.position);

			if(pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1){
				Destroy(BulletList[i]);
				BulletList.RemoveAt(i);
			}
		}
	}

	public void AddPlayerBullet(){
		GameObject clone = (GameObject) Instantiate (playerProjectile, player.transform.position, playerProjectile.transform.rotation);
		Rigidbody2D cloneRigidbody = clone.GetComponent<Rigidbody2D> ();
		cloneRigidbody.AddForce (new Vector2 (0, 100));

		Physics2D.IgnoreCollision (clone.GetComponent<PolygonCollider2D> (), player.GetComponent<PolygonCollider2D> ());

		for (int i = 0; i < BulletList.Count; ++i) {
			if(BulletList[i] == null)
			{
				BulletList.RemoveAt(i);
				continue;
			}
			Physics2D.IgnoreCollision(clone.GetComponent<PolygonCollider2D> (), BulletList[i].GetComponent<PolygonCollider2D> ());
		}

		BulletList.Add (clone);
	}

	public void AddEnemyBullet() {
		GameObject clone = (GameObject) Instantiate (enemyProjectile, enemy.transform.position, enemyProjectile.transform.rotation);
		Rigidbody2D cloneRigidbody = clone.GetComponent<Rigidbody2D> ();
		cloneRigidbody.AddForce (new Vector2 (0, -100));

		Physics2D.IgnoreCollision (clone.GetComponent<PolygonCollider2D> (), enemy.GetComponent<PolygonCollider2D> ());

		for (int i = 0; i < BulletList.Count; ++i) {
			if(BulletList[i] == null)
			{
				BulletList.RemoveAt(i);
				continue;
			}
			Physics2D.IgnoreCollision(clone.GetComponent<PolygonCollider2D> (), BulletList[i].GetComponent<PolygonCollider2D> ());
		}
		
		BulletList.Add (clone);
	}

	public void ClearEnemyBullet(){
		for (int i = 0; i < BulletList.Count; ++i) {
			if(BulletList[i].tag == "EnemyBullet"){
				Destroy(BulletList[i]);
			}
		}

		for (int i = 0; i < BulletList.Count; ++i) {
			if(BulletList[i] == null) {
				BulletList.RemoveAt(i);
			}
		}
	}
}
