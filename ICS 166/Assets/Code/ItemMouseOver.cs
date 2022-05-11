using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private GameObject selected_obj;
	private Image image;

	void Start()
	{
		selected_obj = this.transform.GetChild(0).gameObject;
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		selected_obj.SetActive(true);
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		selected_obj.SetActive(false);
	}
}
