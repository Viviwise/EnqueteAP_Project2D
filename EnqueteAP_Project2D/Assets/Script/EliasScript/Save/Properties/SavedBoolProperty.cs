using System;

namespace Script.EliasScript
{
    [Serializable]
    public class SavedBoolProperty : SavedProperty<bool>
    {
        public SavedBoolProperty(string key, bool value) : base(key, value)
        {
            
        }
    }
}