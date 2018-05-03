using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	float speed = 3f;
    public GameObject target;
    public Vector2 startPosition;
    public Vector2 targetPosition;

    private float distance;
    private float startTime;

	

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
     
	
	}
	
	// Update is called once per frame
	void Update () {
        
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition)){
            if (target != null)
            {
                playerBehavior player = GameObject.Find("Player").GetComponent<playerBehavior>();
                player.Health -= 1;
                //TODO: Play player getting hurt audio
            }
            Destroy(gameObject);
        }

	}


	void OnTriggerEnter2D (Collider2D col){
		
		//if enemy bullet hits object, it is destroyed
		if (col.gameObject.tag == "object") {
			Debug.Log ("Hit surface!");
			Destroy (gameObject);
		}
	}
}
