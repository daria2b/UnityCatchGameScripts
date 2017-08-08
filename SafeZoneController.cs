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

	public GameObject jumpEvolve;
	public GameObject shieldEvolve;
	public GameObject shootEvolve;

	// Use this for initialization
	void Start () {
		//Show the most recent data on the player stats
		UpdateScore ();
		UpdateCoins ();
		UpdateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowEvolvePanel () {
		statsPanel.SetActive (false);
		buttonsPanel.SetActive (false);
		evolutionPanel.SetActive (true);
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
}
