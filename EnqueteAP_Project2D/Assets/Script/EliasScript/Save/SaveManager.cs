using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

namespace Script.EliasScript
{
    public static class SaveManager
    {
        //class static = 1 unique dans le projet 
        // attention ! toutes les méthodes dervont etre en STATIC

        // permet de lancer un méthode direct car unique dans le projet
        //utilitaire => les dictionnaires sont pas nécessaires mais permettent de voir les différentes valeurs 

        private static readonly Dictionary<string, SaveElement> elements = new();

        public static void SaveListener(this ISaveListener listener)
        {
            using (ListPool<ISavedProperty>.Get(out var list))
            {
                listener.Write(list);
                SaveElement element = new SaveElement()
                {
                    guid = listener.Guid,
                    properties = list.ToArray()
                };

                elements[listener.Guid] = element;
            }
        }

        public static bool LoadListener(this ISaveListener listener)
        {
            using (DictionaryPool<string, ISavedProperty>.Get(out var dic))
            {
                if (elements.TryGetValue(listener.Guid, out SaveElement element))
                {
                    foreach (var p in element.properties)
                        dic.Add(p.Key, p);

                    listener.Read(dic);
                    return true;
                }
            }

            return false;
        }

        public static void RemoveListener(ISaveListener listener)
        {
            elements.Remove(listener.Guid);
        }


        public static void Push()
        {
            SaveFile file = new SaveFile()
            {
                elements = new List<SaveElement>()
            };
            foreach ((string guid, SaveElement saveElement) in elements)
                file.elements.Add(saveElement);

            string json = JsonUtility.ToJson(file);
            Debug.Log($"Pushed : {json}");
            PlayerPrefs.SetString("SavedFile", json);
            PlayerPrefs.Save();
        }

        public static void Pull()
        {
            string json = PlayerPrefs.GetString("SavedFile");
            Debug.Log($"Pulled : {json}");
            SaveFile file = JsonUtility.FromJson<SaveFile>(json);
            elements.Clear();

            foreach (SaveElement element in file.elements)
                elements.Add(element.guid, element);
        }
    }
}