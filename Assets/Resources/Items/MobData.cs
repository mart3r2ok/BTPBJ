using UnityEngine;

[CreateAssetMenu(fileName = "New Mob", menuName = "Inventory/Mob")]
public class MobData : ScriptableObject
{
    [Header("Base stats")]
    public string mobName;
    public int maxHealth;
    public int damage;
    public float speed;
    public MobType classification;

    public enum MobType
    {
        Passive,
        Neutral,
        Hostile
    }
}