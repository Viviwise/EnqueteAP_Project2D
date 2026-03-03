using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AlphaHitThresholdModifier : MonoBehaviour
{
    [SerializeField, HideInInspector] 
    private Image image;

    [SerializeField, Range(0, 1)] 
    private float threshold;


    public float Threshold
    {
        get => threshold;
        set
        {
            threshold = value;
            OnValidate();
        }
    }
    
    private void Reset()
    {
        image = GetComponent<Image>();
    }

    private void OnValidate()
    {
        if (image)
            image.alphaHitTestMinimumThreshold = threshold;
    }
}
