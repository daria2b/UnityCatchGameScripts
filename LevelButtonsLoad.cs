using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonsLoad : MonoBehaviour {

	public Button level1;
	public Button level2;
	public Button level3;
	public Button level4;

	//When loading scene check if needed evolutions were acquired, if not disable level associated with them
	void Start () {
		level1.interactable = true;
		if (!Evolution.jump) {
			level2.interactable = false;
		} 
		if (!Evolution.speed) {
			level4.interactable = false;
		} 
		if (!Evolution.shield) {
			level3.interactable = false;
		} 
	}
	
	//Keep checking if the player has evolved to a needed evolution and enable the level button if yes
	void Update () {
		if (Evolution.jump) {
			level2.interactable = true;
		} 
		if (Evolution.speed) {
			level4.interactable = true;
		} 
		if (Evolution.shield) {
			level3.interactable = true;
		} 
	}

	//Level button passes an argument to load the correct level Scene Index
	public void GoToCatch (int index) {
		SceneManager.LoadScene (index);
	}
}

