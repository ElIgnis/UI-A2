﻿using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeToMenu() {
        Application.LoadLevel("MainMenu");
    }
}
