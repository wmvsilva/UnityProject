using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManagerScript : MonoBehaviour {

	public List<PlayerControllerScript> players;

	public void addPlayerToList(PlayerControllerScript player) {
		Debug.Log ("ADDING PLAYER");
		players.Add (player);
	}

	public PlayerControllerScript getPlayer(string name) {
		foreach (PlayerControllerScript p in players) {
			if (p.playerName.Equals(name)) {
				return p;
			}
		}
		Debug.LogError ("Could not find player named: " + name);
		throw new UnityException ();
	}

	public string numPlayers() {
		return players.Count.ToString();
	}

	public string listNames() {
		string names = "";
		foreach (PlayerControllerScript p in players) {
			names = names + p.playerName + ", ";
		}
		return names;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
