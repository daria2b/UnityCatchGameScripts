using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script exists to update relevant text in various scenes in order to avoid duplicating the code in other controller scripts
public class UpdateText : MonoBehaviour {
	
	//this will store needed text fields in variables and will be used to get a reference to the text to display
	public Text scoreText;
	public Text healthText;
	public Text coinsText;
	public Text shieldText;

	//prefabs of text
	public Text floatingText;
	//Text healthFloating;
	//Text coinsFloating;
	//Text shieldFloating;

	//these will be used to check when to update the text on the screen
	private int scoreHolder;
	private float healthHolder;
	private int coinsHolder;
	private float shieldHolder;
	
	// Initiate private variables by accessible the static values under Stats.cs and update the text as needed
	void Start () {
		scoreHolder = Stats.score;
		shieldHolder = Stats.currentShield;
		healthHolder = Stats.currentHealth;
		coinsHolder = Stats.coins;


		//call update functions at the start of the level
		UpdateScore ();
		UpdateHealth ();
		UpdateCoins ();
		UpdateShield ();
	}
	
	//Update text on fields that have been changed since last Update was called
	void Update () {
		if (scoreHolder != Stats.score) {
			UpdateScore ();
			DisplayStatsChange (scoreText, "+", (Stats.score - scoreHolder));
			scoreHolder = Stats.score;
		}
		//check if the other values has been changed as well
		if (healthHolder != Stats.currentHealth) {
			UpdateHealth();
			DisplayStatsChange (healthText, "", (int)(Stats.currentHealth - healthHolder));
			healthHolder = Stats.currentHealth;
		}
		if (coinsHolder != Stats.coins) {
			UpdateCoins();
			DisplayStatsChange (coinsText, "+", (Stats.coins - coinsHolder));
			coinsHolder = Stats.coins;
		}
		if (shieldHolder != Stats.currentShield) {
			UpdateShield();
			DisplayStatsChange (shieldText, "", (int)(Stats.currentShield - shieldHolder));
			shieldHolder = Stats.currentShield;
		}
	}
	
	//All functions that are used to update various text fields
	void UpdateScore () {
		scoreText.text = "" + Stats.score;
	}

	void UpdateHealth () {
		healthText.text = "" + Stats.currentHealth + "/" + Stats.maxHealth;
	}

	void UpdateCoins () {
		coinsText.text = "" + Stats.coins;
	}

	void UpdateShield () {
		shieldText.text = "" + Stats.currentShield + "/" + Stats.maxShield;
	}

	void DisplayStatsChange (Text position, string sign, int stats) {
		Text floating = Instantiate (floatingText, position.transform.position, Quaternion.identity);
		floating.transform.SetParent (position.transform);
		floating.text = "" + sign + stats;
		if (stats < 0) 
			floating.color = Color.red;
	}
	
}
