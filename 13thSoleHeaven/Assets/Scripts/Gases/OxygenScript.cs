using UnityEngine;
using System.Collections;

public class OxygenScript : IGas {

	float volume;
	float temperature;

	public OxygenScript(float v, float t) {
		volume = v;
		temperature = t;
	}

	public float getVolume() {
		return volume;
	}
	
	public float getTemperature() {
		return temperature;
	}
	
	public void affectPlayerHealth(PlayerHealthScript healthScript) {
		healthScript.addOxygenToBlood (6.0);
	}
}
