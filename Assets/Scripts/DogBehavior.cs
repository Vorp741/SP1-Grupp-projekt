
using Unity.Mathematics;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float bounceForce = 6000f;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider2d;
    private CapsuleCollider2D capCollider2d;
    [SerializeField] private GameObject deathParticles;
    private Animator anims;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
        capCollider2d = GetComponent<CapsuleCollider2D>();
        anims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);
        anims.SetFloat("horizontalSpeed", math.abs(moveSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBlock"))
        {
            moveSpeed = -moveSpeed;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            moveSpeed = -moveSpeed;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().takeDamage(1);
            if (collision.transform.position.x > transform.position.x)
            {
                collision.gameObject.GetComponent<PlayerMovement>().rgbd.linearVelocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<PlayerMovement>().takeKnockback(250f, 500f);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().rgbd.linearVelocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<PlayerMovement>().takeKnockback(-250f, 500f);
            }
        }

        if (moveSpeed < 0)
        {
            collider2d.offset = new Vector2(-0.2f, -0.2f);
            capCollider2d.offset = new Vector2(-0.2f, capCollider2d.offset.y);
            spriteRenderer.flipX = false;
        }
        else
        {
            collider2d.offset = new Vector2(0.2f, -0.2f);
            capCollider2d.offset = new Vector2(0.2f, capCollider2d.offset.y);
            spriteRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerMovement>().isGrounded() == false && other.GetComponent<Rigidbody2D>().linearVelocityY < math.abs(1))
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce));
            Instantiate(deathParticles, gameObject.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}
