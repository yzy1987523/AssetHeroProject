using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;

public static class EnemyInfoUtility
{
    public static EnemyInfo Create(string _path, string _name)
    {
        if (new DirectoryInfo(_path).Exists == false)
        {
            Debug.LogError("can't create asset, path not found");
            return null;
        }
        if (string.IsNullOrEmpty(_name))
        {
            Debug.LogError("can't create asset, the name is empty");
            return null;
        }
        string assetPath = Path.Combine(_path, _name + ".asset");
        EnemyInfo newAbilityInfo = ScriptableObject.CreateInstance<EnemyInfo>();//实例化
        AssetDatabase.CreateAsset(newAbilityInfo, assetPath);//保存在指定路径
        Selection.activeObject = newAbilityInfo;//光标自动选取
        return newAbilityInfo;
    }
    [MenuItem("Assets/Create/EnemyInfo")]
    static void Create()
    {
        string assetName = "New EnemyInfo";//创建后需要重命名
        string assetPath = "Assets";
        if (Selection.activeObject)
        {
            assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);//获取选取的对象的完整路径
            //由于有可能选取的对象是文件，而不是文件夹，所以需要做个判断：
            if (Path.GetExtension(assetPath) != "")//判断路径是否存在扩展名
            {
                assetPath = Path.GetDirectoryName(assetPath);//如果有扩展名，则获取该文件的路径
            }
        }

        bool doCreate = true;
        string path = Path.Combine(assetPath, assetName + ".asset");
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)//判断是否存在同名文件
        {
            //弹出dialog窗口
            doCreate = EditorUtility.DisplayDialog(assetName + " already exists.",
                                                    "Do you want to overwrite the old one?",
                                                    "Yes", "No");
        }
        if (doCreate)
        {
            EnemyInfo abilityInfo = EnemyInfoUtility.Create(assetPath, assetName);
            Selection.activeObject = abilityInfo;
        }
    }
}
#endif