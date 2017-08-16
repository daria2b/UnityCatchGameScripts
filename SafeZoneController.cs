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

	public Button jumpButton;
	public Button speedButton;
	public Button shieldButton;

	public Button shopTimeButton;
	public Button shopHealthButton;
	public Button shopShieldButton;
	
	public GameObject messagePanel;
	
	//base costs that are recalculated depending on various aspects
	private int evolutionCost = 26;
	private int timeCost = 64;
	private int timePrice;

	//this reference will be used to update text with high scores in the Hub
	public GameObject scorePanel;

	// Use this for initialization
	void Start () {
		Stats.timeBought = 0.0f;
		if (Evolution.shield) 
			shieldPanel.SetActive (true);
		timePrice = timeCost + timeCost * ((int) Stats.timeBought / 10);
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

		//will correctly update the text on the buttons depending on which evolutions were bought
		if (Evolution.jump) {
			jumpButton.interactable = false;
			UpdatePrice (jumpButton, "Evolved!");
		} else {
			UpdatePrice (jumpButton, (Evolution.playerLevel * evolutionCost).ToString());
		}
		if (Evolution.speed) {
			speedButton.interactable = false;
			UpdatePrice (speedButton, "Evolved!");
		} else {
			UpdatePrice (speedButton, (Evolution.playerLevel * evolutionCost).ToString());
		}
		if (Evolution.shield) {
			shieldButton.interactable = false;
			UpdatePrice (shieldButton, "Evolved!");
		} else {
			UpdatePrice (shieldButton, (Evolution.playerLevel * evolutionCost).ToString());
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

		UpdatePrice (shopTimeButton, timePrice.ToString());
		UpdatePrice (shopHealthButton, (Evolution.playerLevel * 16).ToString());
		UpdatePrice (shopShieldButton, (Evolution.playerLevel * 12).ToString());
	
		//disable buttons and text if player has no need to buy these upgrades
		if (Stats.currentHealth == Stats.maxHealth) {
			shopHealthButton.interactable = false;
		} 
		if (Stats.currentShield == Stats.maxShield) {
			shopShieldButton.interactable = false;
		}

	}

	public void ShowScorePanel () {
		//Display only relevant buttons and images
		healthPanel.SetActive (false);
		shieldPanel.SetActive (false);
		pointsPanel.SetActive (false);
		coinsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		levelPanel.SetActive (false);
		scorePanel.SetActive (true);

		//find text components under the panel and update the high score value
		UpdateScoreValue ("VertLayoutPanel/Level1Panel/Image/Level1Score", HighScoreScript.highScoreValley);
		UpdateScoreValue ("VertLayoutPanel/Level2Panel/Image/Level2Score", HighScoreScript.highScoreSands);
		UpdateScoreValue ("VertLayoutPanel/Level3Panel/Image/Level3Score", HighScoreScript.highScoreRocks);
		UpdateScoreValue ("VertLayoutPanel/Level4Panel/Image/Level4Score", HighScoreScript.highScoreForest);

	}

	//function to find all text objects under Scor Panel and update them by using the provided path and score
	void UpdateScoreValue (string path, int score) {
		Transform levelScore = scorePanel.transform.Find (path);
		Text scoreText = levelScore.GetComponent<Text> ();
		scoreText.text = score.ToString();
	}
	
	//Called when the button Back is clicked to go to the main screen
	public void BackToStats () {
		evolutionPanel.SetActive (false);
		shopPanel.SetActive (false);
		scorePanel.SetActive (false);
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
	public void EvolveButtonPressed (int index) {
		//check if the player has enough points to spend depending on his current level
		if (Stats.score < (Evolution.playerLevel * evolutionCost)) {
			StartCoroutine (ShowMessage ("You don't have enough points to evolve"));
		} else {
			//this part identifies what evolution has been chosen, but it will need to be changed to a distionary instead
			Stats.score -= (Evolution.playerLevel * evolutionCost);
			StartCoroutine (ShowMessage ("You've acquired new evolution!"));
			Evolution.playerLevel +=1;			//Player level increases after each evolution bought
			if (Stats.currentHealth == Stats.maxHealth) {		//Maximum health increases by 5 after each evolution
				Stats.maxHealth += 5; 			//Current health is updated depending on what it was before the evolution
				Stats.currentHealth = Stats.maxHealth;
			} else {
				Stats.maxHealth += 5;
				Stats.currentHealth += 5;
			}
						
			
			switch (index) {
			case 1:
				Evolution.jump = true;
				jumpButton.interactable = false;
				UpdatePrice (jumpButton, "Evolved!");	
				if (!Evolution.speed)
					UpdatePrice (speedButton, (Evolution.playerLevel * evolutionCost).ToString());
				if (!Evolution.shield)
					UpdatePrice (shieldButton, (Evolution.playerLevel * evolutionCost).ToString());
				break;
			case 2: 
				Evolution.speed = true;
				speedButton.interactable = false;
				UpdatePrice (speedButton, "Evolved!");	
				if (!Evolution.jump)
					UpdatePrice (jumpButton, (Evolution.playerLevel * evolutionCost).ToString());
				if (!Evolution.shield)
					UpdatePrice (shieldButton, (Evolution.playerLevel * evolutionCost).ToString());
				break;
			case 3:
				Evolution.shield = true;
				Stats.maxShield = 20;
				Stats.currentShield = 20;
				shieldButton.interactable = false;
				UpdatePrice (shieldButton, "Evolved!");	
				if (!Evolution.jump)
					UpdatePrice (jumpButton, (Evolution.playerLevel * evolutionCost).ToString());
				if (!Evolution.speed)
					UpdatePrice (speedButton, (Evolution.playerLevel * evolutionCost).ToString());
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
			if (Stats.coins < timePrice) {
				StartCoroutine (ShowMessage ("You don't have enough coins"));
			} else {
				//remove coins depending on the price
				Stats.coins -= timePrice;
				//add more time to the player
				Stats.timeBought += 10.0f;
				//recalculate new time price
				timePrice = timeCost + timeCost * ((int) Stats.timeBought / 10);
				//show new price on the button
				UpdatePrice (shopTimeButton, timePrice.ToString());
				//Show success message
				StartCoroutine (ShowMessage ("You bought 10 more seconds for the rest of the game"));
			}
			break;
		case 2: //stands for health
			if (Stats.coins < (Evolution.playerLevel * 16)) {
				StartCoroutine (ShowMessage ("You don't have enough coins"));
			} else {
				//executes more time to buy
				Stats.coins -= (Evolution.playerLevel * 16);
				Stats.currentHealth = Stats.maxHealth;
				StartCoroutine (ShowMessage ("You restored your health"));
			}
			break;
		case 3:	//stands for shield
			if (Stats.coins < (Evolution.playerLevel * 12)) {
				StartCoroutine (ShowMessage ("You don't have enough coins"));
			} else {
				//executes more time to buy
				Stats.coins -= (Evolution.playerLevel * 12);
				Stats.currentShield = Stats.maxShield;
				StartCoroutine (ShowMessage ("You restored your shield"));
			}
			break;
					
		}
	}
	
	//function used to update text on any button whenever price changed
	void UpdatePrice (Button button, string newText) {
		button.GetComponentInChildren<Text>().text = newText;
	}
	
	//Called to show a message
	private IEnumerator ShowMessage (string message) {
		messagePanel.SetActive (true);
		messagePanel.GetComponentInChildren<Text>().text = message;
		yield return new WaitForSeconds (2.0f);
		messagePanel.SetActive (false);
	}
}
