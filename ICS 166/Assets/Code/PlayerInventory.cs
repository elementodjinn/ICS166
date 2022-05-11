using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
	public bool inventory_opened = false;
	private Item[] inventory_data;


	public PlayerInventory()
	{
		inventory_data = new Item[10];
		for (int i = 0; i < 10; i++)
		{
			inventory_data[i] = null;
		}

		Debug.Log("inventory");
	}


	public void AddItem(GameObject obj)
	{
		Item item = obj.GetComponent<Item>();
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] == null)
			{
				inventory_data[i] = item;
				break;
			}
		}

		// temp debug statements
		Debug.Log("ADD inventory");
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] != null) Debug.Log(inventory_data[i].type);
		}
	}


	// maybe temporary, might not need to remove items
	public void RemoveItem(int position)
	{
		inventory_data[position] = null;

		// temp debug statements
		Debug.Log("REMOVE inventory");
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] != null) Debug.Log(inventory_data[i].type);
		}
	}


	public Item[] GetItems()
	{
		return inventory_data;
	}
}
