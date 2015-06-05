using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	PlayerMovementScript movementScript;
	PlayerInputScript inputScript;
	NetworkControllerScript networkScript;
	VisionControllerScript visionScript;
	PlayerEnvironmentController environmentScript;
	PlayerHealthScript healthScript;
	PlayerManagerScript managerScript;

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
		networkScript = transform.FindChild ("NetworkController").GetComponent<NetworkControllerScript> ();
		if (inputScript == null) {
			Debug.LogError("Could not load Network Controller Script");
		}
		visionScript = transform.FindChild ("VisionController").GetComponent<VisionControllerScript> ();
		if (visionScript == null) {
			Debug.LogError("Could not load Vision Controller Script");
		}
		environmentScript = transform.FindChild ("EnvironmentController").GetComponent<PlayerEnvironmentController> ();
		if (environmentScript == null) {
			Debug.LogError("Could not load Player Environment Controller Script");
		}
		healthScript = transform.FindChild ("HealthController").GetComponent<PlayerHealthScript> ();
		if (healthScript == null) {
			Debug.LogError("Could not load Player Health Script");
		}
	}

	public PlayerMovementScript getMovementScript() {
		return movementScript;
	}

	public void enableInput() {
		Debug.Log ("Enabling player input");
		if (inputScript == null) {
			Debug.Log ("Input script not initialized");
		}
		inputScript.enabled = true;
	}

	public void enableMovement() {
		Debug.Log ("Enabling player movement");
		if (movementScript == null) {
			Debug.Log ("Movement script not initialized");
		}
		movementScript.enabled = true;
	}

	public void enableCamera() {
		Debug.Log ("Enabling camera");
		if (visionScript == null) {
			Debug.Log ("Vision script not initialized");
		}
		visionScript.enableCamera ();
	}

	[RPC]
	public void addToPlayerManager() {
		Debug.Log ("Adding player to player manager");
		PlayerManagerScript manager = PlayerManagerScript.FindObjectOfType<PlayerManagerScript> ();
		if (manager == null) {
			Debug.LogError("Could not find the player manager.");
			return;
		}
		manager.addPlayerToList (this);
		managerScript = manager;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		networkScript.myOnPhotonSerializeView (stream, info);
	}
	
	// Update is called once per frame
	void Update () {
		inputScript.myUpdate ();
		movementScript.myUpdate ();
		networkScript.myUpdate ();
	}

	void FixedUpdate() {
		movementScript.myFixedUpdate (transform);
	}
}
