using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void showCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void closeCredits()
    {
        creditsPanel.SetActive(false);
    }
}
