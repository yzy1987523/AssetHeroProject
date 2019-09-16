using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 全局对象池： 包含多个子对象池，
/// </summary>
public class GlobalPool
{
    #region Parameters
    private static GlobalPool instance;
    public List<OnePool> onePools; 

    #endregion
    #region Properties
    public static GlobalPool Instance
    {
        get
        {
            if (instance == null)
                instance = new GlobalPool();
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    #endregion
    #region Private Methods       
    #endregion
    #region Utility Methods
    #endregion
}
public class OnePool
{
    public List<Object> pool;
    public T GetObject<T>(Object _t)
    {
        if (pool.Contains(_t))
        {

        }
        return default;
    }
}
