using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	float moveSpeed = 3f;

	private Rigidbody2D rb;

	playerBehavior target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		//so bullets find player
		target = GameObject.FindObjectOfType<playerBehavior> ();
		//so bullets move
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		//bullet speed
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		//bullet is destroyed after time
		Destroy (gameObject, 3f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col){
		//if enemy bullet hits player, it is destroyed
		if (col.gameObject.name == "Player") {
			Debug.Log ("Enemy fireball has Hit!");
			Destroy (gameObject);
		}
		//if enemy bullet hits object, it is destroyed
		if (col.gameObject.tag == "object") {
			Debug.Log ("Hit surface!");
			Destroy (gameObject);
		}
	}
}
