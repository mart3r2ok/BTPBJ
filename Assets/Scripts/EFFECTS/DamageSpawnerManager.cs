using UnityEngine;
using UnityEngine.UIElements;

public class DamageSpawnerManager : MonoBehaviour
{
    public static DamageSpawnerManager Instance { get; private set; }

    [SerializeField] private DamagePopup popupPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SpawnPopup(Vector3 position, int damage)
    {
        DamagePopup popup = Instantiate(popupPrefab, position, Quaternion.identity);
        popup.Setup(damage);
    }
}