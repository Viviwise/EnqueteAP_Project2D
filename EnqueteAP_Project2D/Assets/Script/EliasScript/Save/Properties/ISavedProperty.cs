using UnityEngine;

public interface ISavedProperty
{
    string Key { get; }
    object ValueAsObject { get; }
    //juste tag pour spécifier 
    //ici utiliser pour récup int, float et string 
}
