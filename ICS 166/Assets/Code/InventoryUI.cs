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

	[SerializeField] private NoteDisplay note_display;


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
		GameObject ui_item_container;
		GameObject ui_item_sprite;
		GameObject ui_item_text;
		GameObject selected_obj;
		Item ui_item;

		for (int i = 0; i < items.Length; i++)
		{
			ui_item_container = item_containers[i];

			selected_obj = ui_item_container.transform.GetChild(0).gameObject;
			ui_item_sprite = ui_item_container.transform.GetChild(1).gameObject;
			ui_item_text = ui_item_container.transform.GetChild(2).gameObject;
			ui_item = ui_item_container.GetComponent<Item>();

			if (items[i] != null)
			{
				ui_item.type = items[i].type;

				ui_item_container.SetActive(true);
				selected_obj.SetActive(false);

				Image image = ui_item_sprite.GetComponent<Image>();
				image.sprite = items[i].GetSprite();

				TextMeshProUGUI tmp_text = ui_item_text.GetComponent<TextMeshProUGUI>();
				tmp_text.text = items[i].GetText();
			}
			else
			{
				ui_item_container.SetActive(false);
			}
		}
	}


	// Opens a note by activating it & closes the inventory
	public void OpenNote(Item item)
	{
		inventory.note_opened = true;

		inventory.inventory_opened = false;
		CloseInventory();

		note_display.Open(item);
	}


	// Closes a note by deactivating it
	public void CloseRecipes()
	{
		note_display.Close();
	}
}
