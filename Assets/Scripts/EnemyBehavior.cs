using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {


	[SerializeField]
	GameObject fireball;

	//for shooting fireballs
	float fireRate;
	float nextFire;

	//forStunning
	public bool isStunned; 


	// Use this for initialization
	void Start () {

		fireRate = 4f;
		nextFire = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {

		//if isStunned is true, enemy stops moving/attacking and can be picked up
		if (isStunned == true) {



		}
		
	}
	//If player bullet hits enemy, enemy is destroyed
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Fireball")
		{
			//Destroy (col.gameObject);
			//Destroy (gameObject);
			isStunned = true;
			Debug.Log ("Player has hit Enemy! Enemy stunned.");
		}
	}
	void CheckIfTimeToFire ()
	{
		if (Time.time > nextFire)
		{
			Instantiate (fireball, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
			}
		else
		{

		}
	}

}
