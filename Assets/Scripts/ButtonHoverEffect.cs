using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private Vector3 originalScale;

    public Color hoverColor = Color.yellow;
    private Color originalColor;

    void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData) //If the mouse is above the button it will change color and the size
    {
        image.color = hoverColor;
        transform.localScale = originalScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData) //If the mouse left the button it will return to its orignal state. 
    {
        image.color = originalColor;
        transform.localScale = originalScale;
    }
}
