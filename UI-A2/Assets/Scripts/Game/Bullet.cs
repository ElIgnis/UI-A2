using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Text highscore;

	// Use this for initialization
	void Start () {
		highscore = GameObject.Find ("Highscore").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player>().health -= 5;
			if(col.gameObject.GetComponent<Player>().health < 0){
				col.gameObject.GetComponent<Player>().health = 0;
			}
			Destroy(gameObject);
		}
		else if (col.gameObject.tag == "Enemy") {
			int score = int.Parse(highscore.text);
			score += 3;
			highscore.text = score.ToString();
			Destroy(gameObject);
		}
	}
}
