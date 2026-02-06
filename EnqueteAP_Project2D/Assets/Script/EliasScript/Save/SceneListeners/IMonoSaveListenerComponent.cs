using System.Collections.Generic;

namespace Script.EliasScript.SceneListeners
{
    public interface IMonoSaveListenerComponent
    {
        void Write(List<ISavedProperty> properties);
        void Read(Dictionary<string, ISavedProperty> properties);
    }
}