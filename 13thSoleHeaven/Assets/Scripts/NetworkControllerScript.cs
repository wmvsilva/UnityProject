using UnityEngine;
using System.Collections;
/**
 * Controls all network events that are constantly updated like player movement, etc.
 */
public class NetworkControllerScript : Photon.MonoBehaviour {

	// The current player's input controller
	PlayerControllerScript controllerScript;
	// Holds position component received over the network.
	Vector3 realPosition = Vector3.zero;
	// HOlds velocity component received over the network.
	Vector2 realVelocity = Vector2.zero;

	/**
	 * Awake- Unity uses this for initialization.
	 * Retrieves and caches the player's input controller script.
	 */
	void Awake () {
		controllerScript = transform.GetComponentInParent<PlayerControllerScript> ();
		if (controllerScript == null) {
			Debug.LogError("Could not load Player Input Script");
		}
	}
	
	/**
	 * myUpdate- Should be called once a frame.
	 * When another player's photon view is found, lerp their velocity and position based on the received network data.
	 */
	public void myUpdate () {
		if (controllerScript.transform.GetComponent<PhotonView>().isMine) {
			// Do nothing
		} else {
			controllerScript.transform.position = Vector3.Lerp(transform.position,realPosition, 0.1f);
			controllerScript.transform.rigidbody2D.velocity = Vector2.Lerp(controllerScript.transform.rigidbody2D.velocity, realVelocity, 0.1f);
		}
	}

	/**
	 * myOnPhotonSerializeView- given a photon steam, either sends or recieves player position and velocity.
	 */
	public void myOnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

		if (stream.isWriting) {
			// Our player
			stream.SendNext(controllerScript.transform.position);
			stream.SendNext(controllerScript.transform.rigidbody2D.velocity);
		} else {
			// Someone else's player
			realPosition = (Vector3) stream.ReceiveNext();
			realVelocity = (Vector2) stream.ReceiveNext();
		}
	}
}
