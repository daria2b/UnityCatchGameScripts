using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		//this was working before I added the Enemy type objects here and before I added a gameobject array in Gamecontroller
		if (other.gameObject.tag == "Drops" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Fly")
			Destroy (other.gameObject);
	}
		
}
