using UnityEngine;
using System.Collections;
/*
 * Manages the sprites used to display a player.
 */
public class PlayerSpriteScript : MonoBehaviour {

	// Sprites for the parts of a player
	public Sprite[] torsoSprites;
	public Sprite[] headSprites;
	public Sprite[] leftArmSprites;
	public Sprite[] rightArmSprites;
	public Sprite[] leftLegSprites;
	public Sprite[] rightLegSprites;
	public Sprite[] leftFootSprites;
	public Sprite[] rightFootSprites;
	public Sprite[] leftHandSprites;
	public Sprite[] rightHandSprites;
	// Renderers to render each of the player's sprite parts
	SpriteRenderer torsoRenderer;
	SpriteRenderer headRenderer;
	SpriteRenderer leftArmRenderer;
	SpriteRenderer rightArmRenderer;
	SpriteRenderer leftLegRenderer;
	SpriteRenderer rightLegRenderer;
	SpriteRenderer leftFootRenderer;
	SpriteRenderer rightFootRenderer;
	SpriteRenderer leftHandRenderer;
	SpriteRenderer rightHandRenderer;

	/*
	 * Initializes by loading all sprites
	 */
	void Start () {
		LoadSprites ("TorsoSprites", "TorsoSprite", torsoSprites, torsoRenderer);
		LoadSprites ("HeadSprites", "HeadSprite", headSprites, headRenderer);
		LoadSprites ("LeftArmSprites", "LeftArmSprite", leftArmSprites, leftArmRenderer);
		LoadSprites ("RightArmSprites", "RightArmSprite", rightArmSprites, rightArmRenderer);
		LoadSprites ("LeftLegSprites", "LeftLegSprite", leftLegSprites, leftLegRenderer);
		LoadSprites ("RightLegSprites", "RightLegSprite", rightLegSprites, rightLegRenderer);
		LoadSprites ("LeftFootSprites", "LeftFootSprite", leftFootSprites, leftFootRenderer);
		LoadSprites ("RightFootSprites", "RightFootSprite", rightFootSprites, rightFootRenderer);
		LoadSprites ("LeftHandSprites", "LeftHandSprite", leftHandSprites, leftHandRenderer);
		LoadSprites ("RightHandSprites", "RightHandSprite", rightHandSprites, rightHandRenderer);
	}

	/*
	 * Loads a sprite into a field and gives it to a given component renderer to render
	 */
	void LoadSprites(string spriteName, string childName, Sprite[] sprites, SpriteRenderer renderer) {
		sprites = Resources.LoadAll<Sprite>(spriteName);
		renderer = transform.FindChild (childName).GetComponent<SpriteRenderer> ();
		if (renderer == null) {
			Debug.LogError(childName + " renderer was null");
		}
		renderer.sprite = sprites [0];
	}
}
