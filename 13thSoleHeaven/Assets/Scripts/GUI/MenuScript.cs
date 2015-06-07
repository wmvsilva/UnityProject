using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	string textFieldString = "";

	public GameObject staticObj;

	void OnGUI(){
		GUI.SetNextControlName ("CommandLine");
		Event e = Event.current;
		if (e.type == EventType.keyDown && e.keyCode == KeyCode.Return && GUI.GetNameOfFocusedControl () == "CommandLine") {
			if (!textFieldString.Equals ("")) {
				staticObj.GetComponent<StaticInformation>().setPlayerName(textFieldString);
				GameObject.DontDestroyOnLoad(staticObj);
				Application.LoadLevel(1);
			}
		}
		textFieldString = GUI.TextField (new Rect(Screen.width / 2, Screen.height / 2, 75, 25) , textFieldString, 25);
	}
}
