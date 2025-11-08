using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private InventoryE inventoryE;
    public Transform attackplaceR, attackplaceL;
    public GameObject[] swordSlashPrefabs;
    public float attackCooldown = 0;
    public MainHero mainHero;
    public float transformYAdjust = 0.2f;
    public float transformXAdjust = 0.5f;
    private Transform attackplace
    {
        get
        {
            MainHero mainHero = GetComponent<MainHero>();
            return mainHero.right ? attackplaceR : attackplaceL;
        }
    }
    void Start()
    {
        mainHero = GetComponent<MainHero>();
    }
    void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && inventoryE.items[0] != null && attackCooldown <= 0)
        { 
            TryAttack(inventoryE.items[0]);
            attackCooldown = inventoryE.items[0].AttackCooldown;
        }
    }
    public void TryAttack(ItemData weapon)
    {
        if (weapon.Type == ItemData.ItemType.WeaponSword)
        {
            /*
            GameObject slashPrefab = GetSlashByRarity(weapon.rarity);
            GameObject slash = mainHero.right
    ? Instantiate(slashPrefab,
        new Vector3(attackplaceR.position.x + transformXAdjust, attackplaceR.position.y - transformYAdjust, attackplaceR.position.z),
        attackplaceR.rotation)
    : Instantiate(slashPrefab,
        new Vector3(attackplaceL.position.x - transformXAdjust, attackplaceL.position.y - transformYAdjust, attackplaceL.position.z),
        attackplaceL.rotation);
            */
        }
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackplace.position, weapon.Range);
        foreach (var hit in hits)
        {
            Vector2 dir = hit.transform.position - attackplace.position;
            float angle = mainHero.right ? Vector2.Angle(transform.right, dir) : Vector2.Angle(-transform.right, dir);

            if (angle < 60f) // полукруг перед игроком
            {
                var enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(weapon.Damage);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(inventoryE.items[0] == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackplace.position, inventoryE.items[0].Range);
    }
    private GameObject GetSlashByRarity(string rarity)
    {
        switch (rarity)
        {
            case "Common":
                return swordSlashPrefabs[0];
            case "Uncommon":
                return swordSlashPrefabs[1];
            case "Rare":
                return swordSlashPrefabs[2];
            case "Epic":
                return swordSlashPrefabs[3];
            case "Legendary":
                return swordSlashPrefabs[4];
            default:
                return swordSlashPrefabs[0];
        }
    }
}
