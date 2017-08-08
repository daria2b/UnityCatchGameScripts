using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script needs to communicate with GameController script as the controls need to be turned off when the game hasn't started yet
public class PlayerController : MonoBehaviour {

	public float maxSpeed = 5f;
	// public float rotationSpeed = 0.1f;	// Rotation is not being used here, the CircleCollider makes the object rotate
	//references to different components of this game object
	Rigidbody2D myRB;
	Animator myAnimation; 
	//boolean variables will be used to control player rotation and what side it faces
	bool facingRight;
	bool facingUp;

	//boolean to check if we can control the player (the game started or not)
	private bool canControl;

	//to hold start position of the player
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnimation = GetComponent<Animator> ();	
		facingRight = true;
		canControl = true;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//only allow controlling the character if the game started
		if (canControl) {
			//get input from player on horizontal axis (A or D keyboard buttons or Left or Right keyboard buttons)
			float move = Input.GetAxis ("Horizontal");
			//interract with the animator if buttom was pressed, so movement speed is not 0
			myAnimation.SetFloat ("speed", Mathf.Abs (move));	

			//if (move != 0)	// Rotation is not being used in this case, the CircleCollider makes the object rotate
			//	transform.Rotate (Vector3.forward * move * rotationSpeed);

			//move the player by using velocity (not physics)
			myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

			//flip the character if it faces the wrong direction
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();

			//reset rotation to 0 if not moving so that the idle jump animation was displayed correctly
			if (move == 0) {
				transform.rotation = Quaternion.identity;
			}
		} 
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//toggle player controls 
	public void ToggleControl (bool toggle) {
		canControl = toggle;
	}
		
}
