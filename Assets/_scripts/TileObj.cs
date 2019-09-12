using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 瓦片对象，有不同类型
/// </summary>
public class TileObj : MonoBehaviour, ISetValue
{
    #region Parameters
    Transform trans;
    [HideInInspector]
    public TileType tileType;


    #endregion
    #region Properties
    public Transform Trans
    {
        get
        {
            if (trans == null)
                trans = transform;
            return trans;
        }

        set
        {
            trans = value;
        }
    }
    #endregion
    #region Private Methods 
    private void OnEnable()
    {
        TileManager._instance.E_Show += Show;
        TileManager._instance.E_Hide += Hide;
    }
    private void OnDisable()
    {
        TileManager._instance.E_Show -= Show;
        TileManager._instance.E_Hide -= Hide;
    }
    IEnumerator IE_TypeChange(TileType _type)
    {
        //先将Type还原为Normal
        switch (tileType)
        {
            case TileType.Water:
                //水干
                break;
            case TileType.Tree:
                //树隐
                break;
            case TileType.Grass:
                //草隐
                break;
            case TileType.Wall:
                break;
        }
        yield return null;
        //再变化样式
        switch (_type)
        {
            case TileType.Ground:
                break;
            case TileType.Water:
                break;
            case TileType.Tree:
                break;
            case TileType.Grass:
                break;
            case TileType.Wall:
                break;
        }
        tileType = _type;
    }
    #endregion
    #region Utility Methods
    //初始当Type发生改变时，瓦片样式发生改变
    public void TypeChange(TileType _type)
    {
        if (tileType == _type) return;
    }
    public void Show()
    {        
        var _count = Enum.GetValues(typeof(MorphingValueType)).Length;
        var _org = new ValueData[_count];
        var _target = new ValueData[_count];
        //var _v0 = (int)MorphingValueType.localPosition;
        //_org[_v0] = new ValueData(MorphingTool.GetFloat4(Vector3.down*10));
        //_target[_v0] = new ValueData(MorphingTool.GetFloat4(Trans.localPosition));
        var _v1 = (int)MorphingValueType.localScale;
        _org[_v1] = new ValueData(MorphingTool.GetFloat4(Vector3.zero));
        _target[_v1] = new ValueData(MorphingTool.GetFloat4(Vector3.one));
        StartCoroutine( MorphingTool._instance.IE_Morphing(this, _org, _target, TileManager._instance.tileShowTime, TileManager._instance.easeInType));
    }
    public void Hide()
    {
        var _count = Enum.GetValues(typeof(MorphingValueType)).Length;
        var _org = new ValueData[_count];
        var _target = new ValueData[_count];
        var _v0 = (int)MorphingValueType.localRotation;
        _org[_v0] = new ValueData(MorphingTool.GetFloat4(Trans.localRotation));
        _target[_v0] = new ValueData(MorphingTool.GetFloat4(Quaternion.Euler(0, 0, 0)));
        var _v1 = (int)MorphingValueType.localScale;
        _org[_v1] = new ValueData(MorphingTool.GetFloat4(Vector3.one));
        _target[_v1] = new ValueData(MorphingTool.GetFloat4(Vector3.zero));
        MorphingTool._instance.IE_Morphing(this, _org, _target, TileManager._instance.tileShowTime, TileManager._instance.easeInType);
    }
    public void SetValue(MorphingValueType _type, ValueData _value)
    {
        switch (_type)
        {
            case MorphingValueType.Position:
                break;
            case MorphingValueType.localPosition:
                Trans.localPosition = MorphingTool.GetData(Trans.localPosition, _value);
                break;
            case MorphingValueType.Rotation:
                break;
            case MorphingValueType.localRotation:
                Trans.localRotation = MorphingTool.GetData(Trans.localRotation, _value);
                break;
            case MorphingValueType.localScale:
                Trans.localScale = MorphingTool.GetData(Trans.localScale, _value);
                break;
            case MorphingValueType.color:
                break;
            case MorphingValueType.value:
                break;
        }
    }
    #endregion
}
public enum TileType
{
    Ground,
    Water,
    Tree,
    Grass,
    Wall,

}