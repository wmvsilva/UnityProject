using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandScript : MonoBehaviour {

	PlayerManagerScript playerManager;

	public void giveCommand(string cmd) {
		string[] cmdArray = cmd.Split (' ');
		string command = cmdArray[0];
		List<string> arguments = new List<string> ();
		for (int i = 1; i < cmdArray.Length; i++) {
			arguments.Add(cmdArray[i]);
		}
		switch (command) {
		case ("echo"):
			echo(arguments);
			break;
		case ("OOC"):
			ooc(arguments);
			break;
		case ("numPlayers"):
			transform.parent.FindChild("ChatWindow").GetComponent<ChatWindowScript>().addPlayerMessage(playerManager.numPlayers());
			break;
		default:
			commandNotFound(command);
			break;
		}
	}

	void ooc(List<string> args) {
		transform.parent.FindChild ("ChatWindow").GetComponent<PhotonView> ()
			.RPC ("addMessage", PhotonTargets.All, args [0]);
	}

	void echo(List<string> args) {
		string stringArgs = "";
		foreach (string s in args) {
			stringArgs = stringArgs + s + " ";
		}
		Debug.Log (stringArgs);
	}

	void commandNotFound(string command) {
		Debug.Log ("Error- " + command + " command not found");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPlayerManager(PlayerManagerScript m) {
		Debug.Log ("Setting player manager for GUI");
		playerManager = m;
		if (playerManager == null) {
			Debug.LogError("Player Manager for GUI was not set");
		}
	}
}
