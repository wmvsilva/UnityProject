using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerEnvironmentController : MonoBehaviour {

	LinkedList<EnvironmentControllerScript> envs = new LinkedList<EnvironmentControllerScript>();

	public void giveEnvironment(EnvironmentControllerScript e) {
		envs.AddLast (e);
	}

	public void removeEnvironment(EnvironmentControllerScript e) {
		int zoneToRemove = e.getZoneNum ();
		foreach (EnvironmentControllerScript env in envs) {
			if (env.getZoneNum() == zoneToRemove) {
				envs.Remove(env);
				return;
			}
		}
		Debug.Log ("Could not remove the given environment.");
	}

	public LinkedList<EnvironmentControllerScript> getEnvs() {
		return envs;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
