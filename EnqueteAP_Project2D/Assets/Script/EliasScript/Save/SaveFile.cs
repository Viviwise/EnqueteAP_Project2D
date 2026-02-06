using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.EliasScript
{
    [Serializable]
    public struct SaveFile
    {
        [SerializeField]
        public List<SaveElement> elements;
    }
}