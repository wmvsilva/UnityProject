using UnityEngine;
using System.Collections;

public class VisionControllerScript : MonoBehaviour {

	public void enableCamera() {
		float cameraHeight = Screen.height - 25;
		float screenHeight = Screen.height;
		float cameraRectHeight = cameraHeight / screenHeight;
		float yRectMove = 1 - cameraRectHeight;
		transform.camera.rect = new Rect (0, yRectMove, 0.5f, cameraRectHeight);
		Debug.Log ("Camera height set to " + cameraRectHeight);
		transform.camera.enabled = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
