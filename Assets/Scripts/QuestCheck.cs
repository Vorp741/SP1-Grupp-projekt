using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestCheck : MonoBehaviour

{
    [SerializeField] private GameObject dialogueBox, finsishedText, unfinishedText;
    [SerializeField] private int questObjective = 10;
    [SerializeField] private int nextLevel;
    private bool isLoading = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>().cherries >= questObjective)
            {
                unfinishedText.SetActive(false);
                finsishedText.SetActive(true);
                dialogueBox.SetActive(true);
                isLoading = true;
                Invoke("loadNextLevel", 2f);
            }
            else
            {
                unfinishedText.SetActive(true);
                dialogueBox.SetActive(true);
            }
        }
    }
    private void loadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isLoading == false)
        {
                unfinishedText.SetActive(false);
                finsishedText.SetActive(false);
                dialogueBox.SetActive(false);
        }
    }
}
