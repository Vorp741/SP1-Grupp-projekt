using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform targetA;
    [SerializeField] private float tweenSpeed;
    private Transform currentTarget;
    void Start()
    {
        currentTarget = targetA;
    }


    void FixedUpdate()
    {

        if (transform.position == targetA.position)
        {
            tweenSpeed = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, tweenSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}

