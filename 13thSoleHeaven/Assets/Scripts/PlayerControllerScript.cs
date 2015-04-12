using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	PlayerMovementScript movementScript;

	// Use this for initialization
	void Start () {
		movementScript = transform.FindChild ("MovementController").GetComponent<PlayerMovementScript> ();
		if (movementScript == null) {
			Debug.LogError("Could not load Player Movement Script");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		movementScript.myUpdate ();
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movementScript.myFixedUpdate ();
	}
}
