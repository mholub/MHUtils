using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace me.mholub.mhutils.templater
{
    public static class MenuItems
    {
        [MenuItem("File/Templater/Create Module")]
        static void CreateModule()
        {
            CreateModuleEditorWindow.Init();
        }
    }
}