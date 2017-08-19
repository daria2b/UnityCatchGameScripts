using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script needs to communicate with GameController script as the controls need to be turned off when the game hasn't started yet
public class PlayerController : MonoBehaviour {

	public float maxSpeed = 8f;
	public float jumpForce = 200f;

	//references to different components of this game object
	Rigidbody2D myRB;
	Animator myAnimation; 
	//boolean variables will be used to control player rotation and what side it faces
	bool facingRight;
	bool facingUp;

	//boolean to check if we can control the player (the game started or not)
	private bool canControl;

	//death effects used on player death
	public GameObject deathFX;
	[HideInInspector] public bool isDead;

	//boolean used for jumping calculations
	[HideInInspector] public bool onGround;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnimation = GetComponent<Animator> ();	
		facingRight = true;
		canControl = true;
		onGround = false;
		isDead = false;
		//startPosition = transform.position;
		//as soon as the player evolved to jump
		if (Evolution.speed) {
			maxSpeed = 12f;
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Edge") {
			onGround = true;
		}
	}

	void Update () {
		if (Stats.currentHealth <= 0) {
			MakeDead ();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//only allow controlling the character if the game started
		if (canControl) {
			//get input from player on horizontal axis (A or D keyboard buttons or Left or Right keyboard buttons)
			float move = Input.GetAxis ("Horizontal");
			//interract with the animator if buttom was pressed, so movement speed is not 0
			myAnimation.SetFloat ("speed", Mathf.Abs (move));	

			//move the player by using velocity (not physics)
			myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

			//flip the character if it faces the wrong direction
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();

			//reset rotation to 0 if not moving so that the idle jump animation is displayed correctly
			if (move == 0) {
				transform.rotation = Quaternion.identity;
			}	

			if (Evolution.jump && Input.GetAxis ("Jump") > 0 && onGround) {
				myRB.AddForce (transform.up * jumpForce);
				onGround = false;
			}
		}
	}

	
	//flip sprite to the side the player is facing
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

	public void MakeDead () {
		canControl = false;
		myAnimation.SetBool ("isDead", true);
		Invoke ("LaunchDeathFX", 1.0f);
	}

	public void LaunchDeathFX () {
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
		isDead = true;
	}
		
}
