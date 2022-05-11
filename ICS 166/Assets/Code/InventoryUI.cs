using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
	private PlayerInventory inventory;

	// the inventory's UI, starts out inactive, activates when Tab is pressed
	private GameObject ui;

	// an array containing all the item slots of the inventory's ui, starts out inactive
	private GameObject[] item_containers;


	private void Awake()
	{
		item_containers = GameObject.FindGameObjectsWithTag("ItemContainer");
		foreach (GameObject item in item_containers)
			item.SetActive(false);

		ui = this.gameObject;
		ui.SetActive(false);
	}


	// "Opens" the inventory by activating it
	public void OpenInventory(PlayerInventory inventory)
	{
		this.inventory = inventory;
		ui.SetActive(true);
		UpdateInventory();
	}


	// "Closes" the inventory by de-activating it
    public void CloseInventory()
	{
		ui.SetActive(false);
	}


	// Updates the displayed inventory's ui
	public void UpdateInventory()
	{
		Item[] items = inventory.GetItems();
		GameObject item_container;
		GameObject item_sprite;
		GameObject item_text;

		for (int i = 0; i < items.Length; i++)
		{
			item_container = item_containers[i];
			item_sprite = item_container.transform.GetChild(1).gameObject;
			item_text = item_container.transform.GetChild(2).gameObject;
			
			if (items[i] != null)
			{
				item_container.SetActive(true);

				Image image = item_sprite.GetComponent<Image>();
				image.sprite = items[i].GetSprite();

				TextMeshProUGUI tmp_text = item_text.GetComponent<TextMeshProUGUI>();
				tmp_text.text = items[i].GetText();
			}
			else
			{
				item_container.SetActive(false);
			}
		}
	}
}
