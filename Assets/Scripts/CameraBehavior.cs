using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -20f);
    [SerializeField] private float smoothing = 1.0f;
    void LateUpdate()
    {
        Vector3 camPosition = Vector3.Lerp(transform.position, player.position + offset, smoothing * Time.deltaTime);
        transform.position = camPosition;
    }
}
