using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    
        [SerializeField] private Transform target1, target2;
        [SerializeField] private float moveSpeed = 2.0f;
        private bool isMoving = false;

        private Rigidbody2D rgbd;
        private Transform currentTarget;



        void Start()
        {
            rgbd = GetComponent<Rigidbody2D>();
            currentTarget = target1;

        }


        //void FixedUpdate()
        private void FixedUpdate()
        {
            if (isMoving)
            {
                if (transform.position == target1.position)
                {
                    currentTarget = target2;
                }
                /* if (transform.position == target2.position)
                 {
                     currentTarget = target1;
                 }*/
            }

            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Player"))
            {
                isMoving = true;
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y)
            {
                other.transform.SetParent(transform);
            }
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }
    }

