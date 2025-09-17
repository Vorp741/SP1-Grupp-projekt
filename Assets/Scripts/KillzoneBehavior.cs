using UnityEngine;

public class KillzoneBehavior : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    void OnTriggerEnter2D(Collider2D entered)
    {
        if (entered.CompareTag("Player"))
        {
            entered.transform.position = spawnPoint.position;
            entered.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        }
    }
}
