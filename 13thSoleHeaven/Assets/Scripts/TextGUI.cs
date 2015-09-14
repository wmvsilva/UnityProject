using UnityEngine;
using System.Collections;
/*
 * GUI for the text-entry field that is present at the bottom of the screen
 */
public class TextGUI : MonoBehaviour {

	// The current contents of the text-entry field
	private string textFieldString = "";

	/*
	 * OnGUI- Creates a GUI which the user can enter text into and press enter to send commands to the game
	 */
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

	/**
	 * sendCoammnd- Sends a command to the specified command controller
	 */
	void sendCommand(string cmd) {
		transform.parent.FindChild ("CommandController").GetComponent<CommandScript> ().giveCommand (cmd);
	}
}
