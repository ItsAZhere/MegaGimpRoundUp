﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButtonPressed(){
		SceneManager.LoadScene("Level 1");
	}
	public void InstructionsButtonPressed(){
		SceneManager.LoadScene ("Instruction");
	}
	public void MenuButtonPressed(){
		SceneManager.LoadScene("Start");
	}
}
