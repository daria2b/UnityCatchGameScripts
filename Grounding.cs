using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounding : MonoBehaviour {

	//reference to the script attached to the player
	public PlayerController playerController;

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Collided");
		if (other.gameObject.tag == "Player") {
			playerController.onGround = true;
		}
	}
		
}
