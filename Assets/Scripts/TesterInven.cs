using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;

    public ItemData potionItem;
    public ItemData swordItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemData newItem = new ItemData()
            {
                Name = potionItem.Name,
                Icon = potionItem.Icon,
                Countable = potionItem.Countable,
                Count = potionItem.Count,
                Type = potionItem.Type
            };
            inventory.AddItem(newItem);
            inventoryUI.RefreshUI();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
             ItemData newItem = new ItemData
            {
                Name = swordItem.Name,
                Icon = swordItem.Icon,
                Countable = swordItem.Countable,
                Count = swordItem.Count,
                Type = swordItem.Type
            };
            inventory.AddItem(newItem);
            inventoryUI.RefreshUI();
        }
    }
}