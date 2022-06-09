using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public enum ItemType
	{
		Default,
		
		// Notes
		Note1,
		Note2,

		// Items
		Key
	}

	public ItemType type;

	
	// maybe temporary
	public void Interact()
	{
		Debug.Log("PICK UP");
		GameObject item = gameObject;
		FindObjectOfType<ItemInteraction>().PickUpItem(item);
		//Disable the obj
		gameObject.SetActive(false);
	}


	public Sprite GetNote()
	{
		switch (type)
		{
			default:
			case ItemType.Note1: return ItemAssets.Instance.note1;
			case ItemType.Note2: return ItemAssets.Instance.note2;
		}
	}


	public Sprite GetSprite()
	{
		switch (type)
		{
			default:
			// Notes
			case ItemType.Note1: 
			case ItemType.Note2: return ItemAssets.Instance.note_sprite;

			// Items
			case ItemType.Key: return ItemAssets.Instance.key_sprite;
		}
	}

    public void ChangeColorBlack()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.black;
    }

    public void ChangeColorWhite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }


    public string GetText()
	{
		switch (type)
		{
			default:
			// Notes
			case ItemType.Note1: return "note #1";
			case ItemType.Note2: return "note #2";

			// Items
			case ItemType.Key: return "key";
		}
	}
}
