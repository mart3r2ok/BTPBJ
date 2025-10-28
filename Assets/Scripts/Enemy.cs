using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mob mob;
    private int currentHealth;

    void Start()
    {
        currentHealth = mob.data.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{mob.data.mobName} took {damage} damage! HP left: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{mob.data.mobName} has died!");
        Destroy(gameObject);
    }
}
