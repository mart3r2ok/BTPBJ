using UnityEngine;

public class ItemPickUP : MonoBehaviour
{
    public ItemData item;
    private bool isPlayerInRange = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = false;
    }
    private void Update()   
    {
        Pickup();
    }
    private void Pickup()
    {
        Inventory inventory = FindFirstObjectByType<Inventory>();
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory != null && item != null)
            {
                inventory.AddItem(item);
                Destroy(gameObject);
            }
            }
    }
}
   