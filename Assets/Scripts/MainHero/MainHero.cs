using Unity.VisualScripting;
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
    public GameObject inv;
    public bool right = true;
    [SerializeField] private InventoryE inventoryE;
    public ItemData currentWeapon;
    public Transform handPoint;
    private GameObject currentWeaponObject;
    private Animator animator;
    public float defence;
    private bool isArmored = false;
    public UpgradingGG upgradingGG;
    void Start()
    {
        defence = upgradingGG.GetArmor();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isArmored)
        {
            if (inventoryE.items[1] != null)
            {
                defence += inventoryE.items[1].Armor;
                isArmored = true;
            }
        }
            if (inventoryE.items[0] != null)
        {
            if (currentWeapon == null || currentWeapon != inventoryE.items[0])
            {
                currentWeapon = inventoryE.items[0];
                if (currentWeaponObject != null)
                    Destroy(currentWeaponObject);
                currentWeaponObject = Instantiate(currentWeapon.prefab, handPoint.position, handPoint.rotation, handPoint);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
            inv.SetActive(!inv.activeSelf);
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentWeaponObject != null)
            {
                currentWeaponObject.GetComponent<SwordTrigger>().PlayAttack();
            }
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        float moveInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.A)) right = false;
        if(Input.GetKeyDown(KeyCode.D)) right = true;
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        bool isRunning = moveInput != 0;
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Отразить по оси X
        }
        else if (moveInput > 0)
        {   
            transform.localScale = new Vector3(1, 1, 1); // Вернуть нормальный вид
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
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
    public void OnDestroy()
    {
        if (currentWeaponObject != null)
            Destroy(currentWeaponObject);
        currentWeapon = null;
    }
}
