using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInteraction : MonoBehaviour
{
    private GameObject detected_object;
    private bool detect_object = false;

    [SerializeField] private InventoryUI inventoryUI;
    private PlayerInventory inventory;

    [SerializeField] private AudioManager audioManager;


    void Start()
    {
        inventory = new PlayerInventory();
    }


    // Update is called once per frame
    void Update()
    {
        // Cannot interact with items while in inventory or not viewing a note
        if (!inventory.inventory_opened && !inventory.note_opened)
        {
            if (detect_object && Input.GetKeyDown(KeyCode.E) && detected_object.activeSelf)
            {
                Debug.Log("INTERACT");
                detected_object.GetComponent<Item>().Interact();
            }
        }

        // Open/close inventory using "Tab" if not viewing a note
        if (Input.GetKeyDown(KeyCode.Tab) && !inventory.note_opened)
        {
            if (!inventory.inventory_opened)
            {
                inventoryUI.OpenInventory(inventory);
            }
            else
            {
                inventoryUI.CloseInventory();
                audioManager.Play("InventoryOpen");
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Item")
        {
            Debug.Log(collision.gameObject.activeSelf);
            Debug.Log("Item!");
            detected_object = collision.gameObject;
            detect_object = true;
        }
        else
        {
            detected_object = null;
            detect_object = false;
        }
    }


    public void PickUpItem(GameObject item)
    {
        audioManager.Play(item.GetComponent<Item>().GetAudio());
        inventory.AddItem(item);
    }


    public void RemoveFromInventory(Item.ItemType type)
    {
        if (inventory.FindItem(type))
        {
            inventoryUI.RemoveItem(inventory.RemoveItem(type));
            inventoryUI.UpdateInventory();
        }
    }
}
