using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will hold information on what level the player is at and what evolutions were bought already
public class Evolution : MonoBehaviour {
	
	//this variable is not used yet, but is created for future use
	public static int playerLevel = 1;
	
	//booleans to be used to determine what evolutions and powers the player has
	public static bool jump = true;
	public static bool speed = false;
	public static bool shield = false;

	//keep this script containing static variables when switching from one scene to another
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
