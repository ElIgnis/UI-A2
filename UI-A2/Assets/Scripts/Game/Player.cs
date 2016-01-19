using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float resource;
	public float health;
	Vector3 initalPosition;
	float initalResource, initialHealth;

	// Use this for initialization
	void Start () {
		initalPosition = gameObject.transform.position;
		initalResource = resource;
		initialHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(){
		resource = initalResource;
		health = initialHealth;
		gameObject.transform.position = initalPosition;
	}
}
