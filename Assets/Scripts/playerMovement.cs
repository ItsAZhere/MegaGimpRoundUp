using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private float distanceToGo;
    [SerializeField] private float Speed;

    private bool moveToPoint = false;
    private Vector3 endPosition;


	void Start () {

        // current position at beginning 
        endPosition = transform.position;
		
	}


    void Update(){

        // going left
        if (Input.GetKey(KeyCode.A)){
            endPosition = new Vector3(endPosition.x - distanceToGo, endPosition.y, endPosition.z);
        }

        // going right
        if (Input.GetKey(KeyCode.D))
        {
            endPosition = new Vector3(endPosition.x + distanceToGo, endPosition.y, endPosition.z);
        }

        // going forward
        if (Input.GetKey(KeyCode.W))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToGo, endPosition.z);
        }

        //going backward
        if (Input.GetKey(KeyCode.S))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToGo, endPosition.z);
        }

    }
	
	
	void FixedUpdate () {

        // "snap" player position to new position
        if (moveToPoint == true){
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Speed * Time.deltaTime);
        }
	}

}
