using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private float distanceToGo;
    [SerializeField] private float Speed;

    private bool moveToPoint = false;
    private Vector3 endPosition; 

	public Animator animationController;
	public bool isfacingdown;
	public bool isfacingup;
	public bool isfacingleft;
	public bool isfacingright;

	void Start () {

        // current position at beginning 
        endPosition = transform.position;
		animationController = GetComponent<Animator>();

		isfacingdown = true;
		isfacingup = false;
		isfacingleft = false;
		isfacingright = false;
		
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

			isfacingleft = true;
			isfacingright = false;
			isfacingdown = false;
			isfacingup = false;

			animationController.SetBool ("isfacingleft", true);
			animationController.Play ("WalkLeft");

		} else if (Input.GetKeyDown (KeyCode.Space) && isfacingleft == true) {
			animationController.SetBool ("isfacingleft", true);
			animationController.Play ("AttackLeft");

		} else if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
			animationController.SetBool ("isfacingleft", false);
		}

        // going right
		if (Input.GetKeyDown (KeyCode.D)) {
			endPosition = new Vector3 (endPosition.x + distanceToGo, endPosition.y, endPosition.z);
			moveToPoint = true;
			isfacingright = true;
			isfacingleft = false;
			isfacingdown = false;
			isfacingup = false;

			animationController.SetBool ("isfacingright", true);
			animationController.Play ("WalkRight");

		} else if (Input.GetKeyDown (KeyCode.Space) && isfacingright == true) {
			animationController.Play ("AttackRight");
			animationController.SetBool ("isfacingright", true);

		} else if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.A)) {
			animationController.SetBool ("isfacingright", false);
		}
			
        // going forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToGo, endPosition.z);
            moveToPoint = true;
			isfacingup = true;
			isfacingright = false;
			isfacingdown = false;
			isfacingleft = false;

			animationController.SetBool ("isfacingup", true);
			animationController.Play ("WalkUp");
		}else if (Input.GetKeyDown (KeyCode.Space) && isfacingup == true)
		{
			animationController.Play ("AttackUp");
			animationController.SetBool ("isfacingup", true);

		}else if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
			animationController.SetBool ("isfacingup", false);
		}

        //going backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToGo, endPosition.z);
            moveToPoint = true;
			isfacingdown = true;
			isfacingright = false;
			isfacingleft = false;
			isfacingup = false;

			animationController.SetBool ("isfacingdown", true);
			animationController.Play ("WalkDown");
		}else if (Input.GetKeyDown (KeyCode.Space) && isfacingdown == true)
		{
			animationController.SetBool ("isfacingdown", true);
			animationController.Play ("AttackDown");
		
		}else if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.A)) {
			animationController.SetBool ("isfacingdown", false);
		}

    }
	
	
	

}
