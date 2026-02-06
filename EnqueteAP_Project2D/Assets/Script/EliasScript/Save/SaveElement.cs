using System;
using UnityEngine;

namespace Script.EliasScript
{
    [Serializable]
    public struct SaveElement
    {
        [SerializeField]
        public string guid;
        [SerializeReference]
        public ISavedProperty[] properties;
    }
}