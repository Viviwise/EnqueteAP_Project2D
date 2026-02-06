using System;

namespace Script.EliasScript
{
    [Serializable]
    public class SavedIntProperty : SavedProperty<int>
    {
        public SavedIntProperty(string key, int value) : base(key, value)
        {
            
        }
    }
}