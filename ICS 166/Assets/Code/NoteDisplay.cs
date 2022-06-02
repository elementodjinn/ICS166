using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour
{
    // the note display's UI, starts out inactive
    private GameObject note_ui;

	private GameObject note_container;
	private Image note_image;

	
	private void Awake()
	{
		note_container = GameObject.Find("Note").gameObject;
		note_image = note_container.transform.GetChild(0).gameObject.GetComponent<Image>();

		note_ui = this.gameObject;
		note_ui.SetActive(false);
	}


	public void Open(Item item)
	{
		note_ui.SetActive(true);
		Image close_button = GameObject.Find("CloseButton").gameObject.GetComponent<Image>();
		close_button.color = new Color(close_button.color.r, close_button.color.g, close_button.color.b, 0.5f);

		note_image.sprite = item.GetNote();
	}


	public void Close()
	{
		note_ui.SetActive(false);
	}
}
