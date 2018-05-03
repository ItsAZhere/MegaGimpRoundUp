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

	public IEnumerator Shoot(Collider2D target){
		while (inSpace) {
			Debug.Log ("Shot");
			//Instantiate (fireball);
			GameObject fireballPrefab = fireball;

			Vector3 startPosition = gameObject.transform.position;
			Vector3 targetPosition = target.transform.position;
			startPosition.z = fireballPrefab.transform.position.z;
			targetPosition.z = fireballPrefab.transform.position.z;
			Instantiate(fireball,transform.parent);

			GameObject newFireball = (GameObject)Instantiate(fireball);
			newFireball.transform.position = startPosition;
			EnemyFireball fireballComp = newFireball.GetComponent<EnemyFireball>();
			fireballComp.target = target.gameObject;
			fireballComp.startPosition = startPosition;
			fireballComp.targetPosition = targetPosition;
			yield return wait;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("Player")&&!SR.enabled) {
			tempPlayer = coll.gameObject;
			inSpace = true;
			StartCoroutine (Shoot (coll));
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if (coll.CompareTag ("Player")&&!SR.enabled) {
			tempPlayer = null;
			inSpace = false;
		}
	}
}
