using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	PlayerMovementScript movementScript;
	PlayerInputScript inputScript;

	// Use this for initialization
	void Awake () {
		movementScript = transform.FindChild ("MovementController").GetComponent<PlayerMovementScript> ();
		if (movementScript == null) {
			Debug.LogError("Could not load Player Movement Script");
		}
		inputScript = transform.FindChild ("InputController").GetComponent<PlayerInputScript> ();
		if (inputScript == null) {
			Debug.LogError("Could not load Player Input Script");
		}
	}

	public PlayerMovementScript getMovementScript() {
		return movementScript;
	}

	public void enableInput() {
		Debug.Log ("Enabling player movement");
		if (movementScript == null) {
			Debug.Log ("Movement script not initialized");
		}
		inputScript.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		inputScript.myUpdate ();
		movementScript.myUpdate ();
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movementScript.myFixedUpdate ();
	}
}
