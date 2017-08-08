using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appear : MonoBehaviour {

	//references to the elements to activate
	public GameObject titleImage;
	public GameObject startButton;

	//variable to be used to define how soon the elements will be activated
	float timeToTitle;
	float timeToStart;

	// Use this for initialization
	void Start () {
		timeToTitle = 1.0f;
		timeToStart = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToTitle > 0) {
			timeToTitle -= Time.deltaTime;
		} else if (timeToStart > 0) {
			timeToStart -= Time.deltaTime;
		}

		if (timeToTitle < 0 && timeToStart > 0) {
			titleImage.SetActive (true); 
		} else if (timeToStart < 0) {
			startButton.SetActive (true);
		}
	}
}
