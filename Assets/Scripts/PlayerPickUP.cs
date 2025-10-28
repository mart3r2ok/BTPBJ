using UnityEngine;

public class PlayerPickUP : MonoBehaviour
{
    public float pickUpRange = 1.5f;
    public KeyCode pickUpKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(pickUpKey))
            TryPickUP();
    }
    public void TryPickUP()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pickUpRange);
        foreach (var hit in hits)
        {
            Item item = hit.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.data);
                Destroy(hit.gameObject);
                break;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
