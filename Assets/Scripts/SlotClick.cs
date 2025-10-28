using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotClickable : MonoBehaviour, IPointerClickHandler
{
    public int slotIndex;
    private InventoryUI inventoryUI;

    private static ItemData heldItem;
    private static Image heldIcon;
    private static Canvas mainCanvas;
    private List<ItemData> items = new List<ItemData>();

    void Start()
    {
        inventoryUI = GetComponentInParent<InventoryUI>();
        if (mainCanvas == null)
            mainCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (heldIcon != null)
            heldIcon.transform.position = Input.mousePosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked slot " + slotIndex);
        int adjustedIndex = slotIndex;
        if (adjustedIndex <= 7)
        {
            items = inventoryUI.inventory.items;
            slot(adjustedIndex);
        }
        else
        {
            items = inventoryUI.inventoryE.items;
            slotE(adjustedIndex - 8);
        }
        inventoryUI.RefreshUI();
    }

    public void slot(int adjustedIndex)
    {
        if (heldItem == null)
        {
            if (items[adjustedIndex] != null)
            {
                heldItem = items[adjustedIndex];
                items[adjustedIndex] = null;
                CreateHeldIcon(heldItem.Icon);
            }
        }
        else
        {
            if (items[adjustedIndex] == null)
            {
                items[adjustedIndex] = heldItem;
                heldItem = null;
                Destroy(heldIcon.gameObject);
                heldIcon = null;
            }
            else
            {
                var temp = items[adjustedIndex];
                items[adjustedIndex] = heldItem;
                heldItem = temp;
                Destroy(heldIcon.gameObject);
                CreateHeldIcon(heldItem.Icon);
            }
        }
    }
    public void slotE(int adjustedIndex)
    {
        if (heldItem == null)
        {
            if (items[adjustedIndex] != null)
            {
                heldItem = items[adjustedIndex];
                items[adjustedIndex] = null;
                CreateHeldIcon(heldItem.Icon);
            }
        }
        else
        {
            if (adjustedIndex == 0 && !heldItem.Weaponn) return;
            if (adjustedIndex == 1 && !heldItem.Armorr) return;
            if (items[adjustedIndex] == null)
            {
                items[adjustedIndex] = heldItem;
                heldItem = null;
                Destroy(heldIcon.gameObject);
                heldIcon = null;
            }
            else
            {
                if (adjustedIndex == 0 && !heldItem.Weaponn) return;
                if (adjustedIndex == 1 && !heldItem.Armorr) return;
                var temp = items[adjustedIndex];
                items[adjustedIndex] = heldItem;
                heldItem = temp;
                Destroy(heldIcon.gameObject);
                CreateHeldIcon(heldItem.Icon);
            }
        }
    }
    private void CreateHeldIcon(Sprite iconSprite)
    {
        if (iconSprite == null) return;

        heldIcon = new GameObject("HeldIcon").AddComponent<Image>();
        heldIcon.transform.SetParent(mainCanvas.transform, false);
        heldIcon.sprite = iconSprite;
        heldIcon.raycastTarget = false;
        heldIcon.rectTransform.sizeDelta = new Vector2(64, 64);
    }
}