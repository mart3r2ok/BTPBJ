using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    public float DisappearTimer = 1f;
    private Color textColor;
    private Vector3 moveDir;
    private float moveSpeed;
    [SerializeField] private TextMeshPro text;
    public void Setup(float damage)
    {
        text.SetText(damage.ToString());
        textColor = text.color;

        moveDir = (Vector3.up + new Vector3(
            Random.Range(-0.3f, 0.3f),
            Random.Range(0f, 0.2f),
            0
        )).normalized;

        moveSpeed = 4f;
    }
    public void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        moveSpeed *= 0.97f;
        DisappearTimer -= Time.deltaTime;
        if(DisappearTimer < 0)
        {
            textColor.a -= 2f * Time.deltaTime;
            text.color = textColor;

            if (textColor.a <= 0f)
                Destroy(gameObject);
        }
    }
}
