using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentControllerScript : MonoBehaviour {

	int zoneNum;
	List<IGas> gases = new List<IGas> ();

	public void addGas(IGas g) {
		gases.Add (g);
	}

	public List<IGas> getGases() {
		return gases;
	}

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
