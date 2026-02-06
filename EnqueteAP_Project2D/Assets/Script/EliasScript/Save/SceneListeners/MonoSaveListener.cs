using System.Collections.Generic;
using UnityEngine;

namespace Script.EliasScript.SceneListeners
{
    public abstract class MonoSaveListener : MonoBehaviour, ISaveListener
    {
        public static List<MonoSaveListener> listeners = new List<MonoSaveListener>();


        public static void SaveAll()
        {
            foreach (var listener in listeners)
                listener.SaveListener();
        }
        
        public static void LoadAll()
        {
            foreach (MonoSaveListener listener in listeners)
                listener.LoadListener();
        }
        
        [field: SerializeField, HideInInspector]
        public string Guid { get; private set; }

        private void Reset()
        {
            Guid = System.Guid.NewGuid().ToString();
        }

        private void OnEnable()
        {
            listeners.Add(this);
        }

        private void OnDisable()
        {
            listeners.Remove(this);
        }

        void ISaveListener.Write(List<ISavedProperty> properties)
        {
            Write(properties);
        }

        void ISaveListener.Read(Dictionary<string, ISavedProperty> properties)
        {
            Read(properties);
        }

        protected abstract void Write(List<ISavedProperty> properties);
        protected abstract void Read(Dictionary<string, ISavedProperty> properties);
    }
}