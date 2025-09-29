using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineNoQuest : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float delay = 3f;
    [SerializeField] private bool isTriggered = false;
    [SerializeField] private GameObject cameraChanger;
   // public Behaviour cameraScriptToDisable;
   // public Behaviour cameraScriptToEnable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(LoadSceneAfterDelay());

            cameraChanger.GetComponent<CameraAutoScroll>().enabled = false;
            cameraChanger.GetComponent<CameraBehavior>().enabled = true;

            //if (cameraScriptToDisable != null)
            //      cameraScriptToDisable.enabled = false;
            //
            //   if (cameraScriptToEnable != null)
            //  cameraScriptToEnable.enabled = true;
        }



    }
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
