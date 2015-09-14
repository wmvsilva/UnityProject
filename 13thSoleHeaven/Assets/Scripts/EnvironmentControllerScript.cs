using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Controls a single square unit of the environment which is capable of holding different types of gases
 * and interacting with the player.
 */
public class EnvironmentControllerScript : MonoBehaviour {

	// A unique number for this environmental unit.
	int zoneNum;
	// All of the gases currently within this square.
	List<IGas> gases = new List<IGas> ();

	/**
	 * addGas- given gas g, adds it to the gases currently contained in this environmental unit
	 */
	public void addGas(IGas g) {
		gases.Add (g);
	}

	/**
	 * getGases- getter method for gases
	 */
	public List<IGas> getGases() {
		return gases;
	}

	/**
	 * changeZoneNum- setter method for unique zone number
	 */
	public void changeZoneNum(int newZoneNum) {
		zoneNum = newZoneNum;
	}

	/**
	 * getZoneNum- getter method for unique zone number
	 */
	public int getZoneNum() {
		return zoneNum;
	}

	/**
	 * changeParentTo- changes the parent of this Unity transform to the given t
	 * Used for adding environmental units to the land controller after instantiation.
	 */
	public void changeParentTo(Transform t) {
		transform.parent = t;
	}

	/**
	 * OnTriggerEnter2D- if a player enters this square, they are given the current environment of this square.
	 */
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.transform.FindChild("EnvironmentController").GetComponent<PlayerEnvironmentController>().giveEnvironment(this);
		}
	}

	/**
	 * OnTriggerExit2D- if a player exits this square, they lose the current environment of this square
	 */
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.transform.FindChild("EnvironmentController").GetComponent<PlayerEnvironmentController>().removeEnvironment(this);
		}
	}
}
