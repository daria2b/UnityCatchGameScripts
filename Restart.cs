using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	//reference to the script attached to the player
	public PlayerController playerController;

	//this function has to be public
	public void RestartGame () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		//send new boolean value to the ToggleController under PlayerController script to enable player controls when Start button is clicked
		playerController.ToggleControl (true);
	}
}
