using UnityEngine;
using System.Collections;
/*
 * Controls all elements of a player's health
 */
public class PlayerHealthScript : MonoBehaviour {

	// Cached reference to the player
	PlayerControllerScript player;
	// Cached reference to the player's environment controller
	PlayerEnvironmentController playerEnv;
	// How often the player should breath in seconds.
	float breathTimer = 4;
	// How often the player should lose oxygen in seconds
	float oxygenDecreaseTimer = 1;
	// The player's current oxygen saturation
	public double oxygenSaturation = 100.00;

	/*
	 * breathe-
	 * The player breathes in the gases found in the environment and is affected by them in some way.
	 */
	public void breathe() {
		Debug.Log ("Took a breath");
		foreach (EnvironmentControllerScript env in playerEnv.getEnvs()) {
			foreach (IGas gas in env.getGases()) {
				gas.affectPlayerHealth(this);
			}
		}
	}

	/*
	 * addOxygenToBlood- increases the oxygen saturation by the given percentage
	 */
	public void addOxygenToBlood(double percent) {
		oxygenSaturation = oxygenSaturation + percent;
	}

	/*
	 * Awake- Unity uses this for initialization
	 * Attempts to cache the player controller and player environment controller
	 */
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
	
	/*
	 * Update- Unity runs this every frame
	 * The player breathes every so often and loses some amount of oxygen every so often.
	 */
	void Update () {
		breathTimer -= Time.deltaTime;
		if (breathTimer <= 0) {
			breathTimer = 4;
			breathe();
		}
		oxygenDecreaseTimer -= Time.deltaTime;
		if (oxygenDecreaseTimer <= 0) {
			oxygenDecreaseTimer = 1;
			oxygenSaturation = oxygenSaturation - 0.25;
		}
	}
}
