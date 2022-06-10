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
	[SerializeField] private GameObject[] item_containers;

	[SerializeField] private NoteDisplay note_display;
	[SerializeField] private AudioManager audioManager;

	// access to the player script object to disable/enable movement when opening/closing inventory
	private Player access_movement;


	private void Awake()
	{
		access_movement = FindObjectOfType<Player>();

		foreach (GameObject item in item_containers)
			item.SetActive(false);

		ui = this.gameObject;
		ui.SetActive(false);
	}


	// "Opens" the inventory by activating it
	public void OpenInventory(PlayerInventory inventory)
	{
		this.inventory = inventory;

		audioManager.Play("InventoryOpen");
		inventory.inventory_opened = true;
		ui.SetActive(true);
		
		UpdateInventory();

		access_movement.DisableMov();
	}


	// "Closes" the inventory by de-activating it
    public void CloseInventory()
	{
		inventory.inventory_opened = false;
		ui.SetActive(false);

		access_movement.EnableMov();
	}


	// Updates the displayed inventory's UI
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
		CloseInventory();

		note_display.setInventory(inventory);
		note_display.Open(item);
	}


	// Returns a list containing all note types
	public List<Item.ItemType> AllNotes()
	{
		return note_display.notes;
	}
}
