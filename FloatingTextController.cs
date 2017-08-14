using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour {

	private static FloatingText popupText;
	//this will be used for setting correct location
	private static GameObject canvas;

	//Since we can't use a prefab throught the inspector in this case, we're creating our won initialization method
	//This method will be responsible to getting a reference to an object or pther parameters we need to set up
	public static void Initialize () {

		canvas = GameObject.Find ("PopupCanvas");
		//it's going to get this prefab and it's going to return the type for us as FloatingText
		//we have a reference to it, but we'll have to initialize it
		if (!popupText)		//if reference is null, create a reference 
			popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent"); 

	}

	public static void CreateFloatingText (string text, Sprite icon, Transform location) {
		//instance gives a reference to the created object. After that we can access files and components from this reference
		FloatingText instance = Instantiate (popupText);
		instance.transform.SetParent (canvas.transform, false);
		instance.SetTextIcon (text, icon);
	}
}
