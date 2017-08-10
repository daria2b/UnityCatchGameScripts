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
	public GameObject evolveButton;
	public GameObject catchButton;

	public Button jumpButton;
	public Button speedButton;
	public Button shieldButton;

	public Text jumpEvolve;
	public Text speedEvolve;
	public Text shieldEvolve;

	private int scoreHolder;
	private float healthHolder;

	// Use this for initialization
	void Start () {
		//line for texting to be removed
		Stats.score = 140;
		//Show the most recent data on the player stats
		UpdateScore ();
		UpdateCoins ();
		UpdateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		//if since last frame score has been updated (e.g. because of collision with falling objects), call UpdateScore function and put current scroe into the score holder for future checks
		if (scoreHolder != Stats.score) {
			UpdateScore ();
			scoreHolder = Stats.score;
		}
		//check if the health value has been changed as well
		if (healthHolder != Stats.health) {
			UpdateHealth();
			healthHolder = Stats.health;
		}
	}

	public void ShowEvolvePanel () {
		statsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		evolutionPanel.SetActive (true);
		//disable buttons and text if evolutions were already bought
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

	public void GoToCatch () {
		SceneManager.LoadScene (1);
	}

	public void BackToStats () {
		evolutionPanel.SetActive (false);
		statsPanel.SetActive (true);
		buttonsPanel.SetActive (true);
	}

	public void EvolveCharacter () {
		
	}

	//these are used to update text
	void UpdateScore () {
		pointsText.text = "Points:\n" + Stats.score;
	}

	void UpdateHealth () {
		healthText.text = "Health:\n" + Stats.health;
	}

	void UpdateCoins () {
		coinsText.text = "Coins:\n" + Stats.coins;
	}

	public GameObject errorPanel;
	public GameObject successPanel;

	public void ButtonPressedCallback (int index) {
		switch (index) {
		//index 1 = Jump Evolve, costs 20 points
		case 1:
			if (Stats.score < 20) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 20;
				Evolution.jump = true;
				StartCoroutine (ShowSuccessMessage ());
				jumpEvolve.color = Color.gray;
				jumpButton.interactable = false;
			}
			break;
			//index 2 = Speed Evolve, costs 40 points
		case 2:
			if (Stats.score < 40) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 40;
				Evolution.speed = true;
				StartCoroutine (ShowSuccessMessage ());
				speedEvolve.color = Color.gray;
				speedButton.interactable = false;
			}
			break;
			//index 3 = Shield Evolve, costs 60 points
		case 3:
			if (Stats.score < 60) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 60;
				Evolution.shield = true;
				StartCoroutine (ShowSuccessMessage ());
				shieldEvolve.color = Color.gray;
				shieldButton.interactable = false;
			}
			break;
		}
	}

	private IEnumerator ShowErrorMessage () {
		errorPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		errorPanel.SetActive (false);
	}

	private IEnumerator ShowSuccessMessage () {
		successPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		successPanel.SetActive (false);
	}
}
