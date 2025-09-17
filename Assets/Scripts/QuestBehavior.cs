using UnityEngine;

public class QuestBehavior : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    [SerializeField] private int questRequirement = 10;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textPopUp.SetActive(true);
            if (collision.GetComponent<PlayerMovement>().cherries >= questRequirement)
            {
                //update textbox
                //allow moving to next level
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textPopUp.SetActive(false);
        }
    }
}
