using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] private float currentHealth;
    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage - gameObject.GetComponent<MainHero>().defence;
        Debug.Log($"Player took {damage}, but {gameObject.GetComponent<MainHero>().defence} damage was reduced");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Player has died.");
        // Continue with death handling logic here
    }
}
