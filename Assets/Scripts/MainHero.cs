using UnityEngine;

public class MainHero : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;
    public float jumpForce = 10f;
    public float speed = 4f;
    public Vector2 checkSize = new Vector2(0.9f, 0.1f);
    private Animator animator;
    public GameObject inv;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inv.SetActive(!inv.activeSelf);
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        bool isRunning = moveInput != 0;
        animator.SetBool("isMoving", isRunning);
    }
    void TryInteract()
    {
        float interactRadius = 1f;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        foreach (var hitCollider in hitColliders)
        {
                IInteractable interactable = hitCollider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    break;
                }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, checkSize);
    }
}
