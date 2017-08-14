using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will hold information on what is the highest score the player has acieved on each level and in total
public class HighestScoreScript : MonoBehaviour {
	
	//The script will use static variable to be accessible from multiple scenes
	//These values should not be changed through the inspector
	//Each level will update the relevant value
	[HideInInspector] public int highScoreValley = 0;
	[HideInInspector] public int highScoreSands = 0;
	[HideInInspector] public int highScoreRocks = 0;
	[HideInInspector] public int highScoreForest = 0;
	
	//these references will be used to update text with high scores in the Hub
	public Text valleyHighScore;
	public Text sandsHighScore;
	public Text rocksHighScore;
	public forestHighScore;

	//keep this script containing static variables when switching from one scene to another
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
