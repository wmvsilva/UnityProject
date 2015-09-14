using UnityEngine;
using System.Collections;
/*
 * Controls all keyboard input provided by the human player
 */
public class PlayerInputScript : MonoBehaviour {

	// Cached reference to the player controller script
	PlayerControllerScript controllerScript;

	/*
	 * Start- Unity uses this for initialization
	 * Attempts to cache the player controller script associated with this player
	 */
	void Start () {
		controllerScript = transform.GetComponentInParent<PlayerControllerScript> ();
		if (controllerScript == null) {
			Debug.LogError("Could not load Player Controller Script");
		}
	}

	/*
	 * myUpdate- if enabled, grabs the keyboard input and sends it to the player movement
	 * controller
	 */
	public void myUpdate() {
		if (enabled) {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");

			controllerScript.getMovementScript().giveXYInput(inputX, inputY);
		}
	}
}
