﻿using UnityEngine;
using System.Collections;

public class InitPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("RightLeft"))
        {
            PlayerPrefs.SetInt("RightLeft", 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
