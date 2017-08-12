using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Camera cam;
	//prefab to be used for drops
	public GameObject[] drops;
	//variable for tracking time
	public float timeLeft;
	//reference to the timer text to update it
	public Text timerText;
	//get reference to some game objects to be able to activate them later on
	public GameObject timesUpText;
	public GameObject endLevelPanel;
	
	//will hold the title of the area and the countdown till the beginning of the actual game
	public Text gameStartText;

	//will be used to control the timer
	private bool playing;

	//reference to the script attached to the player
	public PlayerController playerController;


	//will be used to calculate the spawn position
	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null)
			cam = Camera.main;
		playing = false;
		//send new boolean value to the ToggleController under PlayerController script to enable player controls when Start button is clicked
		//playerController.ToggleControl (true);


		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float dropWidth = drops[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - dropWidth;
		//set up 30 seconds for the game to play
		timeLeft = 30.0f + Stats.timeBought;
		StartCoroutine (Spawn ());
		CountTime ();


	}

	void FixedUpdate () {
		if (playing) {
			//every time we get FixedUpdate remove from timeLeft the deltaTime since the last time the FixedUpdate was called
			//we use fixed update to have same amount of time passing in between the update function being called
			timeLeft -= Time.deltaTime;
			//to avoid showing negative time
			if (timeLeft < 0)
				timeLeft = 0;
			//don't have to convert it to a string, it converts automatically. Mathf will round the timeLeft float to an int to show how many seconds are left to play
			CountTime ();
		}
	}

	void CountTime () {
		timerText.text = "Time left:\n" + Mathf.RoundToInt (timeLeft);
	}

	public void GoToTheHub () {
		SceneManager.LoadScene (2);
	}

	IEnumerator Spawn () {
		//Display the level name and count down to start the game
		gameStartText.text = "Sun Valley";
		yield return new WaitForSeconds (1.0f);
		gameStartText.text = "3";
		yield return new WaitForSeconds (1.0f);
		gameStartText.text = "2";
		yield return new WaitForSeconds (1.0f);
		gameStartText.text = "1";
		yield return new WaitForSeconds (1.0f);
		gameStartText.text = "Go!";
		yield return new WaitForSeconds (1.0f);
		gameStartText.text = "";
		
		//once all preliminary processes completed, the timer and the game can start
		playing = true;
		while (timeLeft > 0) {
			//get a random object to spawn from the array of objects
			GameObject drop = drops[Random.Range (0, drops.Length)];

			Vector3 spawnPosition = new Vector3 (
				                        Random.Range (-maxWidth, maxWidth),
				                        transform.position.y,
				                        0.0f	
			                        );
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (drop, spawnPosition, spawnRotation);
			//if the infinite loop has no condition, the game will generate objects each frame and will crach as it won't be able to render anything else
			//yield command asks to wait for a period between 1 to 2 seconds in this case
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}

		//if game time is 0, turn on game over text and then show restart button
		yield return new WaitForSeconds(2.0f);
		timesUpText.SetActive (true);
		yield return new WaitForSeconds(2.0f);
		endLevelPanel.SetActive (true);
	}

}
