using UnityEngine;

public class HoveredBook : MonoBehaviour
{
    public Color hoverColor = Color.red;   // Couleur quand la souris est dessus

    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }
}
