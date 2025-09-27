using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public Transform player;
    public float yOffset = 0f;
    public float smoothY = 0.2f;

    private float velocityY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x + scrollSpeed * Time.deltaTime;

        float targetY = player.position.y + yOffset;
        float newY = Mathf.SmoothDamp(transform.position.y, targetY, ref velocityY, smoothY);

        transform.position = new Vector3(newX, newY, transform.position.z);
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}
