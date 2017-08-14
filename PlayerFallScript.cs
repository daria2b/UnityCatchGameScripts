using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script controlling what happens if player falls in the hole in the ground
public class PlayerFallScript : MonoBehaviour {

	public GameObject fallPanel;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//Player takes damage when falls into the hole
			//If shield is still available, health is not affected, only shield is removed
			if (Stats.currentShield > 0)
				Stats.currentShield = 0;
			//If shield was not available, player takes damage equal to 50% of his health
			else 
				Stats.currentHealth *= 0.5f;

			fallPanel.SetActive (true);
		}
	}
}
