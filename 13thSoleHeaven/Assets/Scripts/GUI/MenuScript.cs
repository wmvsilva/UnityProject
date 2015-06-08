using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	string firstName = "";
	string lastName = "";

	public GameObject staticObj;

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
