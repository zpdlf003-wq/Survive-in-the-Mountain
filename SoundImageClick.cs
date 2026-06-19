using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundImageClick : MonoBehaviour, IPointerClickHandler
{
    public Sprite soundOnImage;
    public Sprite soundOffImage;

    private Image img;
    private bool isSoundOn = true;

    void Start()
    {
        img = GetComponent<Image>();

        if (img != null)
        {
            img.sprite = soundOnImage;
        }

        AudioListener.volume = 1f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            img.sprite = soundOnImage;
            AudioListener.volume = 1f;
        }
        else
        {
            img.sprite = soundOffImage;
            AudioListener.volume = 0f;
        }
    }
}