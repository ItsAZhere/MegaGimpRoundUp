using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private float distanceToGo;
    [SerializeField] private float Speed;

    private bool moveToPoint = false;
    private Vector3 endPosition; 

	public Animator animationController;

	void Start () {

        // current position at beginning 
        endPosition = transform.position;
		
	}


    void FixedUpdate()

    {

        // "snap" player position to new position
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Speed * Time.deltaTime);
        }

    }



    void Update(){


        // going left
		if (Input.GetKeyDown (KeyCode.A)) {
			endPosition = new Vector3 (endPosition.x - distanceToGo, endPosition.y, endPosition.z);
			moveToPoint = true;
			animationController.Play ("WalkLeft");
		} else if (Input.GetKeyDown (KeyCode.Space))
			{
			animationController.Play ("AttackLeft");
			}

        // going right
        if (Input.GetKeyDown(KeyCode.D))
        {
            endPosition = new Vector3(endPosition.x + distanceToGo, endPosition.y, endPosition.z);
            moveToPoint = true;
			animationController.Play ("WalkRight");
		}else if (Input.GetKeyDown (KeyCode.Space))
		{
			animationController.Play ("AttackRight");
		}


        // going forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToGo, endPosition.z);
            moveToPoint = true;
			animationController.Play ("WalkUp");
		}else if (Input.GetKeyDown (KeyCode.Space))
		{
			animationController.Play ("AttackUp");
		}

        //going backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToGo, endPosition.z);
            moveToPoint = true;
			animationController.Play ("WalkDown");
		}else if (Input.GetKeyDown (KeyCode.Space))
		{
			animationController.Play ("AttackDown");

		}

    }
	
	
	

}
