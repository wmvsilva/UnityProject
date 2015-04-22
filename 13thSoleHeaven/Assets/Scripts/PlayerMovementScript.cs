using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void myUpdate () {

	}

	public void giveXYInput(float inputX, float inputY) {
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
	}

	public void myFixedUpdate(Transform player) {
		if (isActiveAndEnabled) {
			player.rigidbody2D.velocity = movement;
		}
	}
}
