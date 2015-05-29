using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

	PlayerControllerScript player;
	PlayerEnvironmentController playerEnv;
	float breathTimer = 4;

	public void breathe() {
		Debug.Log ("Took a breath");
		foreach (EnvironmentControllerScript env in playerEnv.getEnvs()) {
			foreach (IGas gas in env.getGases()) {
				gas.affectPlayerHealth(this);
			}
		}
	}

	public void addOxygenToBlood() {
		Debug.Log ("Added oxygen to blood");
	}

	// Use this for initialization
	void Awake () {
		player = transform.parent.GetComponent<PlayerControllerScript> ();
		if (player == null) {
			Debug.LogError("Could not find player script.");
		}
		playerEnv = player.transform.FindChild ("EnvironmentController").GetComponent<PlayerEnvironmentController> ();
		if (playerEnv == null) {
			Debug.LogError("Could not find player environment script.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		breathTimer -= Time.deltaTime;
		if (breathTimer <= 0) {
			breathTimer = 4;
			breathe();
		}
	}
}
