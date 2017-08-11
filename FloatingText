using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will be used to display text over player when he catches falling object or is hit by one
public class FloatingText : MonoBehaviour {
	//references to needed game objects
	public GameObject floatingCanvas;
	public Text valueText;
	public Image icon;
	
	public Image[] icons;		//icons should go in this order: [0] health, [1] shield, [2] coins, [3] points
	
	private healthHolder;
	private shieldHolder;
	private coinsHolder;
	private scoreHolder;
	
	void Start () {
		floatingCanvas.SetActive (false);
		//At start remember the initial values for the player stats that can be affected by the falling object
		healthHolder = Stats.currentHealth;
		shieldHolder = Stats.currentShield;
		coinsHolder = Stats.coins;
		scoreHolder = Stats.score;
	}
	
	void Update {
		// if any of the values has changed, change the text and icon on the floating canvas and initiate the coroutine
		if (healthHolder != Stats.currentHealth) {
			valueText = "" + Stats.currentHealth - healthHolder;
			icon.sprite = icons[0];
			StartCoroutine (Display ());
			healthHolder = Stats.currentHealth;
		}
		if (shieldHolder != Stats.currentShield) {
			valueText = "" + Stats.currentShield - shieldHolder;
			icon.sprite = icons[1];
			StartCoroutine (Display ());
			shieldHolder = Stats.currentShield;
		}
		if (coinsHolder != Stats.coins) {
			valueText = "" + Stats.coins - coinsHolder;
			icon.sprite = icons[2];
			StartCoroutine (Display ());
			coinsHolder = Stats.coins;
		} 
		if (scoreHolder != Stats.score) {
			valueText = "" + Stats.score - scoreHolder;
			icon.sprite = icons[3];
			StartCoroutine (Display ());
			scoreHolder = Stats.score;
		}
	}
	
	IEnumerator Display () {
		//Display the panel for 1 second then turn it off
		floatingCanvas.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		floatingCanvas.SetActive (false);
	}
	
}
