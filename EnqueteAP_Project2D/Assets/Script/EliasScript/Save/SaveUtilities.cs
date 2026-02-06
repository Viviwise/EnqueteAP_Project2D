using System.Collections.Generic;

namespace Script.EliasScript
{
    public static class SaveUtilities
    {
        public static bool TrySetValue<T>(this Dictionary<string, ISavedProperty> dictionary, string key, 
            out T value, T defaultValue = default)
        {
            if (dictionary.TryGetValue(key, out ISavedProperty property))
                return property.TrySetValue(out value, defaultValue);

            value = defaultValue;
            return false;
        }
        
        public static bool TrySetValue<T>(this ISavedProperty property, out T value, T defaultValue = default)
        {
            if (property is SavedProperty<T> generic)
            {
                value = generic.Value;
                return true;
            }
            
            value = default;
            return false;
        }

    }
}