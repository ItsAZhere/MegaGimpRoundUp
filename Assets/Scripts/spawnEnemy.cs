﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;

  //  private gameManager GM;
    private float lastSpawnTime;
	public bool enemiesSpawned;
    private int chance;


	void Start () {

 //       GM = GameObject.Find("gameManager").GetComponent<gameManager>();

		
	}
	
	
	void Update () {
		
	}
}
