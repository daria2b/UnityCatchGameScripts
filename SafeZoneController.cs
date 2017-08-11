using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SafeZoneController : MonoBehaviour {

	//get reference to some game objects to be able to activate them later on
	public GameObject statsPanel;
	public GameObject buttonsPanel;
	public GameObject evolutionPanel;
	public Text pointsText;
	public Text healthText;
	public Text coinsText;
	public Text shieldText;
	public GameObject evolveButton;
	public GameObject catchButton;

	public Button jumpButton;
	public Button speedButton;
	public Button shieldButton;

	public Text jumpEvolve;
	public Text speedEvolve;
	public Text shieldEvolve;
	
	public GameObject errorPanel;
	public GameObject successPanel;

	private int scoreHolder;
	private float healthHolder;

	// Use this for initialization
	void Start () {
		//Show the most recent data on the player stats
		UpdateScore ();
		UpdateCoins ();
		UpdateHealth ();
		UpdateShield ();
	}

	// Update is called once per frame
	void Update () {
		//If since last frame score has been updated (e.g. because of collision with falling objects), call UpdateScore function and put current score into the score holder for future checks
		if (scoreHolder != Stats.score) {
			UpdateScore ();
			scoreHolder = Stats.score;
		}
		//Check if the health value has been changed as well
		if (healthHolder != Stats.health) {
			UpdateHealth();
			healthHolder = Stats.health;
		}
	}
	
	//Called when Evolve button is clicked. Open the panel where the player can choose an evolution to buy
	public void ShowEvolvePanel () {
		
		statsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		evolutionPanel.SetActive (true);
		//disable buttons and text if evolutions were already bought 
		//Plan to remove the button altogether and update the title with a green checkbox to show that evolution was bought already
		if (Evolution.jump) {
			jumpEvolve.color = Color.gray;
			jumpButton.interactable = false;
		} 
		if (Evolution.speed) {
			speedEvolve.color = Color.gray;
			speedButton.interactable = false;
		}
		if (Evolution.shield) {
			shieldEvolve.color = Color.gray;
			shieldButton.interactable = false;
		}
	}
	
	//Called when the Play button is clicked and loads a level 
	public void GoToCatch () {
		SceneManager.LoadScene (1);
	}
	
	//Called when the button Back is clicked to go to the main screen
	public void BackToStats () {
		evolutionPanel.SetActive (false);
		statsPanel.SetActive (true);
		buttonsPanel.SetActive (true);
	}

	//These are used to update text. Need to think of a way to take these functions out and use them in different scripts
	void UpdateScore () {
		pointsText.text = "" + Stats.score;
	}

	void UpdateHealth () {
		healthText.text = "" + Stats.health;
	}

	void UpdateCoins () {
		coinsText.text = "" + Stats.coins;
	}

	void UpdateShield () {
		shieldText.text = "" + Stats.shield;
	}
	
	//This is called by the button that sends integer to identify what evolution has been chosen by player
	//Checks if player has enough points to spend on the evolution
	//If yes, set this evolution to true
	public void ButtonPressedCallback (int index) {
		//check if the player has enough points to spend depending on his current level
		if (Stats.score < (Evolution.playerLevel * 20)) {
			StartCoroutine (ShowErrorMessage ());
		} else {
			//this part identifies what evolution has been chose, but it will need to be changed to a distionary instead
			Stats.score -= (Evolution.playerLevel * 20);
			StartCoroutine (ShowSuccessMessage ());
			switch (index) {
				case 1:
					Evolution.jump = true;
					jumpEvolve.color = Color.gray;
					jumpButton.interactable = false;
					break;
				case 2: 
					Evolution.speed = true;
					break;
				case 3:
					Evolution.shield = true;
					break;
			}	
		}
	}
	
	//Called if the player did not have enough points to evolve. Shows error message
	private IEnumerator ShowErrorMessage () {
		if (successPanel.activeSelf) 
			successPanel.SetActive (false);
		errorPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		errorPanel.SetActive (false);
	}
	
	//Called if the player had enough points to evolve. Shows success message
	private IEnumerator ShowSuccessMessage () {
		if (errorPanel.activeSelf) 
			errorPanel.SetActive (false);
		successPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		successPanel.SetActive (false);
	}
}
