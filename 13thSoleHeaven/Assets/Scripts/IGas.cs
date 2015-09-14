using UnityEngine;
using System.Collections;
/**
 * IGas
 * An interface for gases which have volume, temperature, and affect the player in some way.
 */
public interface IGas {

	// Retrieves the volume of the gas in m^3
	float getVolume();

	// Retrieves the temperature of the gas in C
	float getTemperature();

	// Given a player health controller, affects the health in some way based on the contents
	// and temperature of the gas.
	void affectPlayerHealth(PlayerHealthScript healthScript);
}
