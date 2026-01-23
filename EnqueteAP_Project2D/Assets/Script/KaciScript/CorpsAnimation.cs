using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.KaciScript
{
    public class CorpsAnimation : MonoBehaviour ,IPointerClickHandler 
    {
        public Animator animator;
        public Image image;
        public SpriteRenderer newSprite;
        public void OnPointerClick(PointerEventData eventData)
        {
            
            image.sprite = newSprite.sprite;
        }
    }
}

