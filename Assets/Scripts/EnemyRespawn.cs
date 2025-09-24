using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private Transform respawnPoint;
      private GameObject currentEnemy;
    void Start()
    {
        spawnEnemy();
    }
    private void spawnEnemy()
    {
        currentEnemy = Instantiate(dog, respawnPoint.position, respawnPoint.rotation);
    }
    public void respawn()
    {
        if (currentEnemy == null)
        {
            spawnEnemy();
        }
    }
}
