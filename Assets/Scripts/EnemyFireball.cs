using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	float speed = 3f;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

	

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
     
	
	}
	
	// Update is called once per frame
	void Update () {
        
        float timeInterval = Time.time - startTime;
       // gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
		gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / (distance*2));


        if (gameObject.transform.position.Equals(targetPosition)){
            if (target != null)
            {
                playerBehavior player = GameObject.Find("Player").GetComponent<playerBehavior>();
                player.Health -= 1;
                //TODO: Play player getting hurt audio
            }
            Destroy(this.gameObject);
        }

	}
	/*
	void onTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("Player")) {
			playerBehavior player = GameObject.Find("Player").GetComponent<playerBehavior>();
			player.Health--;
			Destroy(this.gameObject);

		}
	}*/


}
