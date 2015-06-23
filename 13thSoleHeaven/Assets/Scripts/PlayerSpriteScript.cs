using UnityEngine;
using System.Collections;

public class PlayerSpriteScript : MonoBehaviour {

	public Sprite[] torsoSprites;
	public Sprite[] headSprites;
	public Sprite[] leftArmSprites;
	SpriteRenderer torsoRenderer;
	SpriteRenderer headRenderer;
	SpriteRenderer leftArmRenderer;

	// Use this for initialization
	void Start () {
		LoadSprites ("TorsoSprites", "TorsoSprite", torsoSprites, torsoRenderer);
		LoadSprites ("HeadSprites", "HeadSprite", headSprites, headRenderer);
		LoadSprites ("LeftArmSprites", "LeftArmSprite", leftArmSprites, leftArmRenderer);
	}

	void LoadSprites(string spriteName, string childName, Sprite[] sprites, SpriteRenderer renderer) {
		sprites = Resources.LoadAll<Sprite>(spriteName);
		renderer = transform.FindChild (childName).GetComponent<SpriteRenderer> ();
		if (renderer == null) {
			Debug.LogError(childName + " renderer was null");
		}
		renderer.sprite = sprites [0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
