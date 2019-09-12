using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//必须要写，不然创建出来的不可复制、不可保存
public class EnemyInfo : ScriptableObject
{
    public List<ActionType> actionTypeList;
    public List<Property> propertyList;
    public LifeState lifeState;

}
public enum LifeState
{
    Dead,
    Free,//自由活动
    Hold,//定住

}
public enum ActionType
{
    Move,
    Rot90,
    Rot180,
    Jump,
}

public enum PropertyType
{
    Power,
    Coin,
    Skill,
}
[System.Serializable]
public class Property
{
    public PropertyType propertyType;
    public float weight;//0-100
}
