using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandControllerScript : MonoBehaviour {

	public int width = 2;
	public int height = 2;
	int squareLength = 1;

	// Use this for initialization
	public void myInitialize () {
		Debug.Log ("Initializing environment");
		int widthToTrack = 0;
		int heightToTrack = 0;
		for (int i = 0; i < width * height; i++) {
			int x = widthToTrack * squareLength;
			int y = heightToTrack * squareLength;
			GameObject oneSquare = (GameObject)PhotonNetwork.Instantiate ("EnvironmentSquare",
		                                                              new Vector3(x, y),
		                                                              Quaternion.identity, 0);
			EnvironmentControllerScript conSquare = oneSquare.GetComponent<EnvironmentControllerScript>();
			conSquare.changeZoneNum(i);
			//Add oxygen to the square
			conSquare.addGas(new OxygenScript(1,1));

			if (conSquare == null) {
				Debug.Log("Environment controller script was null for a square");
			}
			widthToTrack++;
			if (widthToTrack >= width) {
				widthToTrack = 0;
				heightToTrack++;
			}
		}
		Debug.Log ("Environment initialized.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
