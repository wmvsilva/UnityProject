using UnityEngine;
using System.Collections;

public class PlayerInputScript : MonoBehaviour {

	PlayerControllerScript controllerScript;

	// Use this for initialization
	void Start () {
		controllerScript = transform.GetComponentInParent<PlayerControllerScript> ();
		if (controllerScript == null) {
			Debug.LogError("Could not load Player Controller Script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void myUpdate() {
		if (enabled) {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");

			controllerScript.getMovementScript().giveXYInput(inputX, inputY);
		}
	}
}
