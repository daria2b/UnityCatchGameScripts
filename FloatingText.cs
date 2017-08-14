using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will be used to display text over player when he catches falling object or is hit by one
public class FloatingText : MonoBehaviour {

	public Text popupText;
	public Image popupIcon;
	SpriteRenderer spriteRenderer;
	
//	private float healthHolder;
//	private float shieldHolder;
//	private int coinsHolder;
//	private int scoreHolder;
	
	void Start () {
		spriteRenderer = popupIcon.GetComponent<SpriteRenderer> ();
		//pass in the amount of time it wait before destroying the object
		Destroy (gameObject, 1.3f);

		//At start remember the initial values for the player stats that can be affected by the falling object
//		healthHolder = Stats.currentHealth;
//		shieldHolder = Stats.currentShield;
//		coinsHolder = Stats.coins;
//		scoreHolder = Stats.score;
	}
	
//	void Update () {
//		// if any of the values has changed, change the text and icon on the floating canvas and initiate the coroutine
//		if (healthHolder != Stats.currentHealth) {
//			valueText.text = "" + (Stats.currentHealth - healthHolder);
//			popupIcon.sprite = icons[0];
//		
//			healthHolder = Stats.currentHealth;
//		}
//		if (shieldHolder != Stats.currentShield) {
//			valueText.text = "" + (Stats.currentShield - shieldHolder);
//			popupIcon.sprite = icons[1];
//
//			shieldHolder = Stats.currentShield;
//		}
//		if (coinsHolder != Stats.coins) {
//			valueText.text = "" + (Stats.coins - coinsHolder);
//			popupIcon.sprite = icons[2];
//
//			coinsHolder = Stats.coins;
//		} 
//		if (scoreHolder != Stats.score) {
//			valueText.text = "" + (Stats.score - scoreHolder);
//			popupIcon.sprite = icons[3];
//
//			scoreHolder = Stats.score;
//		}
//	}

	public void SetTextIcon (string text, Sprite icon) {
		popupText.text = text;

		spriteRenderer.sprite = icon;
	}
	
}
