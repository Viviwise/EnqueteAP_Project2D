using UnityEngine;
using UnityEngine.UI;

public class HoveredInsideBook : MonoBehaviour
{
    public Color hoverColor = Color.red;   // Couleur quand la souris est dessus

    private Color originalColor;
    public Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    void OnMouseEnter()
    {
        image.color = hoverColor;
    }

    void OnMouseExit()
    {
        image.color = originalColor;
    }
}
