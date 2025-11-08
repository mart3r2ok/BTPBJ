using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public bool Countable, Weaponn, Armorr;
    public int Count = 1;
    public ItemType Type;
    public int Damage;
    public int Armor;
    public int HealAmount;
    public float Range;
    public float AttackCooldown;
    public float AttackRadius;
    public string rarity;
    public GameObject prefab;
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        WeaponSword,
        Material,
        Other,
        KeyItem,
        Armor,
        WeaponBow,
        WeaponGun
    }
}