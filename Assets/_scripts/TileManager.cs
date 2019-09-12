using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 管理瓦片的生成：尺寸，显隐
/// </summary>
public class TileManager : MonoBehaviour
{
    #region Parameters
    public static TileManager _instance;
    public float tileShowTime = 1;
    public EasingEquation easeInType=EasingEquation.QuadEaseIn;
    public EasingEquation easeOutType=EasingEquation.QuadEaseOut;
    public event Action E_Show;
    public event Action E_Hide;
    List<TileObj> tileList;
    TileObj tileObj;
    /// <summary>
    /// 场景是正方形，最少为8*8
    /// </summary>
    public int size=8;
    /// <summary>
    /// 场景的每条边的长度
    /// </summary>
    public float length = 64;



    #endregion
    #region Properties
    public TileObj TileObj
    {
        get
        {
            if (tileObj == null)
            {
                tileObj = GetComponentInChildren<TileObj>(true);
                tileObj.gameObject.SetActive(false);
            }
            return tileObj;
        }

        set
        {
            tileObj = value;
        }
    }
    #endregion
    #region Private Methods       
    private void Awake()
    {
        _instance = this;
    }
    #endregion
    #region Utility Methods
    [ContextMenu("Show")]
    public void Init()
    {
        if (tileList == null)
        {
            var _count = size * size;
            tileList = new List<TileObj>();
            for (var i = 0; i < _count; i++)
            {
                var _obj = Instantiate(TileObj);
                _obj.transform.SetParent(transform);
                _obj.transform.localPosition = new Vector3(i/size,0,i%size);
                _obj.gameObject.SetActive(true);
                tileList.Add(_obj);
            }
        }
        Show();
    }
    public void Show()
    {
        E_Show?.Invoke();
    }
    public void Hide()
    {
        E_Hide?.Invoke();
    }
    #endregion  
}
