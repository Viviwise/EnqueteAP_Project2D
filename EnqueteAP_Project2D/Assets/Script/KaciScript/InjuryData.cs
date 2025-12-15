using UnityEngine;

namespace Script.KaciScript
{
    [CreateAssetMenu(fileName = "Corpse", menuName = "hurt", order = 0)]
    public class InjuryData : ScriptableObject
    {
        public string injuryName;
    }
}