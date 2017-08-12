using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZoneController : MonoBehaviour {

	//get reference to some game objects to be able to activate them later on
	public GameObject healthPanel;
	public GameObject shieldPanel;
	public GameObject coinsPanel;
	public GameObject pointsPanel;

	public GameObject buttonsPanel;
	public GameObject evolutionPanel;
	public GameObject shopPanel;
	public GameObject levelPanel;
	
	public GameObject evolveButton;
	public GameObject shopButton;

	public Button jumpButton;
	public Button speedButton;
	public Button shieldButton;

	public Text jumpEvolve;
	public Text speedEvolve;
	public Text shieldEvolve;

	public Button shopTimeButton;
	public Button shopHealthButton;
	public Button shopShieldButton;
	
	public GameObject errorPanel;
	public GameObject successPanel;

	// Use this for initialization
	void Start () {
		Stats.timeBought = 0.0f;
		if (Evolution.shield) 
			shieldPanel.SetActive (true);
	}

	// Update is called once per frame
	void Update () {

	}
	
	//Called when Evolve button is clicked. Open the panel where the player can choose an evolution to buy
	public void ShowEvolvePanel () {
		//Display only relevant buttons and images
		healthPanel.SetActive (false);
		shieldPanel.SetActive (false);
		coinsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		levelPanel.SetActive (false);
		evolutionPanel.SetActive (true);

		jumpButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 20);
		speedButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 20);
		shieldButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 20);
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

	//Called when Shop button is clicked. Open the panel where the player can buy upgrades
	public void ShowShopPanel () {
		//Display only relevant buttons and images
		healthPanel.SetActive (false);
		shieldPanel.SetActive (false);
		pointsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		levelPanel.SetActive (false);
		shopPanel.SetActive (true);

		shopTimeButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 15);
		shopHealthButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 16);
		shopShieldButton.GetComponentInChildren<Text>().text = "" + (Evolution.playerLevel * 12);
		//disable buttons and text if player has no need to buy these upgrades
		if (Stats.currentHealth == Stats.maxHealth) {
			shopHealthButton.interactable = false;
		} 
		if (Stats.currentShield == Stats.maxShield) {
			shopShieldButton.interactable = false;
		}

	}
	
	//Called when the button Back is clicked to go to the main screen
	public void BackToStats () {
		evolutionPanel.SetActive (false);
		shopPanel.SetActive (false);
		levelPanel.SetActive (true);
		healthPanel.SetActive (true);
		if (Evolution.shield) 
			shieldPanel.SetActive (true);
		coinsPanel.SetActive (true);
		pointsPanel.SetActive (true);
		buttonsPanel.SetActive (true);
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
			Evolution.playerLevel +=1;		//Player level increases after each evolution bought
			Stats.maxHealth += 5; 			//Maximum health increases by 5 after each evolution
			switch (index) {
				case 1:
					Evolution.jump = true;
					jumpEvolve.color = Color.gray;
					jumpButton.interactable = false;
					break;
				case 2: 
					Evolution.speed = true;
					speedEvolve.color = Color.gray;
					speedButton.interactable = false;
					break;
				case 3:
					Evolution.shield = true;
					shieldEvolve.color = Color.gray;
					shieldButton.interactable = false;
					break;
			}	
		}
	}

	//This is called on the Shop screen when player buys upgrades
	//Checks if player has enough coins to spend
	//If yes, various stats are changed
	public void ShopButtonPressed (int index) {
		//check if the player has enough points to spend depending on his current level
		switch (index) {
		case 1:		//stands for time
			if (Stats.coins < (Evolution.playerLevel * 15)) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				//executes more time to buy
				Stats.coins -= (Evolution.playerLevel * 15);
				Stats.timeBought += 10.0f;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
		case 2: //stands for health
			if (Stats.coins < (Evolution.playerLevel * 16)) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				//executes more time to buy
				Stats.coins -= (Evolution.playerLevel * 16);
				Stats.currentHealth = Stats.maxHealth;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
		case 3:	//stands for shield
			if (Stats.coins < (Evolution.playerLevel * 12)) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				//executes more time to buy
				Stats.coins -= (Evolution.playerLevel * 12);
				Stats.currentShield = Stats.maxShield;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
					
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
