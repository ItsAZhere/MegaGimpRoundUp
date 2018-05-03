using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfEnemies : MonoBehaviour {
	GameObject[] spawnpoints;
	int totalEnemies = 0;

	// Use this for initialization
	void Start () {
		foreach (GameObject thing in spawnpoints) {
			spawnEnemy enemy = thing.GetComponent<spawnEnemy> ();

			if (enemy.enemiesSpawned == true) {
				totalEnemies++;
			}
		}
		if (totalEnemies == 4) {
			foreach (GameObject thing in spawnpoints) {
				spawnEnemy enemy = thing.GetComponent<spawnEnemy> ();
				enemy.enemiesSpawned = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
