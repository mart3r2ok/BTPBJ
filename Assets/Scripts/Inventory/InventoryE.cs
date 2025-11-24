using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryE : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public List<ItemData> items = new List<ItemData>(2);
    void Start()
    {
        while (items.Count < 2)
            items.Add(null);
    }
    public void RemoveItem(int index)
    {
        items[index] = null;
        inventoryUI.RefreshUI();
    }
}
