using UnityEngine;
using System.Collections;

public class EnvironmentControllerScript : MonoBehaviour {
	
	public void changeParentTo(Transform t) {
		transform.parent = t;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
