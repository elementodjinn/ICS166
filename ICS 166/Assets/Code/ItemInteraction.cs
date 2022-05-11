using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// maybe temporary, might need to be rewritten to a different script, temp blocks marked with //mb_temp
public class ItemInteraction : MonoBehaviour
{
    //mb_temp
    private Transform detectionPoint;
    private const float detectionRadius = 1f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;

    [SerializeField] private InventoryUI inventoryUI;
    private PlayerInventory inventory;


    void Start()
    {
        //mb_temp
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Item");

        inventory = new PlayerInventory();
    }


    // Update is called once per frame
    void Update()
    {
        // Cannot interact with items while in inventory
        if (!inventory.inventory_opened)
        {
            // Interact with item on ground using "e"
            if (DetectObject() && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("INTERACT");
                detectedObject.GetComponent<Item>().Interact();
            }
        }

        // Open/close inventory using "Tab"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventory.inventory_opened)
            {
                inventory.inventory_opened = true; 
                inventoryUI.OpenInventory(inventory);
            }
            else
            {
                inventory.inventory_opened = false;
                inventoryUI.CloseInventory();
            }
        }
    }


    //mb_temp
    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }


    public void PickUpItem(GameObject item)
    {
        inventory.AddItem(item);
    }
}
