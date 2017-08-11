using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	//this will store the text in a variable and will be used to get a reference to the text to display
	public Text scoreText;
	public Text healthText;
	public Text coinsText;
	public Text shieldText;

	//this will be used to store the player's score
	//Static keyword makes this variable a Member of the class, not of any particular instance.
	//Declaring the values before Start() function to make sure they stay after I load the scene again
	[HideInInspector] public static int score = 0;
	//this variable is used to determine whether a score update needs to be called
	private int scoreHolder;

	//player health & money that can also be easily accessed by other scripts
	[HideInInspector] public static float health = 50;
	private float healthHolder;
	[HideInInspector] public static int coins = 0;
	private float coinsHolder;
	//shield is only used when the player. At the beginning of the game is set to 0 and should not be shown on the game screen
	[HideInInspector] public static float shield = 0;
	private float shieldHolder;

	//keep this script containing static variables when switching from one scene to another
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		//at the start the score is 0
		scoreHolder = score;
		healthHolder = health;
		if (Evolution.shield) {
			Stats.shield = 20;
		}
		//display text with points and health (health has not yet been implemented in game
		UpdateScore();
		UpdateHealth ();
		UpdateCoins ();
		UpdateShield ();
	}

	void Update () {
		//if since last frame score has been updated (e.g. because of collision with falling objects), call UpdateScore function and put current scroe into the score holder for future checks
		if (scoreHolder != score) {
			UpdateScore ();
			scoreHolder = score;
		}
		//check if the other values has been changed as well
		if (healthHolder != health) {
			UpdateHealth();
			healthHolder = health;
		}
		if (coinsHolder != coins) {
			UpdateCoins();
			coinsHolder = coins;
		}
		if (shieldHolder != shield) {
			UpdateShield();
			shieldHolder = shield;
		}
	}

	//this is used to update the score text
	void UpdateScore () {
		scoreText.text = "" + score;
	}

	void UpdateHealth () {
		healthText.text = "" + health;
	}

	void UpdateCoins () {
		coinsText.text = "" + coins;
	}

	void UpdateShield () {
		shieldText.text = "" + shield;
	}
		
}
