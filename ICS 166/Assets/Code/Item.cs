using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public enum ItemType
	{
		Default,

		// Items
		Key,
		Cash,
		Coin,
		Food,
		
		// Notes
		Note1,
		Note2,
		Note3,
		Note4,
		Note5,
		Note6,
		Note7,
		Note8
	}

	public ItemType type;

	
	public void Interact()
	{
		Debug.Log("PICK UP");
		GameObject item = gameObject;
		FindObjectOfType<ItemInteraction>().PickUpItem(item);
		//Disable the obj
		gameObject.SetActive(false);
	}


	// Removes an item from the inventory
	public void Remove()
	{
		if (type != ItemType.Default)
		{
			Debug.Log("REMOVE");
			//FindObjectOfType<ItemInteraction>().RemoveFromInventory(type);
			FindObjectOfType<ItemInteraction>().RemoveFromInventory(this); //NEW
		}
	}


	public int GetNumPages()
	{
		switch (type)
		{
			default:
			case ItemType.Note2:
			case ItemType.Note3:
			case ItemType.Note4:
			case ItemType.Note5:
			case ItemType.Note6:
			case ItemType.Note7:
			case ItemType.Note8: return 1;

			case ItemType.Note1: return 2;
		}
	}


	public Sprite GetNote()
	{
		switch (type)
		{
			default:
			case ItemType.Note1: return ItemAssets.Instance.note1p1;
			case ItemType.Note2: return ItemAssets.Instance.note2;
			case ItemType.Note3: return ItemAssets.Instance.note3;
			case ItemType.Note4: return ItemAssets.Instance.note4;
			case ItemType.Note5: return ItemAssets.Instance.note5;
			case ItemType.Note6: return ItemAssets.Instance.note6;
			case ItemType.Note7: return ItemAssets.Instance.note7;
			case ItemType.Note8: return ItemAssets.Instance.note8;
		}
	}


	public Sprite GetNoteP2()
	{
		switch (type)
		{
			default:
			case ItemType.Note1: return ItemAssets.Instance.note1p2;
		}
	}


	public Sprite GetSprite()
	{
		switch (type)
		{
			default:
			// Items
			case ItemType.Key: return ItemAssets.Instance.key_sprite;
			case ItemType.Cash: return ItemAssets.Instance.cash_sprite;
			case ItemType.Coin: return ItemAssets.Instance.coin_sprite;
			case ItemType.Food: return ItemAssets.Instance.food_sprite;

			// Notes
			case ItemType.Note1:
			case ItemType.Note2:
			case ItemType.Note3:
			case ItemType.Note4:
			case ItemType.Note5:
			case ItemType.Note6:
			case ItemType.Note7:
			case ItemType.Note8: return ItemAssets.Instance.note_sprite;
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
			// Items
			case ItemType.Key: return "key";
			case ItemType.Cash: return "cash";
			case ItemType.Coin: return "coin";
			case ItemType.Food: return "hamburger";

			// Notes
			case ItemType.Note1: return "note #1";
			case ItemType.Note2: return "note #2";
			case ItemType.Note3: return "note #3";
			case ItemType.Note4: return "note #4";
			case ItemType.Note5: return "note #5";
			case ItemType.Note6: return "note #6";
			case ItemType.Note7: return "note #7";
			case ItemType.Note8: return "note #8";
		}
	}


	public string GetAudio()
	{
		switch (type)
		{
			default:
			// Items
			case ItemType.Key: return "Keys";
			case ItemType.Cash:
			case ItemType.Coin: return "Coins";
			case ItemType.Food: return "Food";

			// Notes
			case ItemType.Note1:
			case ItemType.Note2:
			case ItemType.Note3:
			case ItemType.Note4:
			case ItemType.Note5:
			case ItemType.Note6:
			case ItemType.Note7:
			case ItemType.Note8: return "NotePage";
		}
	}
}
