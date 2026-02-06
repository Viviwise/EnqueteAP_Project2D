using System;
using System.Collections.Generic;

namespace Script.EliasScript.SceneListeners
{
    public class EmptyMonoSaveListener : MonoSaveListener
    {
        private IMonoSaveListenerComponent[] components;

        private void Awake()
        {
            components = GetComponents<IMonoSaveListenerComponent>();
        }

        protected override void Write(List<ISavedProperty> properties)
        {
            for (var i = 0; i < components.Length; i++)
            {
                IMonoSaveListenerComponent component = components[i];
                component.Write(properties);
            }
        }

        protected override void Read(Dictionary<string, ISavedProperty> properties)
        {
            for (var i = 0; i < components.Length; i++)
            {
                IMonoSaveListenerComponent component = components[i];
                component.Read(properties);
            }
        }
    }
}