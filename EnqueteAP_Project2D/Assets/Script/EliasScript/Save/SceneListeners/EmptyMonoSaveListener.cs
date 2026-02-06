using System;
using System.Collections.Generic;

namespace Script.EliasScript.SceneListeners
{
    public class EmptyMonoSaveListener : MonoSaveListener
    {
        protected override void Write(List<ISavedProperty> properties)
        {
            throw new NotImplementedException();
        }

        protected override void Read(IReadOnlyList<ISavedProperty> properties)
        {
            throw new NotImplementedException();
        }
    }
}