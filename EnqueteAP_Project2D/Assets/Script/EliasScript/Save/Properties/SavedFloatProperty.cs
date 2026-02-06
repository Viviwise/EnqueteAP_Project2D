using System;

namespace Script.EliasScript
{
    [Serializable]
    public class SavedFloatProperty : SavedProperty<float>
    {
        public SavedFloatProperty(string key, float value) : base(key, value)
        {
            
        }
    }
}