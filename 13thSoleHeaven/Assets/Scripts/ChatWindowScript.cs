using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatWindowScript : MonoBehaviour {

	private float hScrollbarValue;

	public Vector2 scrollPosition = Vector2.zero;
	private Queue<string> messages = new Queue<string>();

	void OnGUI ()
	{
		GUI.SetNextControlName ("ChatWindow");


		scrollPosition = GUI.BeginScrollView (new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height - 25), 
		                                      scrollPosition, 
		                                      new Rect (0, 0, Screen.width / 2 - 25, Screen.height - 25), false, true);
		string displayMessage = "";
		foreach (string m in messages) {
			displayMessage = displayMessage + m + "\n";
		}
		GUI.TextArea (new Rect (0, 0, Screen.width / 2, Screen.height), displayMessage);
		GUI.skin.textArea.wordWrap = true;
		GUI.skin.settings.cursorFlashSpeed = 0;
		GUI.skin.settings.cursorColor = new Color (0, 0, 0, 0);
		GUI.EndScrollView ();

	}

	public void addMessage(string msg) {
		messages.Enqueue (msg);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
