using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SwordDamage : MonoBehaviour
{
    public InventoryE inventoryE;
    public bool icandealdamage = false;
    public Collider2D swordCollider;
    private readonly HashSet<IDamageable> _hitThisSwing = new();
    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        inventoryE = FindFirstObjectByType<InventoryE>().GetComponent<InventoryE>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!icandealdamage) return;
        if (!other.TryGetComponent<IDamageable>(out var dmg)) return;
        if (!_hitThisSwing.Add(dmg)) return;

        dmg.TakeDamage(inventoryE.items[0].Damage);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!icandealdamage) return;

        if (!other.TryGetComponent<IDamageable>(out var dmg)) return;
        if (!_hitThisSwing.Add(dmg)) return;

        dmg.TakeDamage(inventoryE.items[0].Damage);
    }
    public void EnableDamage()
    {
        _hitThisSwing.Clear();
        icandealdamage = true;
    }

    public void DisableDamage()
    {
        icandealdamage = false;
    }
}
