using System;
using System.Collections.Generic;

namespace Script.EliasScript
{
    public interface ISavedIntElement : ISavedElement
    {
        public Dictionary<String, int> SavedInts { get; }
    }
}