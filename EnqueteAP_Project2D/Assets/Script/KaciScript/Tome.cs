using UnityEngine;
using UnityEngine.UI;

public class Tome : MonoBehaviour
{

    public SpriteRenderer spriteRenderer; 

    public Image image; 
    
    public Sprite[] sprites; 
    

    public Button nextButton;
    public Button previousButton; 
    
    private int currentIndex = 0;
    
    void Start()
    {
        if (sprites.Length == 0)
        {
            return;
        }
        
        UpdateSprite();
        
        if (nextButton != null)
            nextButton.onClick.AddListener(NextSprite);
            
        if (previousButton != null)
            previousButton.onClick.AddListener(PreviousSprite);
    }
    
    public void NextSprite()
    {
        currentIndex++;
        
        if (currentIndex >= sprites.Length)
            currentIndex = 0;
            
        UpdateSprite();
    }
    
    public void PreviousSprite()
    {
        currentIndex--;
        
        if (currentIndex < 0)
            currentIndex = sprites.Length - 1;
            
        UpdateSprite();
    }
    
    void UpdateSprite()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = sprites[currentIndex];
            
        if (image != null)
            image.sprite = sprites[currentIndex];
            
    }
}