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

	// Notes
	public Sprite note_sprite;

	// Items
	public Sprite key_sprite;
}
