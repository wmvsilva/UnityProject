using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Determines how a player is to interact with the environments they have been given
 */
public class PlayerEnvironmentController : MonoBehaviour {

	// The list of environments that a player is currently in
	LinkedList<EnvironmentControllerScript> envs = new LinkedList<EnvironmentControllerScript>();

	// Getter method for envs field
	public LinkedList<EnvironmentControllerScript> getEnvs() {
		return envs;
	}

	/*
	 * Records that the player is in given environment e
	 */
	public void giveEnvironment(EnvironmentControllerScript e) {
		envs.AddLast (e);
	}

	/*
	 * Records that the player has left the environment e.
	 */
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
}
