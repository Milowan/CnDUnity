using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Armour")]

public class ArmourObject : ItemObject
{
    public float STRBonus;
    public float DexBonus;
    public float ConBonus;
    public float DefValue;

    public void Awake()
    {
        type = ItemType.Armour;
    }

}
