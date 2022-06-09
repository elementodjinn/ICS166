using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
	public static ItemAssets Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	// Inventory Sprites
	public Sprite key_sprite;
	public Sprite cash_sprite;
	public Sprite coin_sprite;
	public Sprite food_sprite;
	public Sprite note_sprite;

	// Note Displays
	public Sprite note1;
	// not implemented yet TEMPORARY
	public Sprite note2;
	public Sprite note3;
	public Sprite note4;
	public Sprite note5;
	public Sprite note6;
	public Sprite note7;
	public Sprite note8;
}
