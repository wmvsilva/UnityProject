using UnityEngine;
using System.Collections;

public class EnvironmentControllerScript : MonoBehaviour {

	int zoneNum;

	public void changeZoneNum(int newZoneNum) {
		zoneNum = newZoneNum;
	}

	public int getZoneNum() {
		return zoneNum;
	}
	
	public void changeParentTo(Transform t) {
		transform.parent = t;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.transform.FindChild("EnvironmentController").GetComponent<PlayerEnvironmentController>().giveEnvironment(this);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.transform.FindChild("EnvironmentController").GetComponent<PlayerEnvironmentController>().removeEnvironment(this);
		}
	}
}
