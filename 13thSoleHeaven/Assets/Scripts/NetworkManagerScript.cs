using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	
	public PlayerControllerScript player;
	
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
	}
	
	void OnJoinedRoom() {
		Debug.Log("OnJoinedRoom");
		SpawnMyPlayer();
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
