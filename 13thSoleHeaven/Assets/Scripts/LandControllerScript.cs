using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Controls all environment square units in the game. Currently, its only job is the initialization of
 * these units
 */
public class LandControllerScript : MonoBehaviour {

	// The number of land units there are horizontally to be initialized
	public int width = 2;
	// The number of land units there are vertically to be initialized
	public int height = 2;
	// The length of each environment square in Unity units
	int squareLength = 1;

	/**
	 * myInitialize- initializes all environment squares and gives them some units of oxygen.
	 */
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
}
