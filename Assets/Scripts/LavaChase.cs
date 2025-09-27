using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaChase : MonoBehaviour
{
    public Transform cameraTransform;
    public float offsetBehindCamera = 8f; // how far behind camera lava should stay
    public float chaseSpeed = 2.5f;       // lava speed

    private float targetX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetX = cameraTransform.position.x - offsetBehindCamera;

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reload current scene when player touches lava
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

