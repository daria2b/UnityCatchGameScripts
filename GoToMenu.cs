using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {

	public void StartGameAnew () {
		//reset all static value to their initial values to start the game anew
		Evolution.playerLevel = 1;
		Evolution.jump = false;
		Evolution.speed = false;
		Evolution.shield = false;

		HighScoreScript.highScoreValley = 0;
		HighScoreScript.highScoreSands = 0;
		HighScoreScript.highScoreRocks = 0;
		HighScoreScript.highScoreForest = 0;

		Stats.score = 0;
		Stats.maxHealth = 50;
		Stats.currentHealth = 50;
		Stats.coins = 0;
		Stats.maxShield = 0;
		Stats.currentShield = 0;

		Stats.timeBought = 0;

		SceneManager.LoadScene (0);
	}
}
