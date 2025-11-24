using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        gameObject.SetActive(dist < 60f);
    }
}
