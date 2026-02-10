using UnityEngine;

public class PlaySoundEnter : MonoBehaviour
{

    [SerializeField] private SoundType sound;
    [SerializeField, Range(0f, 1)] private float volume = 1;
    public void OnUsed(int layerIndex)
    {
        SoundManager.PlaySound(sound, volume);
    }
}
