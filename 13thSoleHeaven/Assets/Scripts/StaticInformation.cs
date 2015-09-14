using UnityEngine;
using System.Collections;
/*
 * Information provided by the player at the main menu to remain until the next scene (Main game)
 * where it is used to configure the game
 */
public class StaticInformation : MonoBehaviour {

	// The name of the player in-game
	public string playerName;

	// Setter method for player name
	public void setPlayerName(string name) {
		playerName = name;
	}
}
