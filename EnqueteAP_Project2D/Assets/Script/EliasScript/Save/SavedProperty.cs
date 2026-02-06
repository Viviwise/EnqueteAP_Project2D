using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.EliasScript
{
    [Serializable]
    public class SavedProperty<T> : ISavedProperty
    {
        object ISavedProperty.ValueAsObject => Value;
        
        [field: SerializeField]
        public string Key { get; private set; }
        
        [field: SerializeField]
        public T Value { get; private set; }
        
        public SavedProperty(string key, T value)
        {
            this.Value = value;
            Key = key;
        }
    }
}