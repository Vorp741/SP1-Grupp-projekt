using System.Collections;
using UnityEngine;

public class BoostBehavior : MonoBehaviour
{
    //private CircleCollider2D hitbox;
    private Animator anims;
    private bool active;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hitbox = GetComponent<CircleCollider2D>();
        anims = GetComponent<Animator>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        anims.SetBool("Enabled", active);
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {

    }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(EnableAndDisable(hitbox));
            print("trigger");
            active = false;
            if (collision.transform.position.x > transform.position.x)
            {
                collision.gameObject.GetComponent<PlayerMovement>().boostVelocity(-500f, 1000f);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().boostVelocity(500f, 1000f);
            }
            Invoke("reactivate", 0.7f);
        }
    }
    private void reactivate()
    {
        active = true;
    }
    /*IEnumerator EnableAndDisable(CircleCollider2D collider)
    {
        yield return new WaitForSeconds(1);
        active = false;
        collider.gameObject.SetActive(active);
        yield return new WaitForSeconds(5);
        active = true;
        collider.gameObject.SetActive(active);
    }*/
    // fågel
}
