using UnityEngine;

public class PlaySoundExit : MonoBehaviour
{
    [SerializeField] private SoundType sound;
    [SerializeField, Range(0f, 1)] private float volume = 1;
    public void OnExit(int layerIndex)
    {
        SoundManager.PlaySound(sound, volume);
    }
}
