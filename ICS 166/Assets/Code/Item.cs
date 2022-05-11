using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public enum ItemType
	{
		// Notes
		Note1,

		// Items
		Key
	}

	public ItemType type;

	
	// DID NOT WRITE***************************************************************
	/*private void Reset()
	{
		GetComponent<Collider2D>().isTrigger = true;
		gameObject.layer = 10;
	}*/


	// maybe temporary
	public void Interact()
	{
		Debug.Log("PICK UP");
		GameObject item = gameObject;
		FindObjectOfType<ItemInteraction>().PickUpItem(item);
		//Disable the obj
		gameObject.SetActive(false);
	}


	public Sprite GetSprite()
	{
		switch (type)
		{
			default:
			// Notes
			case ItemType.Note1: return ItemAssets.Instance.note_sprite;

			// Items
			case ItemType.Key: return ItemAssets.Instance.key_sprite;
		}
	}


	public string GetText()
	{
		switch (type)
		{
			default:
			// Notes
			case ItemType.Note1: return "note #1";

			// Items
			case ItemType.Key: return "key";
		}
	}
}
