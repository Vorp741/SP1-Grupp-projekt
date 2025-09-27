using UnityEngine;
using UnityEngine.UI;

public class MovingBackgroundMenu : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float eggs, zedd;
    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(eggs, zedd) * Time.deltaTime, background.uvRect.size);
    }
}
