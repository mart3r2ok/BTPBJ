using Unity.VisualScripting;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    private Animator animator;
    public float attackCooldown;
    bool isAttacking = false;   
    void Update()
    {
        attackCooldown = GameObject.FindWithTag("Player").GetComponent<AttackPlayer>().attackCooldown;
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking && attackCooldown <= 0)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
    }
    public void EndAttack()
    {
        isAttacking = false;
    }
}
