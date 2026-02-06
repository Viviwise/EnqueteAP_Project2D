using System.Collections.Generic;

namespace Script.EliasScript
{
    public interface ISaveListener
    {
        string Guid { get; }

        void Write(List<ISavedProperty> properties);
        
        void Read(Dictionary<string, ISavedProperty> properties);
    }
}