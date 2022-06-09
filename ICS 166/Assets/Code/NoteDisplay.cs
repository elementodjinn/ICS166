using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour
{
	private PlayerInventory inventory;

	// the note display's UI, starts out inactive
	private GameObject note_ui;

	private GameObject note_container;
	private Image note_image;

	// access to the player script object to disable/enable movement when opening/closing inventory
	private Player access_movement;

	public List<Item.ItemType> notes = new List<Item.ItemType>{ Item.ItemType.Note1, Item.ItemType.Note2, Item.ItemType.Note3, Item.ItemType.Note4,
									Item.ItemType.Note5, Item.ItemType.Note6, Item.ItemType.Note7, Item.ItemType.Note8 };


	private void Awake()
	{
		access_movement = FindObjectOfType<Player>();

		note_container = GameObject.Find("Note").gameObject;
		note_image = note_container.transform.GetChild(0).gameObject.GetComponent<Image>();

		note_ui = this.gameObject;
		note_ui.SetActive(false);
	}


	public void setInventory(PlayerInventory inventory)
    {
		this.inventory = inventory;
	}


	public void Open(Item item)
	{
		inventory.note_opened = true;
		note_ui.SetActive(true);

		Image close_button = GameObject.Find("CloseButton").gameObject.GetComponent<Image>();
		close_button.color = new Color(close_button.color.r, close_button.color.g, close_button.color.b, 0.5f);

		note_image.sprite = item.GetNote();

		access_movement.DisableMov();
	}


	public void Close()
	{
		inventory.note_opened = false;
		note_ui.SetActive(false);

		access_movement.EnableMov();
	}
}
