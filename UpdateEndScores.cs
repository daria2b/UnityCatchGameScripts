using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEndScores : MonoBehaviour {

	//this reference will be used to update text with high scores in the Hub
	public Text cloudValleyScore;
	public Text sandPlainsScore;
	public Text fallingRocksScore;
	public Text darkForestScore;

	void Start () {
		UpdateScoreValue (cloudValleyScore, HighScoreScript.highScoreValley.ToString ()); 
		//only show score if jump evolution was bought, then same for other evolutions
		if (Evolution.jump) 
			UpdateScoreValue (sandPlainsScore, HighScoreScript.highScoreSands.ToString ());
		else
			UpdateScoreValue (sandPlainsScore, "Locked");

		if (Evolution.speed) 
			UpdateScoreValue (fallingRocksScore, HighScoreScript.highScoreRocks.ToString ());
		else 
			UpdateScoreValue (fallingRocksScore, "Locked");

		if (Evolution.shield) 
			UpdateScoreValue (darkForestScore, HighScoreScript.highScoreForest.ToString ());
		else
			UpdateScoreValue (darkForestScore, "Locked");
	}

	//function to find all text objects under Scor Panel and update them by using the provided path and score
	void UpdateScoreValue (Text stringToUpdate, string text) {
		stringToUpdate.text = text;
	}
}
