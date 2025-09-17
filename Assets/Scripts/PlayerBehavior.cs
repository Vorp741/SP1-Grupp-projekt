using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalValue;
    private Rigidbody2D rgbd;
    private SpriteRenderer spriteRenderer;
    private Animator anims;
    [SerializeField] private float moveSpeed = 325f;
    [SerializeField] private float jumpHeight = 750f;
    [SerializeField] private Transform LeftFoot, RightFoot;
    [SerializeField] private LayerMask identifyGround;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text cherryCount;
    [SerializeField]
    private GameObject cherryParticles, dustParticles;
    [SerializeField] private AudioClip cherrySfx, jumpSfx, boostSfx; //Jag vet hur arrays fungerar, valde att inte använda en.
    private int startingHealth = 3;
    private int currentHealth = 0;
    public int cherries = 0;
    private bool grounded;
    private bool stunned;
    // hello world
 
    private AudioSource audioSource;
    private float rayDistance = 0.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cherryCount.text = "" + cherries;
        stunned = false;
        currentHealth = startingHealth;
        audioSource = GetComponent<AudioSource>();
        rgbd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        //print(horizontalValue);
        FlipFlopgwrovnheriberjgpppfoveghne();

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
        anims.SetFloat("moveSpeed", Mathf.Abs(rgbd.linearVelocityX));
        anims.SetFloat("vertSpeed", rgbd.linearVelocityY);
        anims.SetBool("isGrounded", isGrounded());
        anims.SetBool("isStunned", stunned);

    }
    private void FixedUpdate()
    {
        if (stunned == true)
        {
            return;
        }
        rgbd.linearVelocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rgbd.linearVelocityY);
        /*if (math.abs(rgbd.linearVelocityX) > 1 && isGrounded() == true)
        {
            dustParticles.SetActive(true);
        }
        else
        {
            dustParticles.SetActive(false);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cherry"))
        {
            audioSource.pitch = Random.Range(0.975f, 1.1f);
            audioSource.PlayOneShot(cherrySfx, 0.025f);
            Destroy(collision.gameObject);
            cherries++;
            cherryCount.text = "" + cherries;
            Instantiate(cherryParticles, collision.transform.position, quaternion.identity);
        }
        if (collision.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            if (currentHealth == startingHealth)
            {
                cherries += 5;
                cherryCount.text = "" + cherries;
            }
            else
            {
                currentHealth++;
                healthBar.value++;
            }
        }
        if (collision.CompareTag("Boost"))
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(boostSfx, 0.025f);
            rgbd.linearVelocity = new Vector2(rgbd.linearVelocityX, 0);
        }
    }

    private void FlipFlopgwrovnheriberjgpppfoveghne()
    {
        if (horizontalValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontalValue > 0) { spriteRenderer.flipX = false; }
    }
    private void Jump()
    {
        audioSource.pitch = Random.Range(0.95f, 1.1f);
        audioSource.PlayOneShot(jumpSfx, 0.025f);
        rgbd.AddForce(new Vector2(0, jumpHeight));
    }
    public bool isGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftFoot.position, Vector2.down, rayDistance, identifyGround);
        RaycastHit2D rightHit = Physics2D.Raycast(RightFoot.position, Vector2.down, rayDistance, identifyGround);

        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || rightHit.collider != null && rightHit.collider.CompareTag("Ground"))
        {
            return true;
        }
        else { return false; }
    }
    public void takeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            respawn();
        }
    }

    public void takeKnockback(float knockbackForceX, float knockbackForceY)
    {
        stunned = true;
        rgbd.AddForce(new Vector2(knockbackForceX, knockbackForceY));
        Invoke("unstunned", 0.5f);
    }
    public void boostVelocity(float boostForceX, float boostForceY)
    {
        rgbd.AddForce(new Vector2(boostForceX, boostForceY));
    }
    private void respawn()
    {
        currentHealth = startingHealth;
        healthBar.value = currentHealth;
        transform.position = spawnPos.position;
        rgbd.linearVelocity = new Vector2(0, 0);
    }
    private void unstunned()
    {
        stunned = false;
    }
}
