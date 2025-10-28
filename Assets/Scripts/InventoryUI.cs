using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public InventoryE inventoryE;
    public Image[] slotIcons;
    public TMP_Text[] slotCounts;
    void Start()
    {
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < 8; i++)
        {
                 var item = inventory.items[i];
            if (item != null && item.Icon != null)
            {
                slotIcons[i].sprite = item.Icon;
                slotIcons[i].color = new Color(1, 1, 1, 1);
                slotCounts[i].text = item.Countable ? item.Count.ToString() : "";
            }
            else
            {
                slotIcons[i].sprite = null;
                slotIcons[i].color = new Color(1, 1, 1, 0);
                slotCounts[i].text = "";
            }
        }
        for(int j = 0; j < 2; ++j)
        {
            var item = inventoryE.items[j];
            if (item != null && item.Icon != null)
            {
                slotIcons[j + 8].sprite = item.Icon;
                slotIcons[j + 8].color = new Color(1, 1, 1, 1);
            }
            else
            {
                slotIcons[j + 8].sprite = null;
                slotIcons[j + 8].color = new Color(1, 1, 1, 0);
            }
        }
    }
}
