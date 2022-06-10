using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
	public bool inventory_opened = false;
	public bool note_opened = false;
	private Item[] inventory_data;
	private int inventory_capacity = 12;


	public PlayerInventory()
	{
		inventory_data = new Item[inventory_capacity];
		for (int i = 0; i < inventory_capacity; i++)
		{
			inventory_data[i] = null;
		}

		Debug.Log("inventory");
	}


	public void AddItem(GameObject obj)
	{
		Item item = obj.GetComponent<Item>();
		for (int i = 0; i < inventory_capacity; i++)
		{
			if (inventory_data[i] == null)
			{
				inventory_data[i] = item;
				break;
			}
		}

		// temp debug statements
		Debug.Log("ADD inventory");
		for (int i = 0; i < inventory_capacity; i++)
		{
			if (inventory_data[i] != null) Debug.Log(inventory_data[i].type);
		}
	}


	// removes item from inventory and returns what position in inventory it was in
	// so that the UI slot at that position can update
	public int RemoveItem(Item.ItemType item_type)
	{
		for (int i = 0; i < inventory_capacity; i++)
		{
			if (inventory_data[i] != null && inventory_data[i].type == item_type)
			{
				inventory_data[i] = null;
				return i;
			}
		}

		return -1;
	}


	public Item[] GetItems()
	{
		return inventory_data;
	}


	// Returns true if there is an item of item_type in the inventory, false otherwise
	// Use to check if a player has a specific item in their inventory
	public bool FindItem(Item.ItemType item_type)
	{
		for (int i = 0; i < inventory_capacity; i++)
		{
			if (inventory_data[i] != null && inventory_data[i].type == item_type)
			{
				return true;
			}
		}

		return false;
	}
}
