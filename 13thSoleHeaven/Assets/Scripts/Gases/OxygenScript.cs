using UnityEngine;
using System.Collections;
/**
 * Oxygen as a gas to be place in an environment.
 */
public class OxygenScript : IGas {

	// The volume of the oxygen in m^3
	float volume;
	// The temperature of the oxygen in C
	float temperature;

	/**
	 * Oxygen constructor which creates a unit of oxygen
	 * with volume v and temperature t
	 */
	public OxygenScript(float v, float t) {
		volume = v;
		temperature = t;
	}

	// Getter method for volume
	public float getVolume() {
		return volume;
	}

	// Getter method for temperature
	public float getTemperature() {
		return temperature;
	}

	/*
	 * affectPlayerHealth- Oxygen affects player health by adding oxygen to the player's blood.
	 */
	public void affectPlayerHealth(PlayerHealthScript healthScript) {
		healthScript.addOxygenToBlood (6.0);
	}
}
