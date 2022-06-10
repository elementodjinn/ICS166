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

	[SerializeField] private AudioManager audioManager;

	private GameObject left_arrow;
	private GameObject right_arrow;
	private Item item;
	private int page_num = 0;
	//public int num_pages = 0;


	private void Awake()
	{
		access_movement = FindObjectOfType<Player>();

		note_container = GameObject.Find("Note").gameObject;
		note_image = note_container.transform.GetChild(0).gameObject.GetComponent<Image>();

		left_arrow = GameObject.Find("LeftArrow").gameObject;
		right_arrow = GameObject.Find("RightArrow").gameObject;

		note_ui = this.gameObject;
		note_ui.SetActive(false);
	}


	public void setInventory(PlayerInventory inventory)
    {
		this.inventory = inventory;
	}


	public void Open(Item i)
	{
		item = i;
		
		inventory.note_opened = true;
		note_ui.SetActive(true);
		page_num = 0;

		Image close_button = GameObject.Find("CloseButton").gameObject.GetComponent<Image>();
		close_button.color = new Color(close_button.color.r, close_button.color.g, close_button.color.b, 0.5f);

		//num_pages = item.GetNumPages();
		if (item.GetNumPages() > 1)
        {
			page_num = 1;
		}

		UpdateNote();

		access_movement.DisableMov();

		audioManager.Play("NotePage");
	}


	private void UpdateNote()
	{
		Image left_arrow_image = left_arrow.GetComponent<Image>();
		left_arrow_image.color = new Color(left_arrow_image.color.r, left_arrow_image.color.g, left_arrow_image.color.b, 0.5f);

		Image right_arrow_image = right_arrow.GetComponent<Image>();
		right_arrow_image.color = new Color(right_arrow_image.color.r, right_arrow_image.color.g, right_arrow_image.color.b, 0.5f);

		if (page_num == 0)
		{
			left_arrow.SetActive(false);
			right_arrow.SetActive(false);
			note_image.sprite = item.GetNote();
		}
		else if (page_num == 1)
		{
			right_arrow.SetActive(true);
			left_arrow.SetActive(false);
			note_image.sprite = item.GetNote();
		}
		else if (page_num == 2)
		{
			left_arrow.SetActive(true);
			right_arrow.SetActive(false);
			note_image.sprite = item.GetNoteP2();
		}
	}



	public void Close()
	{
		inventory.note_opened = false;
		note_ui.SetActive(false);

		access_movement.EnableMov();
	}


	public void TurnPage(int arrow_type)
	{
		// Turns the note left or right (if multiple pages)
		page_num += arrow_type;
		UpdateNote();

		audioManager.Play("NotePage");
	}
}
