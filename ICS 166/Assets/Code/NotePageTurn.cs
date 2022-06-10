using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotePageTurn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public int arrow_type;

	private GameObject obj;
	private Image image;

	[SerializeField] private NoteDisplay note_display;


	void Start()
	{
		obj = this.gameObject;
		image = obj.GetComponent<Image>();
	}


	// Indicates when cursor is over an arrow
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Visually indicate hover over an item
		image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		// Visually indicate hover off of an arrow
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
	}


	// Detects if an arrow is clicked on
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			note_display.TurnPage(arrow_type);
		}
	}
}