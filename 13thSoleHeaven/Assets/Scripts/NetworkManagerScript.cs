using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	
	public PlayerControllerScript player;
	public LandControllerScript land;
	bool instantiateEverything = false;
	
	// Use this for initialization
	void Start () {
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
		SpawnMyPlayer();
		SpawnInitialLand ();
	}

	void SpawnInitialLand() {
		if (instantiateEverything) {
			GameObject landObject = (GameObject) PhotonNetwork.Instantiate ("Land",
			                                                          Vector3.zero,
			                                                          Quaternion.identity, 0);
			land = landObject.GetComponent<LandControllerScript>();
			land.myInitialize();
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
	}
	
	// Update is called once per frame
	void Update () {
		if (land == null) {
			attemptToSpawnLand();
		}
	}
}
