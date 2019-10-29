using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Database", menuName ="Inventory System/Items/Database")]
public class ItemDatabaseObj : ScriptableObject, ISerializationCallbackReceiver // Unity doesnt serialize dictionaries, the is a callback feature that allows us to do so.

{
    // an array that holds all of the items in the game.
    public ItemObject[] Items;
    // Dictionary to easily import an item and easily return that item
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();


    // We want to make a new dictionary, and clears it so we are not duplicating any of our items
    public void OnAfterDeserialize()
    {
        // When unity serealises the scriptable object, it will automatically populate the dictionary
        // with refrence values based off the items array we create 
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].ID = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
