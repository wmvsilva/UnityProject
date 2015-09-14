using UnityEngine;
using System.Collections;
/**
 * Script to control all GUI buttons that the player will use to interact with the game.
 */
public class GameGUIScript : MonoBehaviour {

	/**
	 * Swaps the currently selected hand from left to right or vice versa. 
	 */
	public void swapHands() {
		// TODO Implement swapping logic. The player should have some enumeration describing whether
		// they are currently using their left or right hand. When the player clicks on items, they will
		// interact with the currently selected hand.
		Debug.Log ("Swapped hands");
	}
}
