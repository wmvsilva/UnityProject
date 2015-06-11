using UnityEngine;
using System.Collections;

public class PlayerSpriteScript : MonoBehaviour {

	public Sprite[] torsoSprites;
	SpriteRenderer torsoRenderer;

	// Use this for initialization
	void Start () {
		torsoSprites = Resources.LoadAll<Sprite>("Torso");
		torsoRenderer = transform.FindChild ("TorsoSprite").GetComponent<SpriteRenderer> ();
		if (torsoRenderer == null) {
			Debug.LogError("Torso renderer was null");
		}
		torsoRenderer.sprite = torsoSprites [0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
