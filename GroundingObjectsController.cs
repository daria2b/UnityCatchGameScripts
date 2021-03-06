﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingObjectsController : MonoBehaviour {

	//how many points this falling object gives the player, can be adjusted in the Inspector
	//default value given by the falling object is 0
	public int pointsValue = 0; 
	public int coinsValue = 0;
	public float damageValue = 0f;		//damage value will be applied to the shield first, then to health

	Animator myAnimation;

	void Start () {
		myAnimation = GetComponent<Animator> ();
	}

	//Recalculate the player score according to the value assigned to this falling object
	//Then destroy self on contact with other colliders (to be carried over from the destroyer colliders)
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {

			//increment the score
			Stats.score += pointsValue;
			Stats.coins += coinsValue;
			//first apply damage to the shield, then to health
			if (Stats.currentShield > damageValue) {
				Stats.currentShield -= damageValue;
			} else {
				//calculate the damage difference between what was absorbed by the shield
				float damageHolder = damageValue - Stats.currentShield;
				Stats.currentShield = 0;
				Stats.currentHealth -= damageHolder;
			}
			//Destroy object on contact with player
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Edge") {
			//If the object fell on the ground, change the animation to the ground animation and keep the object before destrying for 2 seconds
			myAnimation.SetBool ("onGround", true);	
			Destroy (gameObject, 3.0f);
		} 
	}
}
