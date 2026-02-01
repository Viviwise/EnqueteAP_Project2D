using System;
using System.Collections.Generic;

namespace Script.EliasScript
{
    public interface ISavedStringElement : ISavedElement
    {
        public Dictionary<String, string> SavedStrings { get; }
    }
}