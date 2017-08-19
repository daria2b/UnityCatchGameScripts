using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	//boolean to check if a message has been created
	private bool isCreated;
	//reference to the prefab to instantiate
	public Image gameOverPanel;

	// Use this for initialization
	void Start () {
		isCreated = false;
	}

	//used to display a message that a new high score has been achieved by the player
	//text prefab needs to be child of a Canvas game object to be visible on screen
	public void GameOver () { 
		if (!isCreated) {
			// find canvas
			GameObject canvas = GameObject.Find ("MessagesCanvas");
			// clone the prefab 
			Image gameOver = Instantiate (gameOverPanel, new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity);
			// set canvas as parent to the text
			gameOver.transform.SetParent (canvas.transform);
			gameOver.GetComponent<Image> ().CrossFadeAlpha (1.0f, 1.0f, false);
			isCreated = true;
		}
	}
}
