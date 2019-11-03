using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Inventory inventory;
    public int i;

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<DropSCript>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

}
