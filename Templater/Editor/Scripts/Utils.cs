using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.IO;
using System;

namespace me.mholub.mhutils.templater
{
    static public class Utils
    {
        public static void CreateModule(string path, bool doScripts, bool doModels, bool doTextures, bool doMaterials)
        {
            Debug.Log(MakeRelativePath(Application.dataPath + "/", Directory.GetParent(path).FullName));
            AssetDatabase.CreateFolder("Assets/" + MakeRelativePath(Application.dataPath + "/", Directory.GetParent(path).FullName), Path.GetFileName(path));
            if (doScripts)
            {
                AssetDatabase.CreateFolder("Assets/" + MakeRelativePath(Application.dataPath + "/", path), "Scripts");
            }
            if (doModels)
            {
                AssetDatabase.CreateFolder("Assets/" + MakeRelativePath(Application.dataPath + "/", path), "Models");
            }
            if (doTextures)
            {
                AssetDatabase.CreateFolder("Assets/" + MakeRelativePath(Application.dataPath + "/", path), "Textures");
            }
            if (doMaterials)
            {
                AssetDatabase.CreateFolder("Assets/" + MakeRelativePath(Application.dataPath + "/", path), "Materials");
            }
           
        }

        #region Utility methods
        public static string MakeRelativePath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (string.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            return relativePath;
        }
        #endregion
    }
}

