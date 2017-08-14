using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be updating the high score script from Safe Zone on each level
public class UpdateHighScore : MonoBehaviour {
	
	//Used to store current player score in the level 
	private int currentScore;
	//Used to pass level index from the inspector (easy to change for each level)
	//Currently: 1 = Valley, 2 = Sands, 3 = Rocks, 4 = Forest
	public int levelIndex;
	//get access to another script on the same game object
	GameController gameController;
	
	void Start () {
		//set strting score to the global score to be able to recalculate new high score at the end of the level
		currentScore = Stats.score;
		gameController = gameObject.GetComponent<GameController>();
	}
	
	void Update () {
		//recalculate score as soon as level has finished (this is fired by GameController when time runs out)
		if (gameController.endLevel) {
			//calculate score the player acquired after starting the level by substracting the starting score from current global score
			currentScore = Stats.score - currentScore;
			//depending on what level the player is in now, update the correct high score
			switch (levelIndex) {
			case 1:
				if (currentScore > HighScoreScript.highScoreValley)
				{
					Congratulate ();
					HighScoreScript.highScoreValley = currentScore;
				}
				break;
			case 2:
				if (currentScore > HighScoreScript.highScoreSands)
				{
					Congratulate ();
					HighScoreScript.highScoreSands = currentScore;
				}
				break;
			case 3:
				if (currentScore > HighScoreScript.highScoreRocks)
				{
					Congratulate ();
					HighScoreScript.highScoreRocks = currentScore;
				}
				break;
			case 4:
				if (currentScore > HighScoreScript.highScoreForest)
				{
					Congratulate ();
					HighScoreScript.highScoreForest = currentScore;
				}
				break;
			}
		}
		
	}
	
	//used to display a message that a new high score has been achieved by the player
	//text prefab needs to be child of a Canvas game object to be visible on screen
	void Congratulate () {
		 // find canvas
		GameObject canvas = GameObject.Find("MessagesCanvas");
		// clone the prefab 
		GameObject congrats = Instantiate(newHighScore, new Vector3 (x, y, 0), Quaternion.identity);
		// set canvas as parent to the text
		congrats.transform.SetParent(canvas.transform);
	}
	
}
