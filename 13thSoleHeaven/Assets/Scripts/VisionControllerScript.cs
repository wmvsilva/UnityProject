using UnityEngine;
using System.Collections;
/*
 * Controls what the human player sees
 */
public class VisionControllerScript : MonoBehaviour {

	/*
	 * Enables the camera which follows this component which should be attached to the player.
	 * This means that the camera will follow the player.
	 */
	public void enableCamera() {
		// The view of the player only takes up half of the screen.
		// The remaining view is taken up by the chat window.
		float cameraHeight = Screen.height - 25;
		float screenHeight = Screen.height;
		float cameraRectHeight = cameraHeight / screenHeight;
		float yRectMove = 1 - cameraRectHeight;
		transform.camera.rect = new Rect (0, yRectMove, 0.5f, cameraRectHeight);
		Debug.Log ("Camera height set to " + cameraRectHeight);
		transform.camera.orthographicSize = (screenHeight / 2) / 100;
		transform.camera.enabled = true;
	}
}
