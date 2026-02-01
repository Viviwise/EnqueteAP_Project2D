using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.EliasScript
{
    public static class SavedManager
    {
        //class static = 1 unique dans le projet 
        // attention ! toutes les méthodes dervont etre en STATIC
        
        // permet de lancer un méthode direct car unique dans le projet

        //utilitaire => les dictionnaires sont pas nécessaires mais permettent de voir les différentes valeurs 
        private static readonly Dictionary<String, String> savedStrings = new Dictionary<string, string>();
        private static readonly Dictionary<String, int> savedInts = new Dictionary<string, int>();
        private static readonly Dictionary<String, float> savedFloats = new Dictionary<string, float>();
        
        
        
        
        //<T> generic = permet que les codes en lien parle entre eux par cascade 
        public static void Saved<T> (this T savedElement) where T : ISavedElement
        {
            switch (savedElement)
            {
                //case = : 
                case ISavedStringElement savedString:
                {
                    foreach ((String key, String value) in savedString.SavedStrings)
                    {
                        Debug.Log($"key{key}, value{value}");
                        PlayerPrefs.SetString($"string_{key}", value);
                        //au cas où, tu sauvegardes dans le dictionnaire
                        savedStrings[key] = value;
                    }
                    //break = permet de sortir du case dès que fini
                    break;
                }
                case ISavedIntElement savedInt:
                {
                    foreach ((String key, int value) in savedInt.SavedInts)
                    {
                        Debug.Log($"key{key}, value{value}");
                        PlayerPrefs.SetInt($"int_{key}", value);
                        //savedInts = le dictionnaire
                        savedInts[key] = value;
                    }
                    break;
                }
                case ISavedFloatElement savedFloat:
                {
                    foreach ((String key, float value) in savedFloat.SavedFloats)
                    {
                        Debug.Log($"key{key}, value{value}");
                        PlayerPrefs.SetFloat($"float_{key}", value);
                        savedFloats[key] = value;
                    }
                    break;
                }
            }
        }

        
        
        //trois méthodes de LOAD en fonction de chaque paramètre (string, float, int)
        public static string LoadString(string key)
        {
            //douane = si il n'y a rien dans PlayerPrefs, alors rien. Sinon, on lance la save
            if (!PlayerPrefs.HasKey(key))
            {
                //Debug.LogError = debug rouge type error
                Debug.LogError($"Key string not found");
                return null;
            }
            return PlayerPrefs.GetString($"string_{key}");
        }
        
        public static int LoadInt(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"Key string not found");
                //technique obscur car int n'est pas une classe (return null = class)
                return -1;
            }
            return PlayerPrefs.GetInt($"int_{key}");
        }
        
        public static float LoadFloat(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"Key string not found");
                return -1;
            }
            return PlayerPrefs.GetFloat($"float_{key}");
        }

        
        
        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}