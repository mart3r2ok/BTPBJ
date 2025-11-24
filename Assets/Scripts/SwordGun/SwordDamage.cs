using UnityEngine;
using UnityEngine.Rendering;

public class SwordDamage : MonoBehaviour
{
    public InventoryE inventoryE;
    public int damageAmount;
    public bool icandealdamage = false;
    void Start()
    {
        inventoryE = FindFirstObjectByType<InventoryE>().GetComponent<InventoryE>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!icandealdamage) return;
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(inventoryE.items[0].Damage);
            }
    }
    public void EnableDamage()
    {
        icandealdamage = true;
    }

    public void DisableDamage()
    {
        icandealdamage = false;
    }
}
