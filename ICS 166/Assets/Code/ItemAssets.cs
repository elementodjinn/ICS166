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
	public Sprite note_sprite;
	public Sprite key_sprite;

	// Note Displays
	public Sprite note1;
	public Sprite note2;
}
