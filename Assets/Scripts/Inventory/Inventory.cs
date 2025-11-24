using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public int MaxSlots = 8;
    public List<ItemData> items = new List<ItemData>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        Instance = this;

        // Заполняем список null, если меньше MaxSlots
        while (items.Count < MaxSlots)
            items.Add(null);
    }

    public void AddItem(ItemData newItem)
    {
        if (newItem.Countable)
        {
            var existing = items.Find(i => i != null && i.Name == newItem.Name);
            if (existing != null)
            {
                existing.Count += newItem.Count;
                return;
            }
        }

        // Найти первый пустой слот
        int emptyIndex = items.FindIndex(i => i == null);
        if (emptyIndex != -1)
        {
            items[emptyIndex] = newItem;
        }
        else
        {
            Debug.Log("Инвентарь полный!");
        }
        inventoryUI.RefreshUI();
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < MaxSlots)
            items[index] = null;
        inventoryUI.RefreshUI();
    }
}