using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * PlayerManagerScript
 * Manages all clients' players on the network
 */ 
public class PlayerManagerScript : MonoBehaviour {

	// List of all players currently on the server
	public List<PlayerControllerScript> players;

	/**
	 * Adds a player to the list of players currently in the Photon room
	 */
	public void addPlayerToList(PlayerControllerScript player) {
		Debug.Log ("ADDING PLAYER");
		players.Add (player);
	}

	/*
	 * Gets a player in the manager list by their name
	 */
	public PlayerControllerScript getPlayer(string name) {
		foreach (PlayerControllerScript p in players) {
			if (p.playerName.Equals(name)) {
				return p;
			}
		}
		Debug.LogError ("Could not find player named: " + name);
		throw new UnityException ();
	}

	/*
	 * Returns the number of players currently in the player manager list
	 */
	public string numPlayers() {
		return players.Count.ToString();
	}

	/*
	 * Returns a string listing out all players currently in the player manager list
	 */
	public string listNames() {
		string names = "";
		foreach (PlayerControllerScript p in players) {
			names = names + p.playerName + ", ";
		}
		return names;
	}
}
