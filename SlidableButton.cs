using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class SlidableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Sprite notPressedSprite;
    public Sprite pressedSprite;
    
    Image image;

    bool isButtonDown = false;

    bool isPointerDown = false;
    bool isPointerIn = false;

    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;

    public void Start()
    {
        image = GetComponent<Image>();
        notPressedSprite = image.sprite;
    }

    void UpdateState()
    {
        if (!isPointerDown || !isPointerIn)
        {
            image.sprite = notPressedSprite;
            if (isButtonDown)
            {
                onButtonUp.Invoke();
                isButtonDown = false;
            }
            return;
        }
        image.sprite = pressedSprite;
        if (!isButtonDown)
        {
            onButtonDown.Invoke();
            isButtonDown = true;
        }
    }

    public void OnPointerEnter(PointerEventData ev)
    {
        isPointerIn = true;
        UpdateState();
    }

    public void OnPointerExit(PointerEventData ev)
    {
        isPointerIn = false;
        UpdateState();
    }

    public void OnGroupPointerDown()
    {
        isPointerDown = true;
        UpdateState();
    }

    public void OnGroupPointerUp()
    {
        isPointerDown = false;
        UpdateState();
    }
}