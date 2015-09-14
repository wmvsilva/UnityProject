using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Script to determine what occurs based on a given command. Using commands, the player can speak
 * or find out out-of-character information.
 */
public class CommandScript : MonoBehaviour {

	// Cached player manager object for easy access by the commands.
	PlayerManagerScript playerManager;

	/**
	 * Sets the player manager for this.
	 * This object should be set before any commands are given. Otherwise,
	 * null pointer exceptions may occur.
	 */
	public void setPlayerManager(PlayerManagerScript m) {
		Debug.Log ("Setting player manager for GUI");
		playerManager = m;
		if (playerManager == null) {
			Debug.LogError("Player Manager for GUI was not set");
		}
	}

	/**
	 * giveCommand- given a command, performs some operation such as sending out a text message
	 * to players or displaying information to a player.
	 */
	public void giveCommand(string cmd) {
		// Step 1- Parse the command.
		string[] cmdArray = cmd.Split (' ');
		string command = cmdArray[0];
		List<string> arguments = new List<string> ();
		for (int i = 1; i < cmdArray.Length; i++) {
			arguments.Add(cmdArray[i]);
		}

		// Step 2- Send the command args to the proper method.
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
		case ("listNames"):
			listNames();
			break;
		case ("health"):
			health(arguments);
			break;
		default:
			commandNotFound(command);
			break;
		}
	}

	/**
	 * health- given the name of a player, displays the current oxygen saturation of that player to
	 * all players in the chat window.
	 */
	void health(List<string> args) {
		string name = "";
		foreach (string s in args) {
			name = name + s + " ";
		}
		name = name.Substring (0, name.Length - 1);
		PlayerControllerScript thePlayer = playerManager.getPlayer (name);
		transform.parent.FindChild ("ChatWindow").GetComponent<PhotonView> ()
			.RPC ("addMessage", PhotonTargets.All, thePlayer.getHealthScript ().oxygenSaturation.ToString());
	}

	/**
	 * listNames- lists all players currently on the server.
	 */
	void listNames() {
		string names = playerManager.listNames ();
		transform.parent.FindChild ("ChatWindow").GetComponent<PhotonView> ()
			.RPC ("addMessage", PhotonTargets.All, names);
	}

	/**
	 * Displays the first argument to the chat window for all players.
	 */
	void ooc(List<string> args) {
		transform.parent.FindChild ("ChatWindow").GetComponent<PhotonView> ()
			.RPC ("addMessage", PhotonTargets.All, args [0]);
	}

	/**
	 * echo- simply echos the given arguments as a debug log to the player.
	 */
	void echo(List<string> args) {
		string stringArgs = "";
		foreach (string s in args) {
			stringArgs = stringArgs + s + " ";
		}
		Debug.Log (stringArgs);
	}

	/**
	 * commandNotFound- should be run when a unrecognized command has been given.
	 * Prints an error message to the log.
	 */
	void commandNotFound(string command) {
		Debug.Log ("Error- " + command + " command not found");
	}
}
