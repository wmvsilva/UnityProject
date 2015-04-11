using UnityEngine;
using System.Collections;

public class TextGUI : MonoBehaviour {

	private string textFieldString = "";

	void OnGUI ()
	{
		GUI.SetNextControlName ("CommandLine");
		Event e = Event.current;
		if (e.type == EventType.keyDown && e.keyCode == KeyCode.Return && GUI.GetNameOfFocusedControl() == "CommandLine") {
			if (!textFieldString.Equals("")) {
			sendCommand(textFieldString);
			textFieldString = "";
			}
		}
		textFieldString = GUI.TextField (new Rect (0, Screen.height - 25, Screen.width, 25), textFieldString, 25);
	}

	void sendCommand(string cmd) {
		transform.parent.FindChild ("CommandController").GetComponent<CommandScript> ().giveCommand (cmd);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
