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

    // access to the player script object to check if dialogue is currently active when opening/closing inventory
    private Player access_dialogue_status; //NEW


    void Start()
    {
        inventory = new PlayerInventory();
        access_dialogue_status = FindObjectOfType<Player>(); //NEW
    }


    // Update is called once per frame
    void Update()
    {
        // Cannot interact with items while in inventory or not viewing a note
        if (!inventory.inventory_opened && !inventory.note_opened && !access_dialogue_status.IsDialogueRunning()) //NEW
        {
            if (detect_object && Input.GetKeyDown(KeyCode.E) && detected_object.activeSelf)
            {
                Debug.Log("INTERACT");
                detected_object.GetComponent<Item>().Interact();
            }
        }

        // Open/close inventory using "Tab" if not viewing a note & dialogue is not currently active
        if (Input.GetKeyDown(KeyCode.Tab) && !inventory.note_opened && !access_dialogue_status.IsDialogueRunning()) //NEW
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


    //public void RemoveFromInventory(Item.ItemType type)
    public void RemoveFromInventory(Item item) //NEW
    {
        Item.ItemType type = item.type; //NEW

        if (inventory.FindItem(type))
        {
            audioManager.Play(item.GetAudio()); //NEW
            inventoryUI.RemoveItem(inventory.RemoveItem(type));
            inventoryUI.UpdateInventory();
        }
    }


    public bool InventoryState()
    {
        return inventory.inventory_opened;
    }
}
