using UnityEngine;
using System.Collections;

public interface IGas {

	float getVolume();

	float getTemperature();
	
	void affectPlayerHealth(PlayerHealthScript healthScript);
}
