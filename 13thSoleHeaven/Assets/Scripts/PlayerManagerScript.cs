using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManagerScript : MonoBehaviour {

	public List<PlayerControllerScript> players;

	public void addPlayerToList(PlayerControllerScript player) {
		Debug.Log ("ADDING PLAYER");
		players.Add (player);
	}

	public string numPlayers() {
		return players.Count.ToString();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
