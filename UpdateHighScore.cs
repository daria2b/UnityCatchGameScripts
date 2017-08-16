using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will be updating the high score script from Safe Zone on each level
public class UpdateHighScore : MonoBehaviour {
	
	//Used to store current player score in the level 
	private int startingScore;
	private int endingScore;
	//Used to pass level index from the inspector (easy to change for each level)
	//Currently: 1 = Valley, 2 = Sands, 3 = Rocks, 4 = Forest
	public int levelIndex;
	//get access to another script on the same game object
	GameController gameController;
	//reference to the prefab to instantiate
	public Text newHighScore;
	//boolean to check if a message was created already or not
	private bool isCreated;
	
	void Start () {
		//set strting score to the global score to be able to recalculate new high score at the end of the level
		startingScore = Stats.score;
		gameController = gameObject.GetComponent<GameController>();
		isCreated = false;
	}
	
	void Update () {
		//recalculate score as soon as level has finished (this is fired by GameController when time runs out)
		if (gameController.endLevel) {
			//calculate score the player acquired after starting the level by substracting the starting score from current global score
			endingScore = Stats.score - startingScore;
			//depending on what level the player is in now, update the correct high score
			switch (levelIndex) {
			case 1:
				if (endingScore > HighScoreScript.highScoreValley)
				{
					Congratulate ();
					HighScoreScript.highScoreValley = endingScore;
				}
				break;
			case 2:
				if (endingScore > HighScoreScript.highScoreSands)
				{
					Congratulate ();
					HighScoreScript.highScoreSands = endingScore;
				}
				break;
			case 3:
				if (endingScore > HighScoreScript.highScoreRocks)
				{
					Congratulate ();
					HighScoreScript.highScoreRocks = endingScore;
				}
				break;
			case 4:
				if (endingScore > HighScoreScript.highScoreForest)
				{
					Congratulate ();
					HighScoreScript.highScoreForest = endingScore;
				}
				break;
			}
		}
		
	}

	//used to display a message that a new high score has been achieved by the player
	//text prefab needs to be child of a Canvas game object to be visible on screen
	void Congratulate () { 
		if (!isCreated) {
			// find canvas
			GameObject canvas = GameObject.Find ("MessagesCanvas");
			// clone the prefab 
			Text congrats = Instantiate (newHighScore, new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity);
			// set canvas as parent to the text
			congrats.transform.SetParent (canvas.transform);
			isCreated = true;
		}
	}
	
}
