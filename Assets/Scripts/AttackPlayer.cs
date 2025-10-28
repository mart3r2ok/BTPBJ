using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public InventoryE inventoryE;
    public Transform attackplace;
    public GameObject[] swordSlashPrefabs;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inventoryE.items[0] != null)
        {
            TryAttack(inventoryE.items[0]);
        }
    }
    public void TryAttack(ItemData weapon)
    {
        /*
         if(weapon.Type == WeaponSword) { 
        GameObject slashPrefab = GetSlashByRarity(weapon.rarity);
        GameObject slash = Instantiate(slashPrefab, attackplace.position, attackplace.rotation);
        Destroy(slash, 0.3f);
        */
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackplace.position, weapon.Range);
        foreach (var hit in hits)
        {
            Vector2 dir = hit.transform.position - attackplace.position;
            float angle = Vector2.Angle(transform.right, dir);

            if (angle < 60f) // полукруг перед игроком
            {
                var enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(weapon.Damage);
                }
            }
        }

     //   }
    }
    private void OnDrawGizmosSelected()
    {
        if(inventoryE.items[0] == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackplace.position, inventoryE.items[0].Range);
    }
}
