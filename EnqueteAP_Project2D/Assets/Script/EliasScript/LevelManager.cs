using System;
using System.Collections;
using Script.EliasScript.SceneListeners;
using UnityEngine;

namespace Script.EliasScript
{
    public class LevelManager: MonoBehaviour

    {
        private IEnumerator Start()
        {
            DontDestroyOnLoad(gameObject);
            while (true)
            {

                MonoSaveListener.SaveAll();

                SaveManager.Push();
                
                yield return new WaitForSeconds(3);
                
                SaveManager.Pull();

                MonoSaveListener.LoadAll();
                yield return new WaitForSeconds(3);
            }
        }
    }
}