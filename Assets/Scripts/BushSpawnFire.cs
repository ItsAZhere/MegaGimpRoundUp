using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushSpawnFire : MonoBehaviour {
	public SpriteRenderer SR;
	public GameObject fireball, tempPlayer;

	bool inSpace;
	WaitForSeconds wait;

	// Use this for initialization
	void Start () {
		wait = new WaitForSeconds (3);
	}
	
	// Update is called once per frame
	void Update () {
		if (!SR.enabled) {

		}
	}

	IEnumerator Shoot(){
		while (inSpace) {
			Debug.Log ("Shot");
			Instantiate (fireball);
			yield return wait;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("Player")) {
			tempPlayer = coll.gameObject;
			inSpace = true;
			StartCoroutine (Shoot ());
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if (coll.CompareTag ("Player")) {
			tempPlayer = null;
			inSpace = false;
		}
	}
}
