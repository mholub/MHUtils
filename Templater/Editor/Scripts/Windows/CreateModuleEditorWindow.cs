using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace me.mholub.mhutils.templater
{
    public class CreateModuleEditorWindow : EditorWindow
    {
        #region Variables
        static CreateModuleEditorWindow window;

        public bool DoScripts = true;
        public bool DoModels = false;
        public bool DoTextures = false;
        public bool DoMaterials = false;
        #endregion

        #region Main methods
        public static void Init()
        {
            window = EditorWindow.GetWindow<CreateModuleEditorWindow>(true, "Create New Module", true);
            window.minSize = window.maxSize = new Vector2(175, 122);
        }

        void OnGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.Space(10);

            DoScripts = EditorGUILayout.Toggle("Scripts", DoScripts);
            DoModels = EditorGUILayout.Toggle("Models", DoModels);
            DoTextures = EditorGUILayout.Toggle("Textures", DoTextures);
            DoMaterials = EditorGUILayout.Toggle("Materials", DoMaterials);

            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Create...", GUILayout.Width(70)))
            {
                var moduleName = EditorUtility.SaveFilePanel("Create New Module", "Assets/Modules", "", "");
                if (moduleName != null)
                {
                    Utils.CreateModule(moduleName, DoScripts, DoModels, DoTextures, DoMaterials);
                    
                    this.Close();
                }
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }

        #endregion

        #region Utility methods
        #endregion
    }
}

