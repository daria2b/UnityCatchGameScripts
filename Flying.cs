using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

	//this will be the force applied to the object to move it right or left
	public float thrust = 3.0f;
	//reference to objects rigid body
	Rigidbody2D myRB;
	//variable used to control movement
	bool movingRight;
	float timeCount;

	void Start() {
		//get reference of the rigidbody component attached to the object
		myRB = GetComponent<Rigidbody2D>();
		//set initial values of variables 
		movingRight = true;
		//timeCount is set to 0.8 as we want the object to move right away as it starts falling without having to wait for 0.4-0.8 seconds
		timeCount = 0.8f;
	}

	void FixedUpdate () {
		//add to timeCount since last frame - it is used to apply movement to the object at different times
		timeCount += Time.deltaTime;
		//check if it was more than 0.4 - 0.8 seconds since the object last moved right of left
		if (timeCount > Random.Range (0.4f, 0.8f)) {
			//if object is about to be moved to the right
			if (movingRight) {
				//use velocity to move the object to the right 
				myRB.velocity = new Vector2 (-1 * thrust, myRB.velocity.y);
				//reverse movingRight value to the opposite, so that next move was in a different direction
				movingRight = !movingRight;
				//set timeCount to 0 so that in next frame we start counting it again (to avoid the movement being too fast, we'll wait for another 0.4 - 0.8 seconds)
				timeCount = 0;
			} else {
				myRB.velocity = new Vector2 (thrust, myRB.velocity.y);
				movingRight = !movingRight;
				timeCount = 0;
			}
		}

	}


}
