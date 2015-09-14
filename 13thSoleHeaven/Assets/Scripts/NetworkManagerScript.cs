using UnityEngine;
using System.Collections;
/**
 * Manages connecting to the photon network and the first instantiations of objects like the player and environment
 */
public class NetworkManagerScript : MonoBehaviour {

	// The current player that is instantiated.
	public PlayerControllerScript player;
	// The land controller that is to be instantiated at some point.
	public LandControllerScript land;
	// The player manager which the new instantiated player is given to.
	public PlayerManagerScript players;
	// Unless you are the creator of the server, do not instantiate everything
	bool instantiateEverything = false;
	// Static Information entered from the main menu which is used for connection and player configuration
	StaticInformation menuInformation;
	
	/**
	 * Start- For instantiation, grabs the static information which should have been entered from the main menu
	 * and then proceeds to connect to a Photon server.
	 */
	void Start () {
		menuInformation = GameObject.Find ("StaticInformation").GetComponent<StaticInformation> ();
		Debug.Log ("The player name is: " + menuInformation.playerName);
		Connect();
	}

	/**
	 * Connect to some Photon server. Create one if none exists and instantiate all needed objects for the server.
	 */
	void Connect() {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	/**
	 * OnGUI- Unity method for displaying GUI elements
	 * Displays the current connection status for connecting to Photon.
	 */
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	/**
	 * OnJoinedLobby- On connection to a Photon lobby, join a random room in that lobby
	 */
	void OnJoinedLobby() {
		Debug.Log("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}

	/**
	 * OnPhotonRandomJoinFailed- if a Photon room is not found in the lobby, create one
	 * and then set this client to instantiate everything
	 */
	void OnPhotonRandomJoinFailed() {
		Debug.Log("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null);
		instantiateEverything = true;
	}

	/**
	 * OnJoinedRoom- Upon joining a room, instantiate everything if this client created the room
	 */
	void OnJoinedRoom() {
		Debug.Log("OnJoinedRoom");
		SpawnInitialManager ();
		SpawnMyPlayer();
		SpawnInitialLand ();
	}

	/**
	 * SpawnInitialLand- If this player created the room, spawn the initial environment square units
	 */
	void SpawnInitialLand() {
		if (instantiateEverything) {
			Debug.Log("Initial land spawn.");
			GameObject landObject = (GameObject) PhotonNetwork.Instantiate ("Land",
			                                                          Vector3.zero,
			                                                          Quaternion.identity, 0);
			land = landObject.GetComponent<LandControllerScript>();
			land.myInitialize();
			//Set squares as children of Land
			EnvironmentControllerScript[] envs = EnvironmentControllerScript.FindObjectsOfType<EnvironmentControllerScript>();
			if (envs.GetLength(0) == 0) {
				Debug.Log("Found no environment controller scripts.");
			}
			foreach (EnvironmentControllerScript env in envs) {
				env.changeParentTo(land.transform);
			}
		}
	}

	/**
	 * giveGUIManager- Give the Command script the player manager that this Network Manager has.
	 */
	void giveGUIManager() {
		GameObject.Find ("GUI").GetComponentInChildren<CommandScript> ().setPlayerManager (players);
	}

	/**
	 * SpawnInitialManager- Spawns the initial player manager. From this point on, future joining players
	 * are given this Manager.
	 */
	void SpawnInitialManager() {
		if (instantiateEverything) {
			Debug.Log("Initial manager spawn.");
			GameObject managerObject = (GameObject) PhotonNetwork.Instantiate ("PlayerManager",
			                                                                Vector3.zero,
			                                                                Quaternion.identity, 0);
			if (managerObject == null) {
				Debug.LogError("Could not load manager object");
			}
		}
	}

	void attemptToSpawnLand() {
		land = LandControllerScript.FindObjectOfType<LandControllerScript> ();
		if (land == null) {
			return;
		}
		Debug.Log ("Initializing land.");
		
		EnvironmentControllerScript[] envs = EnvironmentControllerScript.FindObjectsOfType<EnvironmentControllerScript>();
		if (envs.GetLength(0) == 0) {
			Debug.Log("Found no environment controller scripts.");
		}
		foreach (EnvironmentControllerScript env in envs) {
			env.changeParentTo(land.transform);
		}
		Debug.Log ("Land initialized.");
	}
	
	void SpawnMyPlayer() {
		Debug.Log("SpawnMyPlayer");
		GameObject myPlayer = (GameObject) PhotonNetwork.Instantiate ("Player",
		                                                              Vector3.zero,
		                                                              Quaternion.identity, 0);
		player = myPlayer.GetComponent<PlayerControllerScript> ();
		if (myPlayer == null) {
			Debug.Log("myPlayer not found");
			return;
		}
		player.enableInput ();
		player.enableMovement ();
		player.enableCamera ();
		myPlayer.GetComponent<PhotonView> ().RPC ("setPlayerName", PhotonTargets.AllBuffered, menuInformation.playerName);
	}
	
	/**
	 * Update- called once per frame. If the land has not been initialized yet, attempt to initialize it ourselves once it is
	 * Photon instantiated.
	 * If the player manager has not been added to the Network Manger yet, attempt to find it and add this client's player to it.
	 */
	void Update () {
		if (land == null) {
			attemptToSpawnLand();
		}
		if (players == null && PlayerManagerScript.FindObjectOfType<PlayerManagerScript> () != null) {
			players = PlayerManagerScript.FindObjectOfType<PlayerManagerScript> ();
			giveGUIManager();
			player.transform.gameObject.GetComponent<PhotonView> ().RPC ("addToPlayerManager", PhotonTargets.AllBuffered, new string[]{});
		}
	}
}
