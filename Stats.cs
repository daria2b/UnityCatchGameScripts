using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to store all global variables assigned to the player, such as health, shield, coins and points
public class Stats : MonoBehaviour {

	//Static keyword makes this variable a Member of the class, not of any particular instance.
	//Declaring the values before Start() function to make sure they stay after I load the scene again
	[HideInInspector] public static int score = 0;

	//player health & money that can also be easily accessed by other scripts
	[HideInInspector] public static float maxHealth = 50;
	[HideInInspector] public static float currentHealth = 50;

	[HideInInspector] public static int coins = 0;

	//shield is only used when the player. At the beginning of the game is set to 0 and should not be shown on the game screen
	[HideInInspector] public static float maxShield = 0;
	[HideInInspector] public static float currentShield = 0;

	//used to add more time for the next level
	[HideInInspector] public static float timeBought;


	//keep this script containing static variables when switching from one scene to another
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	}
}
