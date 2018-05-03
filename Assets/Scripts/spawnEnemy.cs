using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private gameManager GM;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    private int chance;


	void Start () {

        lastSpawnTime = Time.time;
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();

		
	}
	
	
	void Update () {
		
	}
}
