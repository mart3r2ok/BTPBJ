using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New Mob", menuName = "Inventory/Mob")]
public class MobData : ScriptableObject
{
    [Header("Base stats")]
    public string mobName;
    public int maxHealth;
    public int damage;
    public float speed;
    public float detectionRadius;
    public float AttackCooldown;
    public float jumpPower;
    [Header("Classification")]
    public MobType classification;

    public enum MobType
    {
        Passive,
        Neutral,
        Hostile
    }
}