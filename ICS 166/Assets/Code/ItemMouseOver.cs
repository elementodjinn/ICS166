using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField] private InventoryUI inventoryUI; 
	
	private GameObject selected_obj;
	private Image image;
	private Item item;

	void Start()
	{
		selected_obj = this.transform.GetChild(0).gameObject;
		item = this.GetComponent<Item>();
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		// temp if statement cuz currently can only click on notes
		if (inventoryUI.AllNotes().Contains(item.type))
			selected_obj.SetActive(true);
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		// temp if statement cuz currently can only click on notes
		if (inventoryUI.AllNotes().Contains(item.type))
			selected_obj.SetActive(false);
	}


	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			if (inventoryUI.AllNotes().Contains(item.type))
				inventoryUI.OpenNote(item);
			//else if (item.type == Item.ItemType.Key)
				//item.Remove();
		}
	}
}
