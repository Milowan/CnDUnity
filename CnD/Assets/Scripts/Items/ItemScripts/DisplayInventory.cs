using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
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
    // Upon picking up an item, if the number of slots is less than our slot limit,  we need to check through the inventory slots for the item, if we find it, we increment the amount displayed by 1,
    // if we dont find the item, we create a new itemSlot, pass in the items information and display it within the inventory, beside the previous inventory slot
    // or below if we are extending the inventory beyond 1 row.
    public void UpdateDisplay()
    {
        int slots;
        slots = inventory.container.Count;
        if (slots < slotLimit + 1 )
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                if (itemsDislayed.ContainsKey(inventory.container[i]))
                {
                    itemsDislayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosiotion(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                    itemsDislayed.Add(inventory.container[i], obj);
                }
            }
        }
    }
    // Create the Inventory on start, 
    public void CreateDisplay()
    {
        int slots;
        slots = inventory.container.Count;
        if (slots < slotLimit + 1)
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosiotion(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                itemsDislayed.Add(inventory.container[i], obj);

            }
        }
        else
        {

        }
    }
    public Vector3 GetPosiotion(int i)
    {   // Set the position of the inventory slot, and the space beside and below the next inventory slot.
        return new Vector3(XSTART + X_SPACE_BETWEEN_ITEM *(i % NUMBER_OF_COLUMN), YSTART + (-Y_SPACE_BETWEEN_ITEMS *(i/NUMBER_OF_COLUMN)), 0f);
    }
}
