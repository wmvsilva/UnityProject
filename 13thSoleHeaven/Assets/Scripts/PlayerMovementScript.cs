using UnityEngine;
using System.Collections;
/*
 * Controls all movement for a player
 */
public class PlayerMovementScript : MonoBehaviour {

	// The speed at which a player moves
	public Vector2 speed = new Vector2(50, 50);
	// The current velocity of the player
	private Vector2 movement;
	
	// Update is called once per frame
	public void myUpdate () {

	}

	/**
	 * Given X and Y input from a keyboard, changes the velocity for a player
	 */
	public void giveXYInput(float inputX, float inputY) {
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
	}

	/*
	 * Given a player, updates the player's movement to that of this
	 */
	public void myFixedUpdate(Transform player) {
		if (isActiveAndEnabled) {
			player.rigidbody2D.velocity = movement;
		}
	}
}
