using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyState currentState;  
    [SerializeField] private MobData mob;
    public int currentHealth;
    public Rigidbody2D rb;
    public float obstacleCheckDistance = 0.3f;
    public float jumpPower = 5f;
    public LayerMask groundLayer;
    private CapsuleCollider2D col;
    GameObject PlayerObject;
    public float timer = 0f;
    public bool isgrounded;
    public float rayLength = 0.5f;
    [SerializeField] private Transform groundCheck;
    void Awake()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        currentHealth = mob.maxHealth;
        currentState = new EnemyIdleState(this, mob, PlayerObject.transform);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        currentState?.Update();
        timer += Time.deltaTime;
    }
    public void ChangeState(EnemyState newstate)
    {
        currentState?.Exit();
        currentState = newstate;
        currentState?.Enter();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{mob.mobName} took {damage} damage! HP left: {currentHealth}");

        if (currentHealth <= 0)
        {
            ChangeState(new EnemyDieState(this));
        }
    }

    public void Die()
    {
        Debug.Log($"{mob.mobName} has died!");
        Destroy(gameObject);    
    }
    public bool CanSeePlayer()
    {
        float distance = Vector2.Distance(transform.position, PlayerObject.transform.position);
        if (distance < mob.detectionRadius)
        {
            return true;
        }
        return false;
    }
    public bool IsGrounded()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        isgrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
        return isgrounded;
    }
    public bool HasObstacle(float dir)
    {
        Vector2 wallCheckPos = new Vector2(
    col.bounds.center.x + 0.3f * dir,
    col.bounds.min.y + 0.1f // ×ÓÒÜ âûøå íîã
);
        return Physics2D.Raycast(wallCheckPos, Vector2.right * dir, rayLength, groundLayer);
    }
    public bool CeilingAbove()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x, col.bounds.max.y), Vector2.up, 0.1f, groundLayer);   
    }
    public float GetObstacleHeight(float dir)
    {
        Vector2 wallCheckPos = new Vector2(
    col.bounds.center.x + 0.3f * dir,
    col.bounds.min.y + 0.1f // ×ÓÒÜ âûøå íîã
);
        RaycastHit2D hit = Physics2D.Raycast(wallCheckPos, Vector2.right * dir, rayLength, groundLayer);
        if (hit.collider == null) return 0;
            float obstacleTop = hit.collider.bounds.max.y;
            float myFeet = col.bounds.min.y;

            float height = obstacleTop - myFeet;

            return height;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 wallCheckPos = (Vector2)transform.position + new Vector2(0.3f, -0.9f);
        Gizmos.DrawLine(wallCheckPos, wallCheckPos + Vector2.right * obstacleCheckDistance);
        Gizmos.color = Color.black;
        Gizmos.DrawCube(wallCheckPos, new Vector3(0.1f, 0.1f, 0.1f));
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(timer < 1.5f) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            timer = 0f;
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(mob.damage);
            Debug.Log($"{mob.mobName} dealt {mob.damage} damage to Player!");
        }
    }
}
