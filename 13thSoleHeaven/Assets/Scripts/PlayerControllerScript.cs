using UnityEngine;
using System.Collections;
/*
 * Controls all aspects of a player included movement, input, vision, health, and all interaction
 */
public class PlayerControllerScript : MonoBehaviour {

	// A string containing the player's first and last name.
	public string playerName;

	// Player movement controller
	PlayerMovementScript movementScript;
	// Input controller which determines how to take in keyboard input
	PlayerInputScript inputScript;
	// Network controller to sync player movement
	NetworkControllerScript networkScript;
	// Vision controller to determine what the player sees and does not see
	VisionControllerScript visionScript;
	// Environment controller to determine how the player's environment effects them.
	PlayerEnvironmentController environmentScript;
	// Controls the health of the game player
	PlayerHealthScript healthScript;
	// Manager for all players currently in the Photon room
	PlayerManagerScript managerScript;

	// Getter method for player health script
	public PlayerHealthScript getHealthScript() {
		return healthScript;
	}

	// Getter method for player movement script
	public PlayerMovementScript getMovementScript() {
		return movementScript;
	}

	/*
	 * Remote Procedure Call for setting a player's name across all machines.
	 */
	[RPC]
	public void setPlayerName(string name) {
		Debug.Log ("Setting name to: " + name);
		playerName = name;
	}

	/**
	 * Awake- Used by Unity for initialization
	 * Finds all component children that this player has and caches them
	 */
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

	/**
	 * Enables keyboard input for this player
	 */
	public void enableInput() {
		Debug.Log ("Enabling player input");
		if (inputScript == null) {
			Debug.Log ("Input script not initialized");
		}
		inputScript.enabled = true;
	}

	/**
	 * enableMovement- Enables this player to move
	 */
	public void enableMovement() {
		Debug.Log ("Enabling player movement");
		if (movementScript == null) {
			Debug.Log ("Movement script not initialized");
		}
		movementScript.enabled = true;
	}

	/*
	 * enableCamera- Enables the Unity camera for this one player
	 */
	public void enableCamera() {
		Debug.Log ("Enabling camera");
		if (visionScript == null) {
			Debug.Log ("Vision script not initialized");
		}
		visionScript.enableCamera ();
	}

	/*
	 * RPC for adding this player to every player's player manager.
	 */
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

	/**
	 * OnPhotonSerializeView- syncs player movement across all clients
	 */
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		networkScript.myOnPhotonSerializeView (stream, info);
	}
	
	/**
	 * Updates the input, movement, and network.
	 */
	void Update () {
		inputScript.myUpdate ();
		movementScript.myUpdate ();
		networkScript.myUpdate ();
	}

	/*
	 * FixedUpdate- updates the coordinates of this player on a fixed update schedule
	 */
	void FixedUpdate() {
		movementScript.myFixedUpdate (transform);
	}
}
