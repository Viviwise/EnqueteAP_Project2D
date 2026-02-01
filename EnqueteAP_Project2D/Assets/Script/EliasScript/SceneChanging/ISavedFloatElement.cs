using System;
using System.Collections.Generic;

namespace Script.EliasScript
{
    public interface ISavedFloatElement : ISavedElement
    {
        public Dictionary<String, float> SavedFloats { get; }
    }
}