using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public GameObject inventoryPrefab; // Set a default prefab so we only need to change the sprite and not an entire prefab
    public InventoryObject inventory;
    public int slotLimit;

    public int XSTART;              // the X Position we want to start the inventory at, in relation to the position in the editior.
    public int YSTART;              //  ... same but for y position
    public int X_SPACE_BETWEEN_ITEM;        // The spaces between the inventory slots
    public int NUMBER_OF_COLUMN;            // the number of collums we want, before moving below the first inventory slot
    public int Y_SPACE_BETWEEN_ITEMS;       // space between the rows, if we need it

    Dictionary<InventorySlot, GameObject> itemsDislayed = new Dictionary<InventorySlot, GameObject>();


    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }
    //Upon picking up an item, if the number of slots is less than our slot limit,  we need to check through the inventory slots for the item, if we find it, we increment the amount displayed by 1,
    // if we dont find the item, we create a new itemSlot, pass in the items information and display it within the inventory, beside the previous inventory slot
    //or below if we are extending the inventory beyond 1 row.
        public void UpdateDisplay()
    {
        int slots;
        slots = inventory.container.items.Count;
        if (slots < slotLimit + 1)
        {
            for (int i = 0; i < inventory.container.items.Count; i++)
            {
                InventorySlot slot = inventory.container.items[i];
                if (itemsDislayed.ContainsKey(slot))
                {
                    itemsDislayed[inventory.container.items[i]].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.ID].uiDisplay;
                    obj.GetComponent<RectTransform>().localPosition = GetPosiotion(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                    itemsDislayed.Add(slot, obj);
                }
            }
        }
    }
    // Create the Inventory on start, 
    public void CreateDisplay()
    {
        int slots;
        slots = inventory.container.items.Count;
        if (slots < slotLimit + 1)
        {

            for (int i = 0; i < inventory.container.items.Count; i++)
            {
                InventorySlot slot = inventory.container.items[i];

                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.ID].uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosiotion(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                itemsDislayed.Add(slot, obj);

            }
        }
        else
        {

        }
    }
    public Vector3 GetPosiotion(int i)
    {   // Set the position of the inventory slot, and the space beside and below the next inventory slot.
        return new Vector3(XSTART + X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN), YSTART + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
