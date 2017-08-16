using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appear : MonoBehaviour {

	//references to the elements to activate
	public GameObject titleImage;
	public GameObject buttonsPanel;
	public GameObject helpPanel;

	//variable to be used to define how soon the elements will be activated
	float startTime = 0f;
	float timeToAppear = 1.0f;

	// Use this for initialization
	void Start () {
		helpPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		startTime += Time.deltaTime;
		if (startTime > (timeToAppear * 2)) {
			buttonsPanel.SetActive (true);
		} else if (startTime > timeToAppear) {
			titleImage.SetActive (true);
		}
			
	}

	public void OpenHelpPanel () {
		helpPanel.SetActive (true);
	}

	public void CloseHelpPanel () {
		helpPanel.SetActive (false);
	}
}
