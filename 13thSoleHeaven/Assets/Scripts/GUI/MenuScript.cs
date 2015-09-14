using UnityEngine;
using System.Collections;
/**
 * The main menu that the player is initially presented with.
 */
public class MenuScript : MonoBehaviour {

	// The player's first name to be entered.
	string firstName = "";
	// The player's last name to be entered.
	string lastName = "";

	// Game object which holds the Static Information component which is passed on to the next scene.
	public GameObject staticObj;

	/**
	 * OnGUI- Produces text field for the first name, last name. Also provides a button for loading the next
	 * scene
	 */
	void OnGUI(){
		GUI.SetNextControlName ("Main");
		if (GUI.Button (new Rect(Screen.width / 2, Screen.height / 2 + 60, 75, 25), "Start")) { 
			staticObj.GetComponent<StaticInformation>().setPlayerName(firstName + " " + lastName);
			GameObject.DontDestroyOnLoad(staticObj);
			Application.LoadLevel(1);
		}
		firstName = GUI.TextField (new Rect(Screen.width / 2, Screen.height / 2, 75, 25) , firstName, 25);
		lastName = GUI.TextField (new Rect(Screen.width / 2, Screen.height / 2 + 30, 75, 25) , lastName, 25);
	}
}
