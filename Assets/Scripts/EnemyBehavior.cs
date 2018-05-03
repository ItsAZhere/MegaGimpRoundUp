using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public List<GameObject> playerInRange;
	[SerializeField]
	GameObject fireball;

	//for shooting fireballs
	float fireRate;
	float nextFire;



	
	void Start () {

		fireRate = 4f;
		nextFire = Time.time;	
	}


	
	
	void Update () {
        
        GameObject target = null;
        foreach (GameObject player in playerInRange){
            target = player;

        }

        if (target!= null){
            if (Time.time - nextFire > fireRate){
                Shoot(target.GetComponent< Collider2D>());
                nextFire = Time.time;
            }
        }
	}



	//If player enter's enemy's range, add player to imp's range
    void OnTriggerEnter2D (Collider2D col){
	
        if (col.gameObject.tag.Equals("Player")){
            playerInRange.Add(col.gameObject);
			
		}
	}

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player")){
            playerInRange.Remove((col.gameObject));
        }
    }

    void Shoot(Collider2D target){

        GameObject fireballPrefab = fireball;

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = fireballPrefab.transform.position.z;
        targetPosition.z = fireballPrefab.transform.position.z;

        GameObject newFireball = (GameObject)Instantiate(fireball);
        newFireball.transform.position = startPosition;
        EnemyFireball fireballComp = newFireball.GetComponent<EnemyFireball>();
        fireballComp.target = target.gameObject;
        fireballComp.startPosition = startPosition;
        fireballComp.targetPosition = targetPosition;

        //TODO: Add enemy fireball shooting audio 
        //TODO: add shooting animation 
    }

	
	

}
