using UnityEngine;
using System.Collections;

public class NetworkControllerScript : Photon.MonoBehaviour {

	PlayerControllerScript controllerScript;
	Vector3 realPosition = Vector3.zero;
	Vector2 realVelocity = Vector2.zero;

	// Use this for initialization
	void Awake () {
		controllerScript = transform.GetComponentInParent<PlayerControllerScript> ();
		if (controllerScript == null) {
			Debug.LogError("Could not load Player Input Script");
		}
	}
	
	// Update is called once per frame
	public void myUpdate () {
		if (controllerScript.transform.GetComponent<PhotonView>().isMine) {
			// Do nothing
		} else {
			controllerScript.transform.position = Vector3.Lerp(transform.position,realPosition, 0.1f);
			controllerScript.transform.rigidbody2D.velocity = Vector2.Lerp(controllerScript.transform.rigidbody2D.velocity, realVelocity, 0.1f);
		}
	}

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
