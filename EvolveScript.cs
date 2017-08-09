using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveScript : MonoBehaviour {

	public GameObject errorPanel;
	public GameObject successPanel;

	public void ButtonPressedCallback (int index) {
		switch (index) {
		//index 1 = Jump Evolve, costs 20 points
		case 1:
			if (Stats.score < 20) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 20;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
		//index 2 = Speed Evolve, costs 40 points
		case 2:
			if (Stats.score < 40) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 40;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
		//index 3 = Shield Evolve, costs 60 points
		case 3:
			if (Stats.score < 60) {
				StartCoroutine (ShowErrorMessage ());
			} else {
				Stats.score -= 60;
				StartCoroutine (ShowSuccessMessage ());
			}
			break;
		}
	}

	private IEnumerator ShowErrorMessage () {
		errorPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		errorPanel.SetActive (false);
	}

	private IEnumerator ShowSuccessMessage () {
		successPanel.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		successPanel.SetActive (false);
	}
}
