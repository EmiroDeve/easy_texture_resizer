using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class TextureSizeChanger : EditorWindow
{
    private enum TextureSize { _32 = 32, _64 = 64, _128 = 128, _256 = 256, _512 = 512, _1024 = 1024, _2048 = 2048, _4096 = 4096, _8192 = 8192, _16384 = 16384 }
    private TextureSize selectedSize = TextureSize._256;

    private List<Texture2D> excludeTextures = new List<Texture2D>();

    [MenuItem("Tools/Texture Size Changer")]
    public static void ShowWindow()
    {
        GetWindow<TextureSizeChanger>("Texture Size Changer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Max Texture Size", EditorStyles.boldLabel);
        selectedSize = (TextureSize)EditorGUILayout.EnumPopup("Max Size", selectedSize);

        GUILayout.Space(10);
        GUILayout.Label("Exclude Textures", EditorStyles.boldLabel);

        for (int i = 0; i < excludeTextures.Count; i++)
        {
            GUILayout.BeginHorizontal();
            excludeTextures[i] = (Texture2D)EditorGUILayout.ObjectField(excludeTextures[i], typeof(Texture2D), false);

            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                excludeTextures.RemoveAt(i);
            }
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Texture"))
        {
            excludeTextures.Add(null);
        }

        GUILayout.Space(10);
        if (GUILayout.Button("Apply to All Textures"))
        {
            ChangeTextureSizes((int)selectedSize);
        }
    }

    private void ChangeTextureSizes(int newSize)
    {
        string[] guids = AssetDatabase.FindAssets("t:Texture");

        HashSet<string> excludePaths = new HashSet<string>();
        foreach (var tex in excludeTextures)
        {
            if (tex != null)
            {
                string path = AssetDatabase.GetAssetPath(tex);
                excludePaths.Add(path);
            }
        }

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            if (excludePaths.Contains(path))
            {
                Debug.Log($"Skipping: {path}");
                continue;
            }

            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

            if (importer != null)
            {
                importer.maxTextureSize = newSize;
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }

        Debug.Log($"All textures' max size changed to {newSize}, except excluded ones.");
        AssetDatabase.SaveAssets();
    }
}
