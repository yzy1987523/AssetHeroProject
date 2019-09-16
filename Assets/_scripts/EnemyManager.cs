using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Parameters
    string pathHeadOfScriptableObjects = "ScriptableObjects/";
    string pathHeadOfPrefabs = "Prefabs/";
    [HideInInspector]
    public List<EnemyActor> enemyPool;
    
    #endregion
    #region Properties
    #endregion
    #region Private Methods  

    #endregion
    #region Utility Methods
    [ContextMenu("Load")]
    void LoadTest()
    {
        LoadScriptableObject("Enemy00");
    }
    public EnemyInfo LoadScriptableObject(string _name)
    {
       return (EnemyInfo)Resources.Load(pathHeadOfScriptableObjects+_name);
    }
    public void CreateEnemy(string _name)
    {

        EnemyActor _actor = (EnemyActor)Resources.Load(pathHeadOfPrefabs + _name);
    }
    #endregion
}
