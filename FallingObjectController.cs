using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour {

	//how many points this falling object gives the player, can be adjusted in the Inspector
	//default value given by the falling object is 0
	public int pointsValue = 0; 
	public int coinsValue = 0;
	public float damageValue = 0f;

	//reference to the script attached to the player
	//public Score scoreScript;

	//new Static variable to hold current score
	//private static int currentScore;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//currentScore = Score.score;
	}

	//Recalculate the player score according to the value assigned to this falling object
	//Then destroy self on contact with other colliders (to be carried over from the destroyer colliders)
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//increment the score
			Stats.score += pointsValue;
			Stats.health -= damageValue;
			Stats.coins += coinsValue;
		} 
		Destroy (gameObject);
	}
}
