using System;

namespace Script.EliasScript
{
    [Serializable]
    public class SavedStringProperty : SavedProperty<string>
    {
        public SavedStringProperty(string key, string value) : base(key, value)
        {
        }
    }
}