using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	
	public PlayerControllerScript player;
	public LandControllerScript land;
	public PlayerManagerScript players;
	bool instantiateEverything = false;
	StaticInformation menuInformation;
	
	// Use this for initialization
	void Start () {
		menuInformation = GameObject.Find ("StaticInformation").GetComponent<StaticInformation> ();
		Debug.Log ("The player name is: " + menuInformation.playerName);
		Connect();
	}
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby() {
		Debug.Log("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null);
		instantiateEverything = true;
	}
	
	void OnJoinedRoom() {
		Debug.Log("OnJoinedRoom");
		SpawnInitialManager ();
		SpawnMyPlayer();
		SpawnInitialLand ();
	}

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

	void giveGUIManager() {
		GameObject.Find ("GUI").GetComponentInChildren<CommandScript> ().setPlayerManager (players);
	}

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
	
	// Update is called once per frame
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
