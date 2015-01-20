using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace me.mholub.mhutils.templater
{
    public static class MenuItems
    {
        [MenuItem("Assets/Create/Module")]
        static void CreateModule()
        {
            CreateModuleEditorWindow.Init();
        }
    }
}